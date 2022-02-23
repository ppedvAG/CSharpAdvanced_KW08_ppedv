using System;

using System.Threading; 

namespace _001_ThreadStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwasInEinemThread); //Methode wird in einem Thread zum seperaten ausführen hinterlegt 
            thread.Start(); //Methode MachEtwasInEinemthread wird ausgefürt 

            thread.Join(); //Wir warten, bis der Thread fertig durchgearbeitet wird

            for (int i = 0; i < 100; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("#");
        }


    }
}
