// AForge Fuzzy Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008 
// andrew.kirillov@gmail.com 
//
// Copyright © Fabio L. Caversan, 2008-2009
// fabio.caversan@gmail.com
//

namespace AForge.Fuzzy
{
    using System;
    using System.Collections.Generic;

    
    public class CentroidDefuzzifier: IDefuzzifier
    {
        private int intervals;
        
        public CentroidDefuzzifier( int intervals )
        {
            this.intervals = intervals;
        }

        /// <summary>
        /// Centroid method to obtain the numerical representation of a fuzzy output. The numerical value will be the center of the
        /// shape formed by the several fuzzy labels with their constraints.
        /// </summary>
        /// 
        /// <param name="fuzzyOutput">A <see cref="FuzzyOutput"/> containing the output of several rules of a Fuzzy 
        /// Inference System.</param>
        /// 
        /// <param name="normOperator">A <see cref="INorm"/> operator to be used when constraining the label to the firing strength.</param>
        /// 
        /// <exception cref="Exception">The numerical output in unavaliable. All memberships are zero.</exception>
        /// 
        /// <returns>The numerical representation of the fuzzy output.</returns>
        /// 
        public double Defuzzify( FuzzyOutput fuzzyOutput, INorm normOperator )
        {
            // Results and accumulators
            double weightSum = 0, membershipSum = 0;

            // Speech universe
            double start = fuzzyOutput.OutputVariable.Start;
            double end = fuzzyOutput.OutputVariable.End;

            // Increment
            double increment = ( end - start ) / this.intervals;
            
            // Running all the speech universe and evaluating the labels at each point
            for ( double x=start; x<end; x+=increment )
            {
                // We must evaluate x membership to each one of the output labels
                foreach ( FuzzyOutput.OutputConstraint oc in fuzzyOutput.OutputList )
                {
                    // Getting the membership for X and constraining it with the firing strength
                    double membership = fuzzyOutput.OutputVariable.GetLabelMembership(oc.Label, x);
                    double constrainedMembership = normOperator.Evaluate( membership, oc.FiringStrength );

                    weightSum += x*constrainedMembership;
                    membershipSum += constrainedMembership;
                }
            }

            // If no membership was found, then the membershipSum is zero and the numerical output is unknown.
            if ( membershipSum == 0 )
                throw new Exception( "The numerical output in unavaliable. All memberships are zero." );

            return weightSum / membershipSum ;
        }

    }
}
