using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AForge
{
    /// <summary>
    /// The class provides support for parallel computations, paralleling loop's iterations.
    /// </summary>
    /// 
    /// <remarks><para>The class allows to parallel loop's iteration computing them in separate threads,
    /// what allows their simultaneous execution on multiple CPUs/cores.
    /// </para></remarks>
    ///
    public static class AlternateParallel
    {
        #region PrivateVars

        // default chunk size
        // 

        // TODO: Create a method that adjusts chunkSize according to loop´s index count
        private static int _defaultChunkSize = 4;

        #endregion


        #region PublicVars

        /// <summary>
        /// Gets the default chunk size.
        /// </summary>
        /// 
        /// 
        public static int defaultChunkSize
        {
            get
            {
                return _defaultChunkSize;
            }

        }

        #endregion


        /// <summary>
        /// Delegate defining for-loop's body.
        /// </summary>
        /// 
        /// <param name="i">Loop's index.</param>
        /// 
        public delegate void ForDelegate(int i);

        /// <summary>
        /// Delegate defining worker thread.
        /// </summary>
        /// 
        public delegate void ThreadDelegate();


        /// <summary>
        /// Executes a for-loop in which iterations may run in parallel. 
        /// </summary>
        /// 
        /// <param name="fromInclusive">Loop's start index.</param>
        /// <param name="toExclusive">Loop's stop index.</param>
        /// <param name="chunkSize">Number of indexes to process together in a thread </param>
        /// <param name="action">Loop's body.</param>
        /// 
        /// 
        /// <remarks><para>The method is used to parallel for-loop running its iterations in
        /// different threads. The <b>start</b> and <b>stop</b> parameters define loop's
        /// starting and ending loop's indexes. The number of iterations is equal to <b>stop - start</b>.
        /// </para>
        /// 
        /// <para>Sample usage:</para>
        /// <code>
        /// Parallel.For( 0, 20,4, delegate( int i )
        /// // which is equivalent to
        /// // for ( int i = 0; i &lt; 20; i++ )
        /// {
        ///     System.Diagnostics.Debug.WriteLine( "Iteration: " + i );
        ///     // ...
        /// } );
        /// </code>
        /// </remarks>
        /// 
        public static void For(int fromInclusive, int toExclusive, int chunkSize, ForDelegate action)
        {

            //Amount of indexes to process at a time
            int _chunkSize = chunkSize;

            if (_chunkSize == 0)
                _chunkSize = 1;

            if (_chunkSize < 0)
                throw new ArgumentOutOfRangeException("chunkSize", "The argument \"chunkSize\" should be greater than zero");


            // number of process() threads
            // default is set to the number of processors
            int threadCount = Environment.ProcessorCount;

            // global index
            int globalCount = fromInclusive - _chunkSize;




            // delegate worker
            // takes next chunk and process it
            #region Delegate Worker
            ThreadDelegate process = delegate()
            {

                while (true)
                {

                    // Sum chunkSize to globalCount and stores the value to localCount
                    // Using Interlocked to access shared resource
                    int localCount = Interlocked.Add(ref globalCount, _chunkSize);


                    // process chunk

                    // here items can come out of order if chunkSize > 1

                    for (int i = localCount; i < localCount + _chunkSize; ++i)
                    {

                        if (i >= toExclusive) return;

                        action(i);

                    }

                }

            };

            #endregion


            // launch process() threads
            // Here we let the system scheduler do the work balance

            IAsyncResult[] asyncResults = new IAsyncResult[threadCount];

            for (int i = 0; i < threadCount; ++i)
                asyncResults[i] = process.BeginInvoke(null, null);


            // wait for all threads to complete

            for (int i = 0; i < threadCount; ++i)
                process.EndInvoke(asyncResults[i]);


        }

        /// <summary>
        /// Executes a for-loop in which iterations may run in parallel. 
        /// </summary>
        /// 
        /// <param name="fromInclusive">Loop's start index.</param>
        /// <param name="toExclusive">Loop's stop index.</param>
        /// <param name="action">Loop's body.</param>
        /// 
        /// 
        /// <remarks><para>The method is used to parallel for-loop running its iterations in
        /// different threads. The <b>start</b> and <b>stop</b> parameters define loop's
        /// starting and ending loop's indexes. The number of iterations is equal to <b>stop - start</b>.
        /// </para>
        /// 
        /// <para>Sample usage:</para>
        /// <code>
        /// Parallel.For( 0, 20, delegate( int i )
        /// // which is equivalent to
        /// // for ( int i = 0; i &lt; 20; i++ )
        /// {
        ///     System.Diagnostics.Debug.WriteLine( "Iteration: " + i );
        ///     // ...
        /// } );
        /// </code>
        /// </remarks>
        /// 
        public static void For(int fromInclusive, int toExclusive, ForDelegate action)
        {
            For(fromInclusive, toExclusive, _defaultChunkSize, action);

        }
    }
}
