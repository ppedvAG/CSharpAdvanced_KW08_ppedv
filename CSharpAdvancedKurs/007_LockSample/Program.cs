using System;
using System.Threading;
namespace _007_LockSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart param = null;

            Thread thread = null;

            for (int i=0; i < 500; i++)
            {
                param = new ParameterizedThreadStart(MachEinKontoUpdate);
                thread = new Thread(param);
                thread.Start();
            }

            Console.WriteLine("fertig");
            Console.ReadLine();
        }

        private static void MachEinKontoUpdate( object state)
        {
            Random random = new Random();

            //5000 Transactionen 
            for(int i= 0; i <5000; i++)
            {
                int auswahl = random.Next();
                int betrag = random.Next(0, 1000);

                if (auswahl % 2 == 0)
                    Konto.Abheben(betrag);
                else
                    Konto.Einzahlen(betrag);
            }
        }
    }



    public static class Konto
    {
        public static decimal Kontostand { get; set; } = 0; //Defaultwert ist 0

        public static int TransactionId { get; set; } = 0;

        public static object lockFlag1 = new object();
        public static object lockFlag2 = new object();

        public static void Einzahlen(decimal betrag)
        {


            try
            {
                //Erste Thread darf in lock .... weitere Thread(s) müssen warten 
                lock (lockFlag1)
                {
                    TransactionId++;
                    Kontostand += betrag;

                    Console.WriteLine($"{TransactionId} \t Kontostand nach dem Einzahlen: {Kontostand}");
                }
                
            }
            catch(Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Deadlock juhuuu");
            }
        }

        public static void Abheben(decimal betrag)
        {


            try
            {
                //Erste Thread darf in lock .... weitere Thread(s) müssen warten 
                lock (lockFlag2)
                {
                    TransactionId++;
                    Kontostand -= betrag;

                    Console.WriteLine($"{TransactionId} \t Kontostand nach dem Abheben: {Kontostand}");
                } 

            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Deadlock juhuuu");
            }
        }
    }
}
