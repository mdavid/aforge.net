// AForge Neural Net Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Neuro
{
    using System;

    /// <summary>
    /// Distance neuron.
    /// </summary>
    /// 
    /// <remarks><para>Distance neuron computes its output as distance between
    /// its weights and inputs - sum of absolute differences between weights'
    /// values and corresponding inputs' values. The neuron is usually used in Kohonen
    /// Self Organizing Map.</para></remarks>
    /// 
    [Serializable]
    public class DistanceNeuron : Neuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceNeuron"/> class.
        /// </summary>
        /// 
        /// <param name="inputs">Neuron's inputs count.</param>
        /// 
        public DistanceNeuron( int inputs ) : base( inputs ) { }

        /// <summary>
        /// Computes output value of neuron.
        /// </summary>
        /// 
        /// <param name="input">Input vector.</param>
        /// 
        /// <returns>The output value of distance neuron is equal to the distance
        /// between its weights and inputs - sum of absolute differences.
        /// The output value is also stored in <see cref="Neuron.Output">Output</see>
        /// property.</returns>
        /// 
        /// <exception cref="ArgumentException">Wrong length of the input vector, which is not
        /// equal to the <see cref="Neuron.InputsCount">expected value</see>.</exception>
        /// 
        public override double Compute( double[] input )
        {
            // check for corrent input vector
            if ( input.Length != inputsCount )
                throw new ArgumentException( "Wrong length of the input vector." );

            output = 0.0;

            // compute distance between inputs and weights
            for ( int i = 0; i < inputsCount; i++ )
            {
                output += Math.Abs( weights[i] - input[i] );
            }

            return output;
        }
    }
}
