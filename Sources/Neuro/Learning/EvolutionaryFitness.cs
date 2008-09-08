// AForge Neural Net Library
//
// Copyright © Cezary Wagner, 2008
// Evolutionary learning algorithm
// Cezary Wagner
//
// Copyright © Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

using System;
using System.Diagnostics;
using AForge.Genetic;

namespace AForge.Neuro.Learning
{
    class EvolutionaryFitness : IFitnessFunction
    {
        ActivationNetwork network;
        double[][] input;
        double[][] output;

        public EvolutionaryFitness(ActivationNetwork network, double[][] input, double[][] output)
        {
            Debug.Assert(input.Length > 0 && output.Length > 0);
            Debug.Assert(input.Length == output.Length);
            Debug.Assert(network.InputsCount == input[0].Length);

            this.network = network;
            this.input = input;
            this.output = output;
        }

        public double Evaluate(IChromosome c)
        {
            DoubleArrayChromosome dac = (DoubleArrayChromosome)c;

            int d = 0;

            // asign new weights and thresholds to network from chromosome
            for (int i = 0, l = network.LayersCount; i < l; i++)
            {
                ActivationLayer layer = network[i];

                for (int j = 0, n = layer.NeuronsCount; j < n; j++)
                {
                    ActivationNeuron neuron = layer[j];

                    for (int k = 0, w = neuron.InputsCount; k < w; k++)
                    {
                        neuron[k] = dac.Value[d++];
                    }
                    neuron.Threshold = dac.Value[d++];
                }
            }
            // post check if all values is processed and lenght of chromosome is equal to network size
            Debug.Assert(d == dac.Length);

            double totalError = 0;

            for (int i = 0, li = input.Length; i < li; i++)
            {
                double[] computedOutput = network.Compute(input[i]);

                for (int j = 0, lo = output[0].Length; j < lo; j++)
                {
                    double error = output[i][j] - computedOutput[j];
                    totalError += error * error;
                }
            }

            if (totalError > 0)
                return 1.0 / totalError;
            else
                return 0;
        }

        public object Translate(IChromosome c)
        {
            // function should be romove in future from interface
            // it coulde be realise in outside code from double values
            Debug.Assert(false);
            return null;
        }
    }
}
