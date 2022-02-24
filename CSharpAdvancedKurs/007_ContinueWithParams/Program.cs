using System;
using System.Threading.Tasks;

namespace _007_ContinueWithParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(DayTime);

            task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour > 17
                ? "evening"
                : dateTime.Hour > 12
                ? "afternoon"
                : "morning";
        }

        public static void ShowDayTime(string result)
        {
            Console.WriteLine(result);
        }
    }
}
