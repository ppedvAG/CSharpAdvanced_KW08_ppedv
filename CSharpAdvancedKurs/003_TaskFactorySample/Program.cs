using System;
using System.Threading;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.NET 4.0  -> starten des Tasks erfolgt automatisch 
            Task task = Task.Factory.StartNew(MachEtwasInEinemThread);
            task.Wait();

            //.NET 4.5 - Task.Run dient lediglich als verkürzte Schreibweise.
            Task task2 = Task.Run(MachEtwasInEinemThread);

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
