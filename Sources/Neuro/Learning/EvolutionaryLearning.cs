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

    class EvolutionaryLearning : ISupervisedLearning
    {
        // designed network for training which have to matach inputs and outputs
        private ActivationNetwork network;

        /// <summary>
        /// Random generator for newly generated neurons.
        /// </summary>
        IRandomNumberGenerator geneGenerator;
        /// <summary>
        /// Random generator for mutation values which will be added to existing neurons.
        /// </summary>
        IRandomNumberGenerator geneMutationGenerator;

        // genetic population
        private Population population;

        // selection method for chromosomes in population
        ISelectionMethod selectionMethod;

        // size of population
        private int populationSize;

        /// <summary>
        /// Crossover probability in neural network.
        /// </summary>
        double crossOverRate;

        /// <summary>
        /// Mutation probability in neural network.
        /// </summary>
        double mutationRate;
        /// <summary>
        /// Probability to add newly generated chromosome to population.
        /// </summary>
        double randomSelectionRate;

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
        EvolutionaryLearning( ActivationNetwork activationNetwork, int populationSize,
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

            this.network = activationNetwork;
            this.populationSize = populationSize;
            this.geneGenerator = chromosomeGenerator;
            this.geneMutationGenerator = mutationAdditionGenerator;
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
        EvolutionaryLearning( ActivationNetwork activationNetwork, int populationSize )
        {
            // Check of assumptions during debugging only
            Debug.Assert( activationNetwork != null );
            Debug.Assert( populationSize > 0 );

            DoubleRange range = new DoubleRange( -1, 1 );
            UniformGenerator generator = new UniformGenerator( range );

            this.network = activationNetwork;
            this.populationSize = populationSize;
            this.geneGenerator = generator;
            this.geneMutationGenerator = generator;
            this.selectionMethod = new RouletteWheelSelection( );
            this.crossOverRate = 0.75;
            this.mutationRate = 0.1;
            this.randomSelectionRate = 0.0;
        }


        public double Run( double[] input, double[] output )
        {
            // Evolutionary algorithm is global so there is not solution for one sample
            throw new NotImplementedException(
                "Function is not implemented by design: evolutionary algorithm is global - there is not solution for one input." );
        }

        public double RunEpoch( double[][] input, double[][] output )
        {
            Debug.Assert( input.Length > 0 );
            Debug.Assert( output.Length > 0 );
            Debug.Assert( input.Length == output.Length );
            Debug.Assert( network.InputsCount == input.Length );

            int inputSize = input[0].Length;
            int outputSize = output[0].Length;

            int networkSize = 0;

            for ( int i = 0, l = network.LayersCount; i < l; i++ )
            {
                ActivationLayer layer = network[i];
                for ( int j = 0, n = layer.NeuronsCount; j < n; j++ )
                {
                    ActivationNeuron neuron = layer[j];

                    // all weights and threshold
                    networkSize += neuron.InputsCount + 1;
                }
            }

            DoubleArrayChromosome chromosomeExample = new DoubleArrayChromosome(
                geneGenerator, new ExponentialGenerator( 1 ), geneMutationGenerator, networkSize );

            if ( population == null )
            {
                population = new Population( populationSize, chromosomeExample,
                    new EvolutionaryFitness( network, input, output ),
                selectionMethod );

                population.CrossoverRate = crossOverRate;
                population.MutationRate = mutationRate;
                population.RandomSelectionPortion = randomSelectionRate;
            }

            population.RunEpoch( );

            DoubleArrayChromosome chromosome = (DoubleArrayChromosome) population.BestChromosome;

            int v = 0;

            for ( int i = 0, l = network.LayersCount; i < l; i++ )
            {
                ActivationLayer layer = network[i];
                for ( int j = 0, n = layer.NeuronsCount; j < n; j++ )
                {
                    ActivationNeuron neuron = layer[j];

                    for ( int k = 0, w = neuron.InputsCount; k < w; k++ )
                    {
                        neuron[k] = chromosome.Value[v++];
                    }
                    neuron.Threshold = chromosome.Value[n++];
                }
            }

            Debug.Assert( v == networkSize );

            return population.BestChromosome.Fitness;
        }
    }
}
