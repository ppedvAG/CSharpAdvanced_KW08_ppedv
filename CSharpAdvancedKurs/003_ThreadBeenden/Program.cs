using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwas);
            thread.Start();

            Thread.Sleep(3000);
            thread.Interrupt();

            Console.WriteLine("Main-Methode fertig");
            Console.ReadLine();
        }


        //Diese Methode benötigt 10 Sekunden.
        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i <50;i++)
                {
                    Console.WriteLine("zzzzZZZZZzzzzZZZZzzzzzZZZZ");
                    Thread.Sleep(200); //0,2 Sek pro Loop Interval warten 
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
