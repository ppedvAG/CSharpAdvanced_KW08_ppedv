
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _008_Task_WhenAllSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> taskCollection = new List<Task<int>>();


            for (int counter = 1; counter <= 10; counter++)
            {
                //Initialisierung desd Parameters
                int baseValue = counter;

                //taskCollection.Add(Task.Factory.StartNew(b => (int)b * (int)b, baseValue));
                taskCollection.Add(Task.Factory.StartNew(GetSquareValue, baseValue));
            }


            //taskCollection hat 10 Task -> jeweils task.Result und liest das aus
            // Da ich 10 interger-Werte auslesen, erhalte ich mit der Methode WhenAll alle Ergebnis aus den Tasks.Results in ein Integer-Array
            Task<int[]> taskResults = Task.WhenAll(taskCollection);
            //1,2,4,9,16,25....
            int[] results = taskResults.Result;

            int sum = 0;

            for (int counter = 0; counter <= results.Length - 1; counter++)
            {
                var result = results[counter];

                Console.Write($"{result}{((counter == results.Length - 1) ? "=" : "+")}");
                sum += result;
            }
            Console.WriteLine(sum);


            Console.ReadLine();

        }

        public static int GetSquareValue(object baseValue)
                => (int)baseValue * (int)baseValue; //return baseValue * baseValue

    }
}
