// AForge Math Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2005-2010
// andrew.kirillov@aforgenet.com
//

namespace AForge.Math
{
    using System;
    using System.IO;

    /// <summary>
    /// Vector of double precision floating point values.
    /// </summary>
    /// 
    /// <remarks><para>The class wraps a vector of double precision floating point values.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create vector from raw values
    /// double[] rawValues = new double[] { 1, 2, 3 };
    /// DoubleVector vector1 = new DoubleVector( rawValues );
    /// // create new epty vector of the same size
    /// DoubleVector vector2 = new DoubleVector( vector1.Length );
    /// // create a copy
    /// DoubleVector vector3 = new DoubleVector( vector1 );
    /// // get mean and std.dev. of vector's value
    /// double mean   = vector1.GetMean( );
    /// double stdDev = vector1.GetStdDev( );
    /// </code>
    /// </remarks>
    /// 
    public class DoubleVector
    {
        private double[] values;

        /// <summary>
        /// Values accessor.
        /// </summary>
        /// 
        /// <param name="index">Element's index to access.</param>
        /// 
        /// <remarks>Allows to access values of the vector by their index.</remarks>
        /// 
        public double this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }

        /// <summary>
        /// Vector's length (number of elements).
        /// </summary>
        public int Length
        {
            get { return values.Length; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleVector"/> class.
        /// </summary>
        /// 
        /// <param name="size">Size of vector to create.</param>
        /// 
        /// <remarks><para>The constructor creates zero initialized vector of the specified size.</para></remarks>
        /// 
        public DoubleVector( int size )
        {
            values = new double[size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleVector"/> class.
        /// </summary>
        /// 
        /// <param name="values">Values used to initialize vector.</param>
        /// 
        /// <remarks><para>The constructor creates a vector initializing it with specified values.</para>
        /// </remarks>
        /// 
        public DoubleVector( double[] values )
        {
            this.values = (double[]) values.Clone( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleVector"/> class.
        /// </summary>
        /// 
        /// <param name="sample">Vector to make copy of.</param>
        /// 
        /// <remarks><para>This is a copy constructor, which makes exact copy of the
        /// <paramref name="sample"/> vector by cloning it.</para></remarks>
        /// 
        public DoubleVector( DoubleVector sample )
        {
            this.values = (double[]) sample.values.Clone( );
        }

        /// <summary>
        /// Set all vector's elements to the specified value.
        /// </summary>
        /// 
        /// <param name="value">Value to set for all vector's elements.</param>
        /// 
        public void SetAllElements( double value )
        {
            unsafe
            {
                fixed ( double* tptr = values )
                {
                    double* ptr = tptr;
                    double* ptrLimit = ptr + values.Length;

                    for ( ; ptr < ptrLimit; ptr++ )
                    {
                        *ptr = value;
                    }
                }
            }
        }

        /// <summary>
        /// Copies values from passed array of values. 
        /// </summary>
        /// 
        /// <param name="copyingValues">Values to be copied.</param>
        /// 
        /// <remarks><para>The method copies values from the specified array to the vector. If the
        /// source array has less number of elements, then only that amount is copied and the rest
        /// of vector's elements are kept uninitialized. If the source array has greater number of
        /// elements, then only portion of elements is copied, which equals to then number of elements
        /// in the vector.</para></remarks>
        /// 
        public void CopyFrom( double[] copyingValues )
        {
            Array.Copy( copyingValues, 0, values, 0, System.Math.Min( values.Length, copyingValues.Length ) );
        }

        /// <summary>
        /// Multiply all elements of the vector by the specified factor.
        /// </summary>
        /// 
        /// <param name="factor">Factor to multiply vector element's by.</param>
        /// 
        /// <remarks><para>The method updates the vector by multiplying all elements by the
        /// specified factor.</para></remarks>
        /// 
        public void MultiplyElements( double factor )
        {
            unsafe
            {
                fixed ( double* tptr = values )
                {
                    double* ptr = tptr;
                    double* ptrLimit = ptr + values.Length;

                    for ( ; ptr < ptrLimit; ptr++ )
                    {
                        *ptr *= factor;
                    }
                }
            }
        }

        /// <summary>
        /// Add specified value to all elements of the vector.
        /// </summary>
        /// 
        /// <param name="value">Value to add to all elements of the vector.</param>
        /// 
        /// <remarks><para>The method updates the vector by adding specified value to all
        /// its elements.</para></remarks>
        ///  
        public void AddToElements( double value )
        {
            unsafe
            {
                fixed ( double* tptr = values )
                {
                    double* ptr = tptr;
                    double* ptrLimit = ptr + values.Length;

                    for ( ; ptr < ptrLimit; ptr++ )
                    {
                        *ptr += value;
                    }
                }
            }
        }

        /// <summary>
        /// Calculate mean value of the vector.
        /// </summary>
        /// 
        /// <returns>Returns mean value of the vector or <see cref="double.NaN"/> if vector's
        /// length equals to zero.</returns>
        /// 
        public double GetMean( )
        {
            if ( values.Length == 0 )
                return double.NaN;

            double sum = 0;

            for ( int i = 0, n = values.Length; i < n; i++ )
            {
                sum += values[i];
            }

            return sum / values.Length;
        }

        /// <summary>
        /// Calculate standard deviation of the vector.
        /// </summary>
        /// 
        /// <returns>Returns standard deviation value of the vector or <see cref="double.NaN"/> if vector's
        /// length equals to zero.</returns>
        /// 
        public double GetStdDev( )
        {
            double sum  = 0;
            double sum2 = 0;
            double value;

            for ( int i = 0, n = values.Length; i < n; i++ )
            {
                value = values[i];
                sum  += value;
                sum2 += value * value;
            }

            // mean
            double mean = sum / values.Length;
            // std.dev.
            return Math.Sqrt( sum2 / values.Length - mean * mean );
        }

        /// <summary>
        /// Check if two vectors are equal by comparing their elements.
        /// </summary>
        /// 
        /// <param name="vector">Vector to check equality with.</param>
        /// 
        /// <returns>Returns <see langword="true"/> if two vectors are equal, otherwise
        /// <see langword="false"/>.</returns>
        /// 
        /// <remarks><para><note>If difference between elements of two vectors is not
        /// greater than <see cref="double.Epsilon"/>, then these elements are treated
        /// as equal.</note></para></remarks>
        /// 
        public override bool Equals( object vector )
        {
            DoubleVector secondVector = (DoubleVector) vector;

            // if references are equal, then value will be equal as well
            if ( values.Equals( secondVector.values ) )
                return true;

            // vectors of different length are not equal
            if ( values.Length != secondVector.Length )
                return false;

            double[] secondVectorValues = secondVector.values;

            // compare all values
            for ( int i = 0, n = values.Length; i < n; i++ )
            {
                if ( System.Math.Abs( values[i] - secondVectorValues[i] ) >= double.Epsilon )
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Overrides <see cref="object.GetHashCode()"/>.
        /// </summary>
        /// 
        /// <returns>Returns result of <see cref="object.GetHashCode()"/>.</returns>
        /// 
        public override int GetHashCode( )
        {
            return base.GetHashCode( );
        }

        /// <summary>
        /// Export vector to file.
        /// </summary>
        /// 
        /// <param name="fileName">File's name to export vector to.</param>
        /// 
        /// <remarks><para>The method exports the vector to a file separating each value with a new line, which
        /// makes compatible with CSV file format.</para></remarks>
        /// 
        public void Export( string fileName )
        {
            TextWriter writer = new StreamWriter( fileName );

            for ( int i = 0, n = values.Length; i < n; i++ )
            {
                writer.WriteLine( values[i].ToString( ) );
            }

            writer.Close( );
        }
    }
}
