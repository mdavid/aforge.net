// AForge Neural Net Library
//
// Copyright © Cezary Wagner, 2008
// Evolutionary learning algorithm
// Cezary.Wagner@gmail.com
//
// Copyright © Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

using System;
using System.Diagnostics;
using AForge.Genetic;
using AForge.Math.Random;

namespace AForge.Neuro.Learning
{
    class EvolutionaryLearning : ISupervisedLearning
    {
        int populationSize;
        ActivationNetwork network;
        IRandomNumberGenerator geneGenerator;
        IRandomNumberGenerator geneMutationGenerator;
        ISelectionMethod selectionMethod;

        Population population;
        double crossOverRate;
        double mutationRate;
        double randomSelectionRate;

        /// <summary>
        /// Contructor of population of chromosomes.
        /// </summary>
        /// <param name="activationNetwork">Activation network to be trained.</param>
        /// <param name="populationSize">Size of chromosome population.</param>
        /// <param name="geneGenerator">Random generator for initialization of neural network weights and thresholds.</param>
        /// <param name="geneMutationGenerator">Random generator for modyfication neural network wieghts and thresholds.</param>
        /// <param name="selectionMethod">Method of selection best chromosomes for neural network.</param>
        /// <param name="crossOverRate">Rate of cross over of chromosomes (values should be high about 0.75).</param>
        /// <param name="mutationRate">Rate of mutation of chormosomes (value should be low about 0.1).</param>
        /// <param name="randomSelectionRate">Rate of injection of random chromosomes during selection (value should be low about 0.0).</param>
        EvolutionaryLearning(ActivationNetwork activationNetwork, int populationSize,
            IRandomNumberGenerator geneGenerator, IRandomNumberGenerator geneMutationGenerator,
            ISelectionMethod selectionMethod, double crossOverRate, double mutationRate, double randomSelectionRate)
        {
            // Check of assumptions during debugging only
            Debug.Assert(activationNetwork != null);
            Debug.Assert(populationSize > 0);
            Debug.Assert(geneGenerator != null);
            Debug.Assert(geneMutationGenerator != null);
            Debug.Assert(selectionMethod != null);
            Debug.Assert(crossOverRate >= 0.0 && crossOverRate <= 1.0);
            Debug.Assert(mutationRate >= 0.0 && crossOverRate <= 1.0);
            Debug.Assert(randomSelectionRate >= 0.0 && randomSelectionRate <= 1.0);

            this.network = activationNetwork;
            this.populationSize = populationSize;
            this.geneGenerator = geneGenerator;
            this.geneMutationGenerator = geneMutationGenerator;
            this.selectionMethod = selectionMethod;
            this.crossOverRate = crossOverRate;
            this.mutationRate = mutationRate;
            this.randomSelectionRate = randomSelectionRate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activationNetwork">Activation network to be trained.</param>
        /// <param name="populationSize">Size of chromosome population.</param>
        /// <param name="mutationRange">Range for weight and thresholds initial values and mutations.</param>
        EvolutionaryLearning(ActivationNetwork activationNetwork, int populationSize, double mutationRange)
        {
            // Check of assumptions during debugging only
            Debug.Assert(activationNetwork != null);
            Debug.Assert(populationSize > 0);
            Debug.Assert(mutationRange > 0);

            DoubleRange range = new DoubleRange(-mutationRange, mutationRange);
            UniformGenerator generator = new UniformGenerator(range);

            this.network = activationNetwork;
            this.populationSize = populationSize;
            this.geneGenerator = generator;
            this.geneMutationGenerator = generator;
            this.selectionMethod = new RouletteWheelSelection();
            this.crossOverRate = 0.75;
            this.mutationRate = 0.1;
            this.randomSelectionRate = 0.0;
        }
        public double Run(double[] input, double[] output)
        {
            // Evolutionary algorithm is global so there is not solution for one sample
            throw new NotImplementedException(
                "Function is not implemented by design: evolutionary algorithm is global - there is not solution for one input.");
        }

        public double RunEpoch(double[][] input, double[][] output)
        {
            Debug.Assert(input.Length > 0);
            Debug.Assert(output.Length > 0);
            Debug.Assert(input.Length == output.Length);
            Debug.Assert(network.InputsCount == input.Length);

            int inputSize = input[0].Length;
            int outputSize = output[0].Length;

            int networkSize = 0;

            for (int i = 0, l = network.LayersCount; i < l; i++)
            {
                ActivationLayer layer = network[i];
                for (int j = 0, n = layer.NeuronsCount; j < n; j++)
                {
                    ActivationNeuron neuron = layer[j];

                    // all weights and threshold
                    networkSize += neuron.InputsCount + 1;
                }
            }

            DoubleArrayChromosome chromosomeExample = new DoubleArrayChromosome(
                geneGenerator, geneMutationGenerator, networkSize);

            if (population == null)
            {
                population = new Population(populationSize, chromosomeExample,
                    new EvolutionaryFitness(network, input, output),
                selectionMethod);

                population.CrossoverRate = crossOverRate;
                population.MutationRate = mutationRate;
                population.RandomSelectionPortion = randomSelectionRate;
            }

            population.RunEpoch();

            DoubleArrayChromosome chromosome = (DoubleArrayChromosome)population.BestChromosome;

            int v = 0;

            for (int i = 0, l = network.LayersCount; i < l; i++)
            {
                ActivationLayer layer = network[i];
                for (int j = 0, n = layer.NeuronsCount; j < n; j++)
                {
                    ActivationNeuron neuron = layer[j];

                    for (int k = 0, w = neuron.InputsCount; k < w; k++)
                    {
                        neuron[k] = chromosome.Value[v++];
                    }
                    neuron.Threshold = chromosome.Value[n++];
                }
            }

            Debug.Assert(v == networkSize);

            return population.BestChromosome.Fitness;
        }
    }
}
