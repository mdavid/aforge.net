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
    /// Interface with the common methods of a Fuzzy Hedge.
    /// </summary>
    /// 
    /// <remarks><para>A fuzzy hedge is a modifier used before a linguistic label to change its meaning. Lets us consider 
    /// the existence of a "hot" label in a "temperature" linguistic variable. A "very" fuzzy hedge can be applied to the
    /// "hot" label, resulting in the "very hot" linguistic expression. 
    /// 
    /// Fuzzy hedges are unary operators that modify the shape of the label membership's function. 
    /// All fuzzy hedges must implement this interface.
    /// </para></remarks>
    /// 
    public interface IHedge: IUnaryOperator
    {

    }
}
