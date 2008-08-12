using System;
using AForge;

namespace ParallelTest
{
    class Program
    {
        static void Main( string[] args )
        {
            int matrixSize = 500;
            int runs = 10;
            int tests = 5;

            // allocate matrixes for all tests
            double[,] a  = new double[matrixSize, matrixSize];
            double[,] b  = new double[matrixSize, matrixSize];
            double[,] c1 = new double[matrixSize, matrixSize];
            double[,] c2 = new double[matrixSize, matrixSize];
            double[,] c3 = new double[matrixSize, matrixSize];

            Random rand = new Random( );

            // fill source matrixes with random numbers
            for ( int i = 0; i < matrixSize; i++ )
            {
                for ( int j = 0; j < matrixSize; j++ )
                {
                    a[i, j] = rand.NextDouble( );
                    b[i, j] = rand.NextDouble( );
                }
            }

            // run specified number of tests
            for ( int test = 0; test < tests; test++ )
            {
                // test 1
                DateTime start = DateTime.Now;

                for ( int run = 0; run < runs; run++ )
                {
                    Test1( a, b, c1 );
                }

                DateTime end = DateTime.Now;
                TimeSpan span = end - start;

                Console.Write( span.TotalMilliseconds + "\t | " );

                // test 2
                start = DateTime.Now;

                for ( int run = 0; run < runs; run++ )
                {
                    Test2( a, b, c2 );
                }

                end = DateTime.Now;
                span = end - start;

                Console.Write( span.TotalMilliseconds + "\t | " );

                Console.WriteLine( " " );
            }

            Console.WriteLine( "Done" );
        }

        private static void Test1( double[,] a, double[,] b, double[,] c )
        {
            int s = a.GetLength( 0 );

            for ( int i = 0; i < s; i++ )
            {
                for ( int j = 0; j < s; j++ )
                {
                    double v = 0;

                    for ( int k = 0; k < s; k++ )
                    {
                        v += a[i, k] * b[k, j];
                    }

                    c[i, j] = v;
                }
            }
        }

        private static void Test2( double[,] a, double[,] b, double[,] c )
        {
            int s = a.GetLength( 0 );

            AForge.Parallel.For( 0, s, delegate( int i )
            {
                for ( int j = 0; j < s; j++ )
                {
                    double v = 0;

                    for ( int k = 0; k < s; k++ )
                    {
                        v += a[i, k] * b[k, j];
                    }

                    c[i, j] = v;
                }
            }
            );
        }
    }
}
