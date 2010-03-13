using System;
using System.Collections.Generic;
using AForge;
using AForge.Math.Geometry;
using MbUnit.Framework;

namespace AForge.Math.GeometryTests
{
    [TestFixture]
    public class LineStraighteningOptimizer
    {
        private IShapeOptimizer optimizer = new AForge.Math.Geometry.LineStraighteningOptimizer( 3 );

        [RowTest]
        [Row( new int[] { 0, 0, 10, 0, 10, 10 }, new int[] { 0, 0, 10, 0, 10, 10 } )]
        [Row( new int[] { 0, 0, 10, 0, 5, 1 }, new int[] { 0, 0, 10, 0, 5, 1 } )]
        [Row( new int[] { 0, 0, 10, 0, 10, 10, 5, 5 }, new int[] { 0, 0, 10, 0, 10, 10 } )]
        [Row( new int[] { 0, 0, 10, 0, 10, 10, 6, 6 }, new int[] { 0, 0, 10, 0, 10, 10 } )]
        [Row( new int[] { 0, 0, 10, 0, 10, 10, 4, 4 }, new int[] { 0, 0, 10, 0, 10, 10 } )]
        [Row( new int[] { 5, 5, 0, 0, 5, 0, 10, 0, 10, 5, 10, 10 }, new int[] { 0, 0, 10, 0, 10, 10 } )]
        [Row( new int[] { 6, 6, 0, 0, 6, 0, 10, 0, 10, 4, 10, 10 }, new int[] { 0, 0, 10, 0, 10, 10 } )]
        public void OptimizationTest( int[] coordinates, int[] expectedCoordinates )
        {
            List<IntPoint> shape = new List<IntPoint>( );
            List<IntPoint> expectedShape = new List<IntPoint>( );

            // build a shape top optimize
            for ( int i = 0, n = coordinates.Length / 2; i < n; i++ )
            {
                shape.Add( new IntPoint( coordinates[i * 2], coordinates[i * 2 + 1] ) );
            }

            // build a shape, which should be result of optimization
            for ( int i = 0, n = expectedCoordinates.Length / 2; i < n; i++ )
            {
                expectedShape.Add( new IntPoint( expectedCoordinates[i * 2], expectedCoordinates[i * 2 + 1] ) );
            }

            List<IntPoint> optimizedShape = optimizer.OptimizeShape( shape );

            // check number of points in result shape
            Assert.AreEqual( expectedShape.Count, optimizedShape.Count );

            // check that all points matches with expected
            for ( int i = 0, n = optimizedShape.Count; i < n; i++ )
            {
                Assert.AreEqual( expectedShape[i], optimizedShape[i] );
            }
        }
    }
}
