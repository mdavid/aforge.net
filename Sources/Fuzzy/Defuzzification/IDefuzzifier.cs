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

    /// <summary>
    /// Interface which specifies set of methods required to be implemented by all defuzzification methods 
    /// that can be used in Fuzzy Inference Systems. 
    /// </summary>
    /// 
    /// <remarks><para>Typical Fuzzy Inference Systems need to calculate a numeric output, after obtaining a fuzzy 
    /// output. To calculate de numerical value of a fuzzy output a defuzzification method is required. Several 
    /// deffuzification methods were proposed, and they can be created as classes that implements this interface. 
    /// </para></remarks>
    /// 
    public interface IDefuzzifier
    {
        /// <summary>
        /// Defuzzification method to obtain the numerical representation of a fuzzy output.
        /// </summary>
        /// 
        /// <param name="fuzzyOutput">A <see cref="FuzzyOutput"/> containing the output of several rules of a Fuzzy 
        /// Inference System.</param>
        /// 
        /// <returns></returns>
        double Defuzzify( FuzzyOutput fuzzyOutput );
    }
}
