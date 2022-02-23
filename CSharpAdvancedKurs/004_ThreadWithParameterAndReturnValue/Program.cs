using System;
using System.Threading;

namespace _004_ThreadWithParameterAndReturnValue
{
    internal class Program
    {
        static string retString = string.Empty;
        static string meinText = "Hallo World";

        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                //befinden uns im Thread
                retString = StringToUpper(meinText);
            }); //hier ist Thread fertig
            thread.Start();
            thread.Join(); //Join Bekommt den Callback von der Thread ausgeführten Methode, dass der Thread fertig ist. 

            Console.WriteLine(retString); //HALLO WELT

            Console.ReadLine();
        }

        private static string StringToUpper(string param)
        {
            return param.ToUpper(); 
        }

        private static void MethodeInThread()
        {
            retString = StringToUpper(meinText);
        }
    }
}
