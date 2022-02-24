using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_ContinueSample
{
    internal class Program
    {
        private static int[] Lottozahlen = new int[7];

        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Lottozahlen[0] = 2;
                Lottozahlen[1] = 12;
                Lottozahlen[2] = 22;
                Lottozahlen[3] = 32;
                Lottozahlen[4] = 42;
                Lottozahlen[5] = 52;
                Lottozahlen[6] = 62;


                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(1000);

                throw new Exception();
            });

            t1.Start();

            //Continue With beinhaltet ein wait...also wir warten bis Task 1 fertig ist
            t1.ContinueWith(t => AllgemeinerFolgetask()); //Wird immer ausgefürt
            t1.ContinueWith(t1 => FolgetaskeiFehler(), TaskContinuationOptions.OnlyOnFaulted);
            t1.ContinueWith(t1 => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.ReadLine();
        }

        private static void AllgemeinerFolgetask()
        {
            Console.WriteLine("Allgemeiner Folgetask");
        }

        private static void FolgetaskeiFehler()
        {
            Console.WriteLine("FolgetaskeiFehler");
            Lottozahlen = new int[6];
        }

        private static void FolgetaskBeiErfolg()
        {
            Console.WriteLine("FolgetaskBeiErfolg");
        }
    }
}
