using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Task_Beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ab 4.0
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            try
            {
                Task task = new Task(MeineMethodeMitAbbrechen, token);
                task.Start();

                Thread.Sleep(5000);
                cts.Cancel();
            }
            catch (OperationCanceledException e) //OperationCanceledException wird geworfen, wenn ein Task beendet wird
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadLine();
        }

        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationToken cancellationToken = (CancellationToken)param;

            while(true)
            {
                Console.WriteLine("zzzzZZZZzzzZZZzzZZ");
                Thread.Sleep(50);


                //Wurde  cts.Cancel(); aufgerufen? 
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested(); //Best Practice
                }

            }
        }
    }
}
