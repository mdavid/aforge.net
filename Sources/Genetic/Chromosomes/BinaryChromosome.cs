// AForge Genetic Library
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2006-2009
// andrew.kirillov@aforgenet.com
//

namespace AForge.Genetic
{
    using System;

    /// <summary>
    /// Binary chromosome, which supports length from 2 till 64.
    /// </summary>
    /// 
    /// <remarks><para>The binary chromosome is the simplest type of chromosomes,
    /// which is represented by a set of bits. Maximum number of bits comprising
    /// the chromosome is 64.</para></remarks>
    /// 
    public class BinaryChromosome : IChromosome
    {
        /// <summary>
        /// Chromosome's length in bits.
        /// </summary>
        protected int length;

        /// <summary>
        /// Numerical chromosome's value.
        /// </summary>
        protected ulong val = 0;

        /// <summary>
        /// Chromosome's fintess value.
        /// </summary>
        protected double fitness = 0;

        /// <summary>
        /// Random number generator for chromosoms generation, crossover, mutation, etc.
        /// </summary>
        protected static Random rand = new Random( );

        /// <summary>
        /// Chromosome's maximum length.
        /// </summary>
        /// 
        /// <remarks><para>Maxim chromosome's length in bits, which is supported
        /// by the class</para></remarks>
        /// 
        public const int MaxLength = 64;

        /// <summary>
        /// Chromosome's length.
        /// </summary>
        /// 
        /// <remarks><para>Length of the chromosome in bits.</para></remarks>
        /// 
        public int Length
        {
            get { return length; }
        }

        /// <summary>
        /// Chromosome's value.
        /// </summary>
        /// 
        /// <remarks><para>Current numerical value of the chromosome.</para></remarks>
        /// 
        public ulong Value
        {
            get { return val & ( 0xFFFFFFFFFFFFFFFF >> ( 64 - length ) ); }
        }

        /// <summary>
        /// Max possible chromosome's value.
        /// </summary>
        /// 
        /// <remarks><para>Maximum possible numerical value, which may be represented
        /// by the chromosome of current length.</para></remarks>
        /// 
        public ulong MaxValue
        {
            get { return 0xFFFFFFFFFFFFFFFF >> ( 64 - length ); }
        }

        /// <summary>
        /// Chromosome's fintess value.
        /// </summary>
        /// 
        /// <remarks><para>Fitness value (usefulness) of the chromosome calculate by calling
        /// <see cref="Evaluate"/> method. The greater the value, the more useful the chromosome.
        /// </para></remarks>
        /// 
        public double Fitness
        {
            get { return fitness; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryChromosome"/> class.
        /// </summary>
        /// 
        /// <param name="length">Chromosome's length in bits, [2, <see cref="MaxLength"/>].</param>
        /// 
        public BinaryChromosome( int length )
        {
            this.length = Math.Max( 2, Math.Min( MaxLength, length ) );
            // randomize the chromosome
            Generate( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryChromosome"/> class.
        /// </summary>
        /// 
        /// <param name="source">Source chromosome to copy.</param>
        /// 
        /// <remarks><para>This is a copy constructor, which creates the exact copy
        /// of specified chromosome.</para></remarks>
        /// 
        protected BinaryChromosome( BinaryChromosome source )
        {
            length  = source.length;
            val     = source.val;
            fitness = source.fitness;
        }

        /// <summary>
        /// Get string representation of the chromosome.
        /// </summary>
        /// 
        /// <returns>Returns string representation of the chromosome.</returns>
        /// 
        public override string ToString( )
        {
            ulong	tval = val;
            char[]	chars = new char[length];

            for ( int i = length - 1; i >= 0; i-- )
            {
                chars[i] = (char) ( ( tval & 1 ) + '0' );
                tval >>= 1;
            }

            // return the result string
            return new string( chars );
        }

        /// <summary>
        /// Compare two chromosomes.
        /// </summary>
        /// 
        /// <param name="o">Binary chromosome to compare to.</param>
        /// 
        /// <returns>Returns comparison result, which equals to 0 if fitness values
        /// of both chromosomes are equal, 1 if fitness value of this chromosome
        /// is less than fitness value of the specified chromosome, -1 otherwise.</returns>
        /// 
        public int CompareTo( object o )
        {
            double f = ( (BinaryChromosome) o ).fitness;

            return ( fitness == f ) ? 0 : ( fitness < f ) ? 1 : -1;
        }

        /// <summary>
        /// Generate random chromosome value.
        /// </summary>
        /// 
        /// <remarks><para>Regenerates chromosome's value using random number generator.</para>
        /// </remarks>
        /// 
        public virtual void Generate( )
        {
            byte[] bytes = new byte[8];

            // generate value
            rand.NextBytes( bytes );
            val = BitConverter.ToUInt64( bytes, 0 );
        }

        /// <summary>
        /// Create new random chromosome with same parameters (factory method).
        /// </summary>
        /// 
        /// <remarks><para>The method creates new chromosome of the same type, but randomly
        /// initialized. The method is useful as factory method for those classes, which work
        /// with chromosome's interface, but not with particular chromosome type.</para></remarks>
        /// 
        public virtual IChromosome CreateNew( )
        {
            return new BinaryChromosome( length );
        }

        /// <summary>
        /// Clone the chromosome.
        /// </summary>
        /// 
        /// <returns>Return's clone of the chromosome.</returns>
        /// 
        /// <remarks><para>The method clones the chromosome returning the exact copy of it.</para>
        /// </remarks>
        ///
        public virtual IChromosome Clone( )
        {
            return new BinaryChromosome( this );
        }

        /// <summary>
        /// Mutation operator.
        /// </summary>
        /// 
        /// <remarks><para>The method performs chromosome's mutation, changing randomly
        /// one of its bits.</para></remarks>
        /// 
        public virtual void Mutate( )
        {
            val ^= ( (ulong) 1 << rand.Next( length ) );
        }

        /// <summary>
        /// Crossover operator.
        /// </summary>
        /// 
        /// <param name="pair">Pair chromosome to crossover with.</param>
        /// 
        /// <remarks><para>The method performs crossover between two chromosomes – interchanging
        /// range of bits between these chromosomes.</para></remarks>
        ///
        public virtual void Crossover( IChromosome pair )
        {
            BinaryChromosome p = (BinaryChromosome) pair;

            // check for correct pair
            if ( ( p != null ) && ( p.length == length ) )
            {
                int		crossOverPoint = 63 - rand.Next( length - 1 );
                ulong	mask1 = 0xFFFFFFFFFFFFFFFF >> crossOverPoint;
                ulong	mask2 = ~mask1;

                ulong	v1 = val;
                ulong	v2 = p.val;

                // calculate new values
                val   = ( v1 & mask1 ) | ( v2 & mask2 );
                p.val = ( v2 & mask1 ) | ( v1 & mask2 );
            }
        }

        /// <summary>
        /// Evaluate chromosome with specified fitness function.
        /// </summary>
        /// 
        /// <param name="function">Fitness function to use for evaluation of the chromosome.</param>
        /// 
        /// <remarks><para>Calculates chromosome's fitness using the specifed fitness function.</para></remarks>
        ///
        public void Evaluate( IFitnessFunction function )
        {
            fitness = function.Evaluate( this );
        }
    }
}
