using System;
using System.Threading;

namespace _009_MutexSample
{
    internal class Program
    {
        private static Mutex mutex = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            mutex = new Mutex(false, "MyMutex");

            bool lockToken = false;

            try
            {
                //true
                lockToken = mutex.WaitOne();
            }
            finally
            {
                if (lockToken)
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
