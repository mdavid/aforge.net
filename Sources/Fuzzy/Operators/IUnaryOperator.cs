// AForge Fuzzy Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008 
// andrew.kirillov@gmail.com 
//
// Copyright © Fabio L. Caversan, 2008
// fabio.caversan@gmail.com
//
namespace AForge.Fuzzy
{
    using System;

    /// <summary>
    /// Interface with the common methods of a Fuzzy Unary Operator.
    /// </summary>
    /// 
    /// <remarks><para>All fuzzy unary operator must implement this interface.
    /// </para></remarks>
    /// 
    public interface IUnaryOperator : IOperator
    {
        /// <summary>
        /// Calculates the numerical result of the application of an unary operator
        /// to a fuzzy membership value.
        /// </summary>
        /// 
        /// <param name="membership">A fuzzy membership value, [0..1].</param>
        /// 
        /// <returns>The numerical result of the application of an unary operator
        /// to a fuzzy membership value.</returns>
        /// 
        double Evaluate( double membership );
    }
}
