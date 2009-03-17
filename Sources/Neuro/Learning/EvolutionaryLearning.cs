// AForge Neural Net Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2008-2009
// andrew.kirillov@aforgenet.com
//
// Copyright © Cezary Wagner, 2008
// Initial implementation of evolutionary learning algorithm
// Cezary.Wagner@gmail.com
//

namespace AForge.Neuro.Learning
{
    using System;
    using System.Diagnostics;
    using AForge.Genetic;
    using AForge.Math.Random;

    public class EvolutionaryLearning : ISupervisedLearning
    {
        // designed network for training which have to matach inputs and outputs
        private ActivationNetwork network;
        // number of weight in the network to train
        private int numberOfNetworksWeights;

        // genetic population
        private Population population;
        // size of population
        private int populationSize;

        // generator for newly generated neurons
        private IRandomNumberGenerator chromosomeGenerator;
        // mutation generators
        private IRandomNumberGenerator mutationMultiplierGenerator;
        private IRandomNumberGenerator mutationAdditionGenerator;

        // selection method for chromosomes in population
        private ISelectionMethod selectionMethod;

        // crossover probability in genetic population
        private double crossOverRate;
        // mutation probability in genetic population
        private double mutationRate;
        // probability to add newly generated chromosome to population
        private double randomSelectionRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvolutionaryLearning"/> class.
        /// </summary>
        /// 
        /// <param name="activationNetwork">Activation network to be trained.</param>
        /// <param name="populationSize">Size of genetic population.</param>
        /// <param name="chromosomeGenerator">Random numbers generator used for initialization of genetic
        /// population representing neural network's weights and thresholds (see <see cref="DoubleArrayChromosome.chromosomeGenerator"/>).</param>
        /// <param name="mutationMultiplierGenerator">Random numbers generator used to generate random
        /// factors for multiplication of network's weights and thresholds during genetic mutation
        /// (ses <see cref="DoubleArrayChromosome.mutationMultiplierGenerator"/>.)</param>
        /// <param name="mutationAdditionGenerator">Random numbers generator used to generate random
        /// values added to neural network's weights and thresholds during genetic mutation
        /// (see <see cref="DoubleArrayChromosome.mutationAdditionGenerator"/>).</param>
        /// <param name="selectionMethod">Method of selection best chromosomes in genetic population.</param>
        /// <param name="crossOverRate">Crossover rate in genetic population (see
        /// <see cref="Population.CrossoverRate"/>).</param>
        /// <param name="mutationRate">Mutation rate in genetic population (see
        /// <see cref="Population.MutationRate"/>).</param>
        /// <param name="randomSelectionRate">Rate of injection of random chromosomes during selection
        /// in genetic population (see <see cref="Population.RandomSelectionPortion"/>).</param>
        /// 
        public EvolutionaryLearning( ActivationNetwork activationNetwork, int populationSize,
            IRandomNumberGenerator chromosomeGenerator,
            IRandomNumberGenerator mutationMultiplierGenerator,
            IRandomNumberGenerator mutationAdditionGenerator,
            ISelectionMethod selectionMethod,
            double crossOverRate, double mutationRate, double randomSelectionRate )
        {
            // Check of assumptions during debugging only
            Debug.Assert( activationNetwork != null );
            Debug.Assert( populationSize > 0 );
            Debug.Assert( chromosomeGenerator != null );
            Debug.Assert( mutationMultiplierGenerator != null );
            Debug.Assert( mutationAdditionGenerator != null );
            Debug.Assert( selectionMethod != null );
            Debug.Assert( crossOverRate >= 0.0 && crossOverRate <= 1.0 );
            Debug.Assert( mutationRate >= 0.0 && crossOverRate <= 1.0 );
            Debug.Assert( randomSelectionRate >= 0.0 && randomSelectionRate <= 1.0 );

            // networks's parameters
            this.network = activationNetwork;
            this.numberOfNetworksWeights = CalculateNetworkSize( activationNetwork );

            // population parameters
            this.populationSize = populationSize;
            this.chromosomeGenerator = chromosomeGenerator;
            this.mutationMultiplierGenerator = mutationMultiplierGenerator;
            this.mutationAdditionGenerator = mutationAdditionGenerator;
            this.selectionMethod = selectionMethod;
            this.crossOverRate = crossOverRate;
            this.mutationRate = mutationRate;
            this.randomSelectionRate = randomSelectionRate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EvolutionaryLearning"/> class.
        /// </summary>
        /// 
        /// <param name="activationNetwork">Activation network to be trained.</param>
        /// <param name="populationSize">Size of genetic population.</param>
        ///
        public EvolutionaryLearning( ActivationNetwork activationNetwork, int populationSize )
        {
            // Check of assumptions during debugging only
            Debug.Assert( activationNetwork != null );
            Debug.Assert( populationSize > 0 );

            DoubleRange range = new DoubleRange( -1, 1 );
            UniformGenerator generator = new UniformGenerator( range );

            // networks's parameters
            this.network = activationNetwork;
            this.numberOfNetworksWeights = CalculateNetworkSize( activationNetwork );

            // population parameters
            this.populationSize = populationSize;
            this.chromosomeGenerator = new UniformGenerator( new DoubleRange( -1, 1 ) );
            this.mutationMultiplierGenerator = new ExponentialGenerator( 1 );
            this.mutationAdditionGenerator = new UniformGenerator( new DoubleRange( -0.5, 0.5 ) );
            this.selectionMethod = new EliteSelection( );
            this.crossOverRate = 0.75;
            this.mutationRate = 0.1;
            this.randomSelectionRate = 0.2;
        }

        // Create and initialize genetic population
        private int CalculateNetworkSize( ActivationNetwork activationNetwork )
        {
            // caclculate total amount of weight in neural network
            int networkSize = 0;

            for ( int i = 0, layersCount = network.LayersCount; i < layersCount; i++ )
            {
                ActivationLayer layer = network[i];

                for ( int j = 0, neuronsCount = layer.NeuronsCount; j < neuronsCount; j++ )
                {
                    // sum all weights and threshold
                    networkSize += layer[j].InputsCount + 1;
                }
            }

            return networkSize;
        }

        /// <summary>
        /// Runs learning iteration.
        /// </summary>
        /// 
        /// <param name="input">Input vector.</param>
        /// <param name="output">Desired output vector.</param>
        /// 
        /// <returns>Returns learning error.</returns>
        /// 
        /// <remarks><note>The method is not implemented, since evolutionary learning algorithm is global
        /// and requires all inputs/outputs in order to run its one epoch. Use <see cref="RunEpoch"/>
        /// method instead.</note></remarks>
        /// 
        /// <exception cref="NotImplementedException">The method is not implemented by design.</exception>
        /// 
        public double Run( double[] input, double[] output )
        {
            throw new NotImplementedException( "The method is not implemented by design." );
        }

        /// <summary>
        /// Runs learning epoch.
        /// </summary>
        /// 
        /// <param name="input">Array of input vectors.</param>
        /// <param name="output">Array of output vectors.</param>
        /// 
        /// <returns>Returns summary squared learning error for the entire epoch.</returns>
        ///
        public double RunEpoch( double[][] input, double[][] output )
        {
            Debug.Assert( input.Length > 0 );
            Debug.Assert( output.Length > 0 );
            Debug.Assert( input.Length == output.Length );
            Debug.Assert( network.InputsCount == input.Length );

            int inputSize = input[0].Length;
            int outputSize = output[0].Length;

            // check if it is a first run and create population if so
            if ( population == null )
            {
                // sample chromosome
                DoubleArrayChromosome chromosomeExample = new DoubleArrayChromosome(
                    chromosomeGenerator, mutationMultiplierGenerator, mutationAdditionGenerator,
                    numberOfNetworksWeights );

                // create population ...
                population = new Population( populationSize, chromosomeExample,
                    new EvolutionaryFitness( network, input, output ), selectionMethod );
                // ... and configure it
                population.CrossoverRate = crossOverRate;
                population.MutationRate = mutationRate;
                population.RandomSelectionPortion = randomSelectionRate;
            }

            // run genetic epoch
            population.RunEpoch( );

            // get best chromosome of the population
            DoubleArrayChromosome chromosome = (DoubleArrayChromosome) population.BestChromosome;
            double[] chromosomeGenes = chromosome.Value;

            // put best chromosome's value into neural network's weights
            int v = 0;

            for ( int i = 0, layersCount = network.LayersCount; i < layersCount; i++ )
            {
                ActivationLayer layer = network[i];

                for ( int j = 0, neuronsCount = layer.NeuronsCount; j < neuronsCount; j++ )
                {
                    ActivationNeuron neuron = layer[j];

                    for ( int k = 0, weightsCount = neuron.InputsCount; k < weightsCount; k++ )
                    {
                        neuron[k] = chromosomeGenes[v++];
                    }
                    neuron.Threshold = chromosomeGenes[v++];
                }
            }

            Debug.Assert( v == numberOfNetworksWeights );

            return 1.0 / chromosome.Fitness;
        }
    }
}
