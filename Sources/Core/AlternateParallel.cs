// AForge Core Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

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
    public sealed class AlternateParallel
    {
        /// <summary>
        /// Delegate defining for-loop's body.
        /// </summary>
        /// 
        /// <param name="index">Loop's index.</param>
        /// 
        public delegate void ForLoopBody(int index);


        // control vars
        private int globalCount;
        private int stopIndex;

        // delegate instance
        private ForLoopBody loopBody;



        // number of threads for parallel computations
        private static int threadsCount = System.Environment.ProcessorCount;

        // single instance of the class to implement singleton pattern
        private static volatile AlternateParallel instance = null;
        private static object syncRoot = new Object();


        // background threads for parallel computation
        private static Thread[] threads = null;

       
        // events to signal about job availability and thread availability
        private AutoResetEvent[] jobAvailable = null;

        private ManualResetEvent[] threadIdle = null;

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
                // thread-safe set value
                Interlocked.Exchange(ref threadsCount, Math.Max(1, value));

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
        public static void For(int start, int stop, ForLoopBody loopBody)
        {

            // get instance of parallel computation manager
            AlternateParallel parallelManager = Instance;

            parallelManager.stopIndex = stop;
            Interlocked.Exchange(ref parallelManager.globalCount, start - 1);           
            parallelManager.loopBody = loopBody;
            

            // Sign that the queue received new items
            CallThreads();

            // Wait from threads sign idle
            WaitAllToBeFree();


        }

        // Private constructor to avoid class instantiation
        private AlternateParallel() { }

        // Get instace of the Parallel class
        private static AlternateParallel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AlternateParallel();
                            instance.Initialize();
                        }

                    }
                }
                else
                {
                    if (threads.Length != threadsCount)
                    {
                        // terminate old threads
                        instance.Terminate();
                        // reinitialize
                        instance.Initialize();

                        // TODO: change reinitialization to reuse already created objects
                    }
                }
                return instance;
            }
        }

        // Wake threads
        private static void CallThreads()
        {
            for (int i = 0; i < threadsCount; i++)
            {
                instance.threadIdle[i].Reset();
                instance.jobAvailable[i].Set();
            }




        }

        // Wait until all treads become free
        private static void WaitAllToBeFree()
        {
            // wait for empty queue
            //instance.jobFinished.WaitOne();

            // wait for all threads sign finished
            for (int i = 0; i < threadsCount; i++)
            {
                instance.threadIdle[i].WaitOne();
            }
        }

        // Initialize Parallel class's instance creating required number of threads
        // and synchronization objects
        private void Initialize()
        {
            // array of events, which signal about available job
            jobAvailable = new AutoResetEvent[threadsCount];
            // array of events, which signal about available thread
            threadIdle = new ManualResetEvent[threadsCount];


            // array of threads
            threads = new Thread[threadsCount];

            
            // event which signal about arrivals in queue
            jobAvailable = new AutoResetEvent[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {

                threadIdle[i] = new ManualResetEvent(false);
                jobAvailable[i] = new AutoResetEvent(false);


                threads[i] = new Thread(new ParameterizedThreadStart(WorkerThread));
                threads[i].IsBackground = true;
                threads[i].Start(i);

            }
        }

        // Terminate all worker threads used for parallel computations and close all
        // synchronization objects
        private void Terminate()
        {
            lock (syncRoot)
            {
                for (int i = 0; i < threadsCount; i++)
                {
                    // finish thread by setting null loop body and signaling about available work
                    //loopBodies[i] = null;
                    jobAvailable[i].Set();
                    // wait for thread termination
                    threads[i].Join();

                    // close events
                    jobAvailable[i].Close();
                    threadIdle[i].Close();
                }

                // clean all array references
                jobAvailable = null;
                threadIdle = null;
                threads = null;
            }

        }



        // Worker thread performing parallel computations in loop
        private void WorkerThread(object index)
        {
            int threadIndex = (int)index;
            int localCount=0;

            while (true)
            {


                // wait until there is job to do
                jobAvailable[threadIndex].WaitOne();
                threadIdle[threadIndex].Reset();


                while (true)
                {

                    // increment global count
                    localCount = Interlocked.Increment(ref globalCount);       
                    
                    //Return to wait state if queue is empty
                    if (localCount >= stopIndex )
                        break;

                    // execute loop body
                    
                    loopBody(localCount);
                
                                     
                    
                }
                // signal about thread availability
                threadIdle[threadIndex].Set();

            }
        }


       

    }


}
