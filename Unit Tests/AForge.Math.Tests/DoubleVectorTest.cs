using System;
using System.Collections.Generic;
using AForge;
using AForge.Math;
using MbUnit.Framework;

namespace AForge.Math.Tests
{
    [TestFixture]
    public class DoubleVectorTest
    {
        [Test]
        public void ConstructorTest( )
        {
            DoubleVector vector1 = new DoubleVector( 4 );
            DoubleVector vector2 = new DoubleVector( new double[] { 1, 2, 3, 4 } );
            DoubleVector vector3 = new DoubleVector( vector2 );

            Assert.AreEqual( 4, vector1.Length );
            Assert.AreEqual( 4, vector2.Length );
            Assert.AreEqual( 4, vector3.Length );

            Assert.AreEqual( 0, vector1[0] );
            Assert.AreEqual( 1, vector2[0] );
            Assert.AreEqual( 1, vector3[0] );

            Assert.AreEqual( 0, vector1[3] );
            Assert.AreEqual( 4, vector2[3] );
            Assert.AreEqual( 4, vector3[3] );
        }

        [Test]
        public void CopyFromSamllerArrayTest( )
        {
            DoubleVector vector = new DoubleVector( new double[] { 1, 2, 3 } );

            vector.CopyFrom( new double[] { 5, 6 } );

            Assert.AreEqual( 5, vector[0] );
            Assert.AreEqual( 6, vector[1] );
            Assert.AreEqual( 3, vector[2] );
        }

        [Test]
        public void CopyFromLargerArrayTest( )
        {
            DoubleVector vector = new DoubleVector( new double[] { 1, 2, 3 } );

            vector.CopyFrom( new double[] { 5, 6, 7, 8 } );

            Assert.AreEqual( 5, vector[0] );
            Assert.AreEqual( 6, vector[1] );
            Assert.AreEqual( 7, vector[2] );
        }

        [Test]
        [Row( new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, true )]
        [Row( new double[] { 1, 2, 3 }, new double[] { 1, 2, 4 }, false )]
        [Row( new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4 }, false )]
        public void EqualityTest( double[] v1, double[] v2, bool expectedResult )
        {
            DoubleVector vector1 = new DoubleVector( v1 );
            DoubleVector vector2 = new DoubleVector( v2 );

            Assert.AreEqual( vector1.Equals( vector2 ), expectedResult );
        }

        [Test]
        [Row( 2.0, new double[] { 1, 2, 3, 4 }, new double[] { 2, 4, 6, 8 } )]
        [Row( 3.0, new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 3, 6, 9, 12, 15, 18 } )]
        [Row( 0.5, new double[] { 1, 2 }, new double[] { 0.5, 1 } )]
        public void MultiplyElementsTest( double factor, double[] values, double[] expectedValues )
        {
            DoubleVector vector = new DoubleVector( values );
            DoubleVector expectedResult = new DoubleVector( expectedValues );

            vector.MultiplyElements( factor );

            Assert.AreEqual( vector, expectedResult );
        }

        [Test]
        [Row( 2.0, new double[] { 1, 2, 3, 4 }, new double[] { 3, 4, 5, 6 } )]
        [Row( 3.0, new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 4, 5, 6, 7, 8, 9 } )]
        [Row( -0.5, new double[] { 1, 2 }, new double[] { 0.5, 1.5 } )]
        public void AddToElementsTest( double valueToAdd, double[] values, double[] expectedValues )
        {
            DoubleVector vector = new DoubleVector( values );
            DoubleVector expectedResult = new DoubleVector( expectedValues );

            vector.AddToElements( valueToAdd );

            Assert.AreEqual( vector, expectedResult );
        }

        [Test]
        [Row( new double[] { 1, 2, 3 }, 2 )]
        [Row( new double[] { 1, 2, 3, 4, 5 }, 3 )]
        [Row( new double[] { 1, 4, 5, 6, 9 }, 5 )]
        [Row( new double[] { }, double.NaN )]
        public void GetMeanTest( double[] values, double expectedMean )
        {
            DoubleVector vector = new DoubleVector( values );

            Assert.AreEqual( vector.GetMean( ), expectedMean );
        }

        [Test]
        [Row( new double[] { 2, 2, 2 }, 0 )]
        [Row( new double[] { 2, 2, 4, 4 }, 1 )]
        [Row( new double[] { }, double.NaN )]
        public void GetStdDevTest( double[] values, double expectedStdDev )
        {
            DoubleVector vector = new DoubleVector( values );

            Assert.AreEqual( vector.GetStdDev( ), expectedStdDev );
        }
    }
}
