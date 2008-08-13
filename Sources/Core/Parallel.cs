// AForge Core Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge
{
    using System;
    using System.Threading;

    /// <summary>
    /// The class provides support for parallel computations, paralleling loop's iterations.
    /// </summary>
    /// 
    /// <remarks><para>The class allows to parallel loop's iteration computing them in separate threads,
    /// what allows their simultaneous execution on multiple CPUs/cores.
    /// </para></remarks>
    ///
    public class Parallel
    {
        /// <summary>
        /// Delegate defining for-loop's body.
        /// </summary>
        /// 
        /// <param name="index">Loop's index.</param>
        /// 
        public delegate void ForLoopBody( int index );

        // number of threads for parallel computations
        private static int threadsCount = System.Environment.ProcessorCount;
        // mutex to synchronize access to public methods/properties
        private static Mutex mutex = new Mutex( );

        // single instance of the class to implement singleton pattern
        private static Parallel instance = null;
        // background threads for parallel computation
        private Thread[] threads = null;

        // events to signal about job availability and thread availability
        private AutoResetEvent[] jobAvailable = null;
        private AutoResetEvent[] threadAvailable = null;
        private WaitHandle[] waitHandles = null;

        // loop bodies and start/stop indexes
        private int[] startIndex;
        private int[] stopIndex;
        private ForLoopBody[] loopBodies;

        /// <summary>
        /// Number of threads used for parallel computations.
        /// </summary>
        /// 
        /// <remarks><para>The property sets how many worker threads are created for paralleling
        /// loops' computations.</para>
        /// 
        /// <para>By default the property is set to number of CPU's in the system
        /// (see <see cref="System.Environment.ProcessorCount"/>).</para>
        /// </remarks>
        /// 
        public static int ThreadsCount
        {
            get { return threadsCount; }
            set
            {
                mutex.WaitOne( );
                threadsCount = Math.Max( 1, value );
                mutex.ReleaseMutex( );
            }
        }

        /// <summary>
        /// Executes a for-loop in which iterations may run in parallel. 
        /// </summary>
        /// 
        /// <param name="start">Loop's start index.</param>
        /// <param name="stop">Loop's stop index.</param>
        /// <param name="loopBody">Loop's body.</param>
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
        public static void For( int start, int stop, ForLoopBody loopBody  )
        {
            mutex.WaitOne( );

            // get instance of parallel computation manager
            Parallel parallelManager = Instance;

            int iterationsLeft = stop - start;
            int jobStart = start;
            int jobStop  = 0;

            for ( int t = threadsCount; t > 0; t-- )
            {
                int iterationsForTheThread = iterationsLeft / t;
                jobStop = jobStart + iterationsForTheThread;

                parallelManager.AddJob( jobStart, jobStop, loopBody );

                jobStart = jobStop;
                iterationsLeft -= iterationsForTheThread;
            }

            parallelManager.WaitAllToBeFree( );

            mutex.ReleaseMutex( );
        }

        /// <summary>
        /// Clean-up resources used by Parallel class instance.
        /// </summary>
        /// 
        /// <remarks><para>All applications, which use Parallel class for parallel computations,
        /// should call this method. The method terminates all worker threads used for parallel
        /// computations and frees all resources used for synchronization.</para>
        /// 
        /// <para><note>Application's main thread will not exit (application will not terminate),
        /// if this method is not called after using Parallel class's services.</note></para>
        /// </remarks>
        /// 
        public static void Cleanup( )
        {
            // !!! TODO !!!
            // work on solution, which does not require from user to call this method
            // clean-up should be done automatically


            mutex.WaitOne( );

            if ( instance != null )
            {
                instance.Terminate( );
                instance = null;
            }

            mutex.ReleaseMutex( );
        }

        // Private constructor to avoid class instantiation
        private Parallel( ) { }

        // Get instace of the Parallel class
        private static Parallel Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new Parallel( );
                    instance.Initialize( );
                }
                else
                {
                    if ( instance.threads.Length != threadsCount )
                    {
                        // terminate old threads
                        instance.Terminate( );
                        // reinitialize
                        instance.Initialize( );

                        // TODO: change reinitialization to reuse already created objects
                    }
                }
                return instance;
            }
        }

        // Wait until all treads become free
        private void WaitAllToBeFree( )
        {
            for ( int i = 0; i < threadsCount; i++ )
            {
                threadAvailable[i].WaitOne( -1, false );
                threadAvailable[i].Set( );
            }
        }

        // Initialize Parallel class's instance creating required number of threads
        // and synchronization objects
        private void Initialize( )
        {
            // array of events, which signal about available job
            jobAvailable = new AutoResetEvent[threadsCount];
            // array of events, which signal about available thread
            threadAvailable = new AutoResetEvent[threadsCount];
            // array of threads
            threads = new Thread[threadsCount];
            // set of handles to wait for first available thread
            waitHandles = new WaitHandle[threadsCount];

            // loops' start and stop indexes
            startIndex = new int[threadsCount];
            stopIndex  = new int[threadsCount];
            // loops' bodies
            loopBodies = new ForLoopBody[threadsCount];

            for ( int i = 0; i < threadsCount; i++ )
            {
                jobAvailable[i]    = new AutoResetEvent( false );
                threadAvailable[i] = new AutoResetEvent( true );
                waitHandles[i]     = threadAvailable[i];

                threads[i] = new Thread( new ParameterizedThreadStart( WorkerThread ) );
                threads[i].Start( i );
            }
        }

        // Terminate all worker threads used for parallel computations and close all
        // synchronization objects
        private void Terminate( )
        {
            for ( int i = 0; i < threadsCount; i++ )
            {
                // finish thread by setting null loop body and signaling about available work
                loopBodies[i] = null;
                jobAvailable[i].Set( );
                // wait for thread termination
                threads[i].Join( );

                // close events
                jobAvailable[i].Close( );
                threadAvailable[i].Close( );
            }

            // clean all array references
            jobAvailable    = null;
            threadAvailable = null;
            threads         = null;
            waitHandles     = null;
            startIndex      = null;
            stopIndex       = null;
            loopBodies      = null;
        }

        // Added parallel job for the first available worker thread
        private void AddJob( int start, int stop, ForLoopBody body )
        {
            // get first available thread
            int availableThread = WaitHandle.WaitAny( waitHandles, Timeout.Infinite, false );
            // set start and stop indexed for the loop
            startIndex[availableThread] = start;
            stopIndex[availableThread]  = stop;
            // set loop's body
            loopBodies[availableThread] = body;

            // signal thread about available job
            jobAvailable[availableThread].Set( );
        }

        // Worker thread performing parallel computations in loop
        private void WorkerThread( object index )
        {
            int threadIndex = (int) index;

            while ( true )
            {
                // wait until there is job to do
                jobAvailable[threadIndex].WaitOne( );

                // get loop's body
                ForLoopBody body = loopBodies[threadIndex];
                // exit on null body
                if ( body == null )
                    break;

                // get start/stop indexes for the loop
                int start = startIndex[threadIndex];
                int stop  = stopIndex[threadIndex];

                for ( int i = start; i < stop; i++ )
                {
                    body( i );
                }

                // signal about thread availability
                threadAvailable[threadIndex].Set( );
            }
        }
    }
}
