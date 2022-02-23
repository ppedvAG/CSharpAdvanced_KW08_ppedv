using System;

namespace EventAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Beispiel 1
            BusinessLogicComponentA businessLogicComponentA = new BusinessLogicComponentA();
            
            
            businessLogicComponentA.ChangedPercentValue += BusinessLogicComponentA_ChangedPercentValue;

            //Funktionszeiger von BusinessLogicComponentA_ResultCompletedDelegate wird übergeben 
            businessLogicComponentA.ResultCompletedDelegate += BusinessLogicComponentA_ResultCompletedDelegate;
            businessLogicComponentA.StartProcess();


            //Beispiel 2
            BusinessLogicComponentB businessLogicComponentB = new BusinessLogicComponentB();
            businessLogicComponentB.PercentValueChanged += BusinessLogicComponentB_PercentValueChanged;
            businessLogicComponentB.ProcessComplet += BusinessLogicComponentB_ProcessComplet;
            businessLogicComponentB.StartProcess();
            Console.ReadLine();
        }

        private static void BusinessLogicComponentB_ProcessComplet(object sender, EventArgs e)
        {
            Console.WriteLine("ProcessStart ist fertig");
        }

        private static void BusinessLogicComponentB_PercentValueChanged(object sender, EventArgs e)
        {
            MyPercentEventArgs myPercent = (MyPercentEventArgs)e;
            Console.WriteLine(myPercent.PercentValue);
            //Prozente werden ausgegeben  (0..100)
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
