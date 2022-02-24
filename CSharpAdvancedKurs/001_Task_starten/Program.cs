
using System;
using System.Threading.Tasks; //.NET 4.0

namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(MacheEtwasInEinemTread);

            task.Start(); //MacheEtwasInEinemTread wird aufgerufen
            //Und zusätzlich wird die Main Methode parallel weiterlaufen
            
            task.Wait();
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");



            Console.ReadLine();
        }

        private static void MacheEtwasInEinemTread()
        {
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("#");
        }
    }
}
