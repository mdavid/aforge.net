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

    public class InferenceSystem
    {
        // The linguistic variables of this system
        private Database database;
        // The fuzzy rules of this system
        private Rulebase rulebase;
        // The defuzzifier method choosen 
        private IDefuzzifier defuzzifier;
        // Norm operator used in rules and deffuzification
        private INorm normOperator;
        // CoNorm operator used in rules
        private ICoNorm conormOperator;

        /// <summary>
        /// Initializes a new Fuzzy <see cref="InferenceSystem"/>.
        /// </summary>
        /// 
        /// <param name="database">A fuzzy <see cref="Database"/> containing the system linguistic variables.</param>
        /// 
        /// <param name="defuzzifier">A defuzzyfier method used to evaluate the numeric uotput of the system.</param>
        /// 
        public InferenceSystem( Database database, IDefuzzifier defuzzifier )
            : this(database, defuzzifier, new MinimumNorm(), new MaximumCoNorm())
        {
        }

        /// <summary>
        /// Initializes a new Fuzzy <see cref="InferenceSystem"/>.
        /// </summary>
        /// 
        /// <param name="database">A fuzzy <see cref="Database"/> containing the system linguistic variables.</param>
        /// 
        /// <param name="defuzzifier">A defuzzyfier method used to evaluate the numeric uotput of the system.</param>
        /// 
        /// <param name="defuzzifier">A <see cref="INorm"/> operator used to evaluate the norms in the <see cref="InferenceSystem"/>.</param>
        /// 
        /// <param name="defuzzifier">A <see cref="ICoNorm"/> operator used to evaluate the conorms in the <see cref="InferenceSystem"/>.</param>
        /// 
        public InferenceSystem( Database database, IDefuzzifier defuzzifier, INorm normOperator, ICoNorm conormOperator )
        {
            this.database       = database;
            this.defuzzifier    = defuzzifier;
            this.normOperator   = normOperator;
            this.conormOperator = conormOperator;
            this.rulebase       = new Rulebase( );
        }

        /// <summary>
        /// Creates a new <see cref="Rule"/> and add it to the <see cref="RuleBase"/> of the 
        /// <see cref="InferenceSystem"/>.
        /// </summary>
        /// 
        /// <param name="name">Name of the <see cref="Rule"/> to create.</param>
        /// 
        /// <param name="rule">A string representing the fuzzy rule.</param>
        /// 
        /// <returns>The new <see cref="Rule"/> reference. </returns>
        public Rule NewRule( string name, string rule )
        {
            Rule r = new Rule( database, name, rule, normOperator, conormOperator );
            this.rulebase.AddRule( r );
            return r;
        }

        /// <summary>
        /// Sets a numerical input for one of the linguistic variables of the <see cref="Database"/>. 
        /// </summary>
        /// 
        /// <param name="variableName">Name of the <see cref="LinguisticVariable"/>.</param>
        /// 
        /// <param name="value">Numeric value to be used as input.</param>
        /// 
        /// <exception cref="KeyNotFoundException">The variable indicated in variableName was not found in the database.</exception>
        /// 
        public void SetInput( string variableName, double value )
        {
            this.database.GetVariable( variableName ).NumericInput = value;
        }

        /// <summary>
        /// Executes the fuzzy inference, obtaining a numerical output for a choosen output linguistic variable. 
        /// </summary>
        /// 
        /// <param name="variableName">Name of the <see cref="LinguisticVariable"/> to evaluate.</param>
        /// 
        /// <returns>The numerical output of the Fuzzy Inference System for the choosen variable.</returns>
        /// 
        /// <exception cref="KeyNotFoundException">The variable indicated was not found in the database.</exception>
        /// 
        public double Evaluate( string variableName )
        {
            // Gets the variable
            LinguisticVariable lingVar = database.GetVariable( variableName );
            
            // Object to store the fuzzy output
            FuzzyOutput fuzzyOutput = new FuzzyOutput( lingVar );
            
            // Select only rules with the variable as output
            Rule [] rules = rulebase.GetRules();
            foreach (Rule r in rules)
            {
                if ( r.Output.Variable.Name == variableName )
                {
                    string labelName = r.Output.Label.Name;
                    double firingStrength = r.EvaluateFiringStrength();
                    if ( firingStrength > 0)
                        fuzzyOutput.AddOutput( labelName, firingStrength );
                }
            }

            // Call the defuzzification on fuzzy output 
            double res = defuzzifier.Defuzzify( fuzzyOutput, normOperator );
            return res;
        }

    }
}
