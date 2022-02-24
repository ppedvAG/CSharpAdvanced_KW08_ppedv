using System;
using System.Threading;

namespace _008_MonitorSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //Methode die von mehreren Threads verwendet wird
        static void KritischerCodeAbschnitt()
        {
            int x = 1; //x muss auf 1 gesetzt werden

            if (Monitor.TryEnter(x))
            {
                try
                {
                    //Fehler passiert
                }
                finally
                {
                    //Wird immer aufgerufen 
                    Monitor.Exit(x);
                }
            }
        }
    }

    
}
