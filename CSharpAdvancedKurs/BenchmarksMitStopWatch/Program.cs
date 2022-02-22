using System;
using System.Diagnostics;

namespace BenchmarksMitStopWatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                //rechenintensives was gemessen werden muss
            }
            stopwatch.Stop();


            //Ergebniszeit 
            long millisekundenResult = stopwatch.ElapsedMilliseconds;

            Console.WriteLine(millisekundenResult);
        }
    }
}
