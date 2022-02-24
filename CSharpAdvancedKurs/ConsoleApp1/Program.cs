using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }


        public static async Task DoSomethingAsync()
        {
            SqlConnection conn = new SqlConnection("......");

            Task task = conn.OpenAsync();
            task.Wait(); //Warten bis Task fertig ist

            Task<string> task1 = Task.Run(DayTime);
            task1.Wait();
            string result = task1.Result;

            //await / async

            await conn.OpenAsync();

            string result1 = await Task.Run(DayTime);
            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime date = DateTime.Now;

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }
    }
}
