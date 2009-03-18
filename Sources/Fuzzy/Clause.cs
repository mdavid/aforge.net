// AForge Fuzzy Library
// AForge.NET framework
//
// Copyright � Andrew Kirillov, 2005-2008 
// andrew.kirillov@gmail.com 
//
// Copyright � Fabio L. Caversan, 2008
// fabio.caversan@gmail.com
//

namespace AForge.Fuzzy
{
    using System;
    using System.Collections.Generic;

    // TODO: Document class
    public class Clause
    {
        // the linguistic var of the clause
        private LinguisticVariable variable;
        // the label of the clause
        private FuzzySet label;

        /// <summary>
        /// Gets the <see cref="LinguisticVariable"/> of the <see cref="Clause"/>.
        /// </summary>
        public LinguisticVariable Variable
        {
            get { return variable; }
        }

        /// <summary>
        /// Gets the <see cref="FuzzySet"/> of the <see cref="Clause"/>.
        /// </summary>
        public FuzzySet Label
        {
            get { return label; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clause"/> class.
        /// </summary>
        /// 
        /// <param name="variable">Linguistic variable of the clause. </param>
        /// 
        /// <param name="label">Label of the linguistic variable, a fuzzy set used as label into the linguistic variable.</param>
        /// 
        /// <exception cref="KeyNotFoundException">The label indicated was not found in the linguistic variable.</exception>
        /// 
        public Clause( LinguisticVariable variable, FuzzySet label )
        {
            // Check if label belongs to var.
            variable.GetLabel( label.Name );
            
            // Initializing attributes
            this.label    = label;
            this.variable = variable;
        }

        /// <summary>
        /// Evaluates the fuzzy clause.
        /// </summary>
        /// 
        /// <param name="x">Value which membership needs to be calculated.</param>
        /// 
        /// <returns>Degree of membership [0..1] of the clause.</returns>
        /// 
        public double Evaluate( double x )
        {
            return label.GetMembership( x );
        }

        /// <summary>
        /// Evaluates the fuzzy clause using the linguistic variable's numeric input.
        /// </summary>
        /// 
        /// <returns>Degree of membership [0..1] of the clause.</returns>
        /// 
        public double Evaluate( )
        {
            return Evaluate( variable.NumericInput );
        }

        /// <summary>
        /// Returns the fuzzy clause in its linguistic representation.
        /// </summary>
        /// 
        /// <returns>A string representing the fuzzy clause.</returns>
        /// 
        public string ToString( )
        {
            return this.variable.Name + " IS " + this.label.Name;
        }
    }
}
