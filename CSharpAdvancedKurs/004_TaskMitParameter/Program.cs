using System;
using System.Text;
using System.Threading.Tasks;

namespace _004_TaskMitParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();

            Task<string> task = new Task<string>(MachEtwas, katze);
            task.Start();
            task.Wait();
            Console.WriteLine(task.Result);

            Task<string> taskA = new Task<string>(() => MachEtwas(katze));
            taskA.Start();
            taskA.Wait();


            //Via Factory
            Task<string> task2 = Task.Factory.StartNew(MachEtwas, katze);
            task2.Wait();
            Console.WriteLine(task2.Result);

            //Task.Run
            Task<string> task3 = Task.Run( ()=> MachEtwas(katze));
            task.Wait();
            string result = task.Result;
        }

        private static string MachEtwas(object input)
        {
            if (input is Katze myCat)
            {
                return myCat.Name; //Name wird zurückgegeen
            }

            throw new ArgumentException();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
