using System;
using System.Threading;

// C# program to illustrate the
// concept of Abort(object)

namespace _003a_ThreadBeenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating object of ExThread
            ExThread obj = new ExThread("Thread ");
            Thread.Sleep(1000);
            Console.WriteLine("Stop thread");
            obj.thr.Abort(100);

            // Waiting for a thread to terminate.
            obj.thr.Join();
            Console.WriteLine("Main thread is terminating");
        }
    }

    class ExThread
    {

        public Thread thr;

        public ExThread(string name)
        {
            thr = new Thread(this.RunThread);
            thr.Name = name;
            thr.Start();
        }

        // Enetring point for thread
        void RunThread()
        {
            try
            {
                Console.WriteLine(thr.Name +
                            " is starting.");

                for (int j = 1; j <= 100; j++)
                {
                    Console.Write(j + " ");
                    if ((j % 10) == 0) //ISt es durch 10 Teilbar 
                    {
                        Console.WriteLine();
                        Thread.Sleep(200);
                    }
                }
                Console.WriteLine(thr.Name +
                      " exiting normally.");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Thread is aborted and the code is "
                                                 + ex.ExceptionState);
            }
        }
    }
}
