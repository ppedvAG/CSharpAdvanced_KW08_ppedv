using System;
using System.Threading;

namespace _002_ThreadMitParameterStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(MachEtwasInEinemThread);

            Thread thread = new Thread(parameterized);
            thread.Start(600);


            thread.Join();
            for(int i =0; i < 100; i++)
                Console.WriteLine("*");
        }

        private static void MachEtwasInEinemThread(object obj) //600 wird übergeben als obj
        {
            if (obj is DateTime myDateTime)
            {
                //myDateTime 
            }
            else if (obj is int unitl) //until bekommt den Wert 600
            {
                for(int i = 0; i < unitl; i++)
                    Console.WriteLine(i.ToString() + " #");
            }
        }

    }
}
