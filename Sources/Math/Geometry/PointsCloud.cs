// AForge Math Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2007-2009
// andrew.kirillov@aforgenet.com
//

namespace AForge.Math.Geometry
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Set of tools for processing collection of points in 2D space.
    /// </summary>
    /// 
    /// <remarks><para>The static class contains set of routines, which provide different
    /// operations with collection of points in 2D space. For example, finding the
    /// furthest point from a specified point or line.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create points' list
    /// List&lt;IntPoint&gt; points = new List&lt;IntPoint&gt;( );
    /// points.Add( new IntPoint( 10, 10 ) );
    /// points.Add( new IntPoint( 20, 15 ) );
    /// points.Add( new IntPoint( 15, 30 ) );
    /// points.Add( new IntPoint( 40, 12 ) );
    /// points.Add( new IntPoint( 30, 20 ) );
    /// // get furthest point from the specified point
    /// IntPoint p1 = PointsCloud.GetFurthestPoint( points, new IntPoint( 15, 15 ) );
    /// Console.WriteLine( p1.X + ", " + p1.Y );
    /// // get furthest point from line
    /// IntPoint p2 = PointsCloud.GetFurthestPointFromLine( points,
    ///     new IntPoint( 50, 0 ), new IntPoint( 0, 50 ) );
    /// Console.WriteLine( p2.X + ", " + p2.Y );
    /// </code>
    /// </remarks>
    /// 
    public static class PointsCloud
    {
        /// <summary>
        /// Find furhtest point from the specified point.
        /// </summary>
        /// 
        /// <param name="cloud">Collection of points to search furthest point in.</param>
        /// <param name="referencePoint">The point to search furthest point from.</param>
        /// 
        /// <returns>Returns a point, which is the furthest away from the <paramref name="referencePoint"/>.</returns>
        /// 
        public static IntPoint GetFurthestPoint( List<IntPoint> cloud, IntPoint referencePoint )
        {
            IntPoint furthestPoint = referencePoint;
            double maxDistance = -1;

            int rx = referencePoint.X;
            int ry = referencePoint.Y;

            foreach ( IntPoint point in cloud )
            {
                int dx = rx - point.X;
                int dy = ry - point.Y;
                // we are not calculating square root for finding "real" distance,
                // since it is really not important for finding furthest point
                double distance = dx * dx + dy * dy;

                if ( distance > maxDistance )
                {
                    maxDistance = distance;
                    furthestPoint = point;
                }
            }

            return furthestPoint;
        }

        /// <summary>
        /// Find two furhtest points from the specified line.
        /// </summary>
        /// 
        /// <param name="cloud">Collection of points to search furthest points in.</param>
        /// <param name="linePoint1">First point forming the line.</param>
        /// <param name="linePoint2">Second point forming the line.</param>
        /// <param name="furthestPoint1">First found furthest point.</param>
        /// <param name="furthestPoint2">Second found furthest point (which is on the
        /// opposite side from the line compared to the <paramref name="furthestPoint1"/>);</param>
        /// 
        /// <remarks><para>The method finds two furhtest points from the specified line,
        /// where one point is on one side from the line and the second point is on
        /// another side from the line.</para></remarks>
        /// 
        public static void GetFurthestPointsFromLine( List<IntPoint> cloud, IntPoint linePoint1, IntPoint linePoint2,
            out IntPoint furthestPoint1, out IntPoint furthestPoint2 )
        {
            double d1, d2;

            GetFurthestPointsFromLine( cloud, linePoint1, linePoint2,
                out furthestPoint1, out d1, out furthestPoint2, out d2 );
        }

        /// <summary>
        /// Find two furhtest points from the specified line.
        /// </summary>
        /// 
        /// <param name="cloud">Collection of points to search furthest points in.</param>
        /// <param name="linePoint1">First point forming the line.</param>
        /// <param name="linePoint2">Second point forming the line.</param>
        /// <param name="furthestPoint1">First found furthest point.</param>
        /// <param name="distance1">Distance between the first found point and the given line.</param>
        /// <param name="furthestPoint2">Second found furthest point (which is on the
        /// opposite side from the line compared to the <paramref name="furthestPoint1"/>);</param>
        /// <param name="distance2">Distance between the second found point and the given line.</param>
        /// 
        /// <remarks><para>The method finds two furhtest points from the specified line,
        /// where one point is on one side from the line and the second point is on
        /// another side from the line.</para></remarks>
        ///
        public static void GetFurthestPointsFromLine( List<IntPoint> cloud, IntPoint linePoint1, IntPoint linePoint2,
            out IntPoint furthestPoint1, out double distance1, out IntPoint furthestPoint2, out double distance2 )
        {
            furthestPoint1 = linePoint1;
            distance1 = 0;

            furthestPoint2 = linePoint2;
            distance2 = 0;

            if ( linePoint2.X != linePoint1.X )
            {
                // line's equation y(x) = k * x + b
                double k = (double) ( linePoint2.Y - linePoint1.Y ) / ( linePoint2.X - linePoint1.X );
                double b = linePoint1.Y - k * linePoint1.X;

                double div = Math.Sqrt( k * k + 1 );
                double distance = 0;

                foreach ( IntPoint point in cloud )
                {
                    distance = ( k * point.X + b - point.Y ) / div;

                    if ( distance > distance1 )
                    {
                        distance1 = distance;
                        furthestPoint1 = point;
                    }
                    if ( distance < distance2 )
                    {
                        distance2 = distance;
                        furthestPoint2 = point;
                    }
                }
            }
            else
            {
                int lineX = linePoint1.X;
                double distance = 0;

                foreach ( IntPoint point in cloud )
                {
                    distance = lineX - point.X;

                    if ( distance > distance1 )
                    {
                        distance1 = distance;
                        furthestPoint1 = point;
                    }
                    if ( distance < distance2 )
                    {
                        distance2 = distance;
                        furthestPoint2 = point;
                    }
                }
            }

            distance2 = -distance2;
        }

        /// <summary>
        /// Find the furhtest point from the specified line.
        /// </summary>
        /// 
        /// <param name="cloud">Collection of points to search furthest point in.</param>
        /// <param name="linePoint1">First point forming the line.</param>
        /// <param name="linePoint2">Second point forming the line.</param>
        /// 
        /// <returns>Returns a point, which is the furthest away from the
        /// specified line.</returns>
        /// 
        /// <remarks><para>The method finds the furthest point from the specified line.
        /// Unlike the <see cref="GetFurthestPointsFromLine( List{IntPoint}, IntPoint, IntPoint, out IntPoint, out IntPoint )"/>
        /// method, this method find only one point, which is the furthest away from the line
        /// regardless of side from the line.</para></remarks>
        ///
        public static IntPoint GetFurthestPointFromLine( List<IntPoint> cloud, IntPoint linePoint1, IntPoint linePoint2 )
        {
            double d;

            return GetFurthestPointFromLine( cloud, linePoint1, linePoint2, out d );
        }

        /// <summary>
        /// Find the furhtest point from the specified line.
        /// </summary>
        /// 
        /// <param name="cloud">Collection of points to search furthest points in.</param>
        /// <param name="linePoint1">First point forming the line.</param>
        /// <param name="linePoint2">Second point forming the line.</param>
        /// <param name="distance">Distance between the furhtest found point and the given line.</param>
        /// 
        /// <returns>Returns a point, which is the furthest away from the
        /// specified line.</returns>
        /// 
        /// <remarks><para>The method finds the furthest point from the specified line.
        /// Unlike the <see cref="GetFurthestPointsFromLine( List{IntPoint}, IntPoint, IntPoint, out IntPoint, out double, out IntPoint, out double )"/>
        /// method, this method find only one point, which is the furthest away from the line
        /// regardless of side from the line.</para></remarks>
        ///
        public static IntPoint GetFurthestPointFromLine( List<IntPoint> cloud, IntPoint linePoint1, IntPoint linePoint2, out double distance )
        {
            IntPoint furthestPoint = linePoint1;
            distance = 0;

            if ( linePoint2.X != linePoint1.X )
            {
                // line's equation y(x) = k * x + b
                double k = (double) ( linePoint2.Y - linePoint1.Y ) / ( linePoint2.X - linePoint1.X );
                double b = linePoint1.Y - k * linePoint1.X;

                double div = Math.Sqrt( k * k + 1 );
                double pointDistance = 0;

                foreach ( IntPoint point in cloud )
                {
                    pointDistance = Math.Abs( ( k * point.X + b - point.Y ) / div );

                    if ( pointDistance > distance )
                    {
                        distance = pointDistance;
                        furthestPoint = point;
                    }
                }
            }
            else
            {
                int lineX = linePoint1.X;
                double pointDistance = 0;

                foreach ( IntPoint point in cloud )
                {
                    distance = Math.Abs( lineX - point.X );

                    if ( pointDistance > distance )
                    {
                        distance = pointDistance;
                        furthestPoint = point;
                    }
                }
            }

            return furthestPoint;
        }
    }
}
