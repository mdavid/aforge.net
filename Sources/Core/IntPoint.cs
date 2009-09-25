// AForge Core Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2007-2009
// andrew.kirillov@aforgenet.com
//

namespace AForge
{
    using System;

    /// <summary>
    /// Structure for representing a pair of coordinates of integer type.
    /// </summary>
    /// 
    /// <remarks><para>The class is used to store a pair of integer coordinates.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // assigning coordinates in the constructor
    /// IntPoint p1 = new IntPoint( 10, 20 );
    /// // creating a point and assigning coordinates later
    /// IntPoint p2;
    /// p2.X = 30;
    /// p2.Y = 40;
    /// // calculating distance between two points
    /// double distance = p1.DistanceTo( p2 );
    /// </code>
    /// </remarks>
    /// 
    public struct IntPoint
    {
        /// <summary> 
        /// X coordinate.
        /// </summary> 
        /// 
        public int X;

        /// <summary> 
        /// Y coordinate.
        /// </summary> 
        /// 
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntPoint"/> structure.
        /// </summary>
        /// 
        /// <param name="x">X axis coordinate.</param>
        /// <param name="y">Y axis coordinate.</param>
        /// 
        public IntPoint( int x, int y )
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Calculate Euclidean distance between two points.
        /// </summary>
        /// 
        /// <param name="anotherPoint">Point to calculate distance to.</param>
        /// 
        /// <returns>Returns Euclidean distance between this point and
        /// <paramref name="anotherPoint"/> points.</returns>
        /// 
        public double DistanceTo( IntPoint anotherPoint )
        {
            int dx = X - anotherPoint.X;
            int dy = Y - anotherPoint.Y;

            return System.Math.Sqrt( dx * dx + dy * dy );
        }
    }
}
