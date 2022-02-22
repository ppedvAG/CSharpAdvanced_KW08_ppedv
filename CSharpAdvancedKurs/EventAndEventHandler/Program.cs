using System;

namespace EventAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessLogicComponentA businessLogicComponentA = new BusinessLogicComponentA();
            businessLogicComponentA.ChangedPercentValue += BusinessLogicComponentA_ChangedPercentValue;

            //Funktionszeiger von BusinessLogicComponentA_ResultCompletedDelegate wird übergeben 
            businessLogicComponentA.ResultCompletedDelegate += BusinessLogicComponentA_ResultCompletedDelegate;
            businessLogicComponentA.StartProcess();

            Console.ReadLine();
        }

        private static void BusinessLogicComponentA_ResultCompletedDelegate(string msg)
        {
            Console.WriteLine(msg);
        }



        //komme von  protected virtual void OnProcessPercentStatus(int percent)
        private static void BusinessLogicComponentA_ChangedPercentValue(int perventValue)
        {
            Console.WriteLine(perventValue);
        }
    }
}
