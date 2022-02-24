using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002a_Task_Beenden
{
    class Program
    {
        static async Task Main()
        {
            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;
            //Task task = new Task(MethodaABC);
            //task.Start();

            Task task = new Task(MeineMethode, ct); // Pass same token to Task.Run.


            await Task.Delay(5000);

            tokenSource2.Cancel();

            // Just continue on this thread, or await with try-catch:
            try
            {
                await task;
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            finally
            {
                tokenSource2.Dispose();
            }

            Console.ReadKey();
        }

        public static void MeineMethode(object param)
        {
            CancellationToken ct = (CancellationToken)param;
            
            //ct.ThrowIfCancellationRequested();

            bool moreToDo = true;
            while (moreToDo)
            {
                Console.WriteLine("zzzZZZZzzz");
                // Poll on this property if you have to do
                // other cleanup before throwing.
                if (ct.IsCancellationRequested)
                {
                    // Clean up here, then...
                    ct.ThrowIfCancellationRequested();
                }
            }
        }
    }
}
