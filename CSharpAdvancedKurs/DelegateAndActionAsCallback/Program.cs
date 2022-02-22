using System;

namespace DelegateAndActionAsCallback
{
    //Callback Typische UseCases:
    //Aufruf auf einen anderen PC 
    // - SQLConnection.OpenAsync
    // - HttpClient-GetAsync() 


    public class Program
    {
        static void Main(string[] args)
        {
            ClassWithMethode classWithMethode = new();
            ResultDelegate resultDelegate = new ResultDelegate(classWithMethode.FinishMessage);
            resultDelegate("hallo finish Methode");
            //Von hier könnte man auch die FinishMethode aufrufen, ob es intelligent ist...ist offen :-) 

            ResultDelegate resultDelegate2 = new ResultDelegate(FinishOutputInProgrammCS);
            classWithMethode.StartWorkflow(11, 22, resultDelegate2);



            //Action Callback

            //Variante, wenn Action-Delage anstatt klassisches Delegate 
            Action<string> actionMessageDelegate = new Action<string>(classWithMethode.FinishMessage);
            classWithMethode.StartWorkflow(11, 33, actionMessageDelegate);
        }

        public static void FinishOutputInProgrammCS(string msg)
        {
            Console.WriteLine(msg);
        }
    }



    public delegate void ResultDelegate(string msg);

    public class ClassWithMethode
    {
        public void StartWorkflow(int param, int param1, ResultDelegate resultDelegate ) //FinishMessage ist dabei
        {
            //komplizierte Logic verarbeitet



            //Ganz am Ende wird ein Callback aufgeruf

           /*  FinishMessage("bin fertig");*/ //-> Direkter Methodenaufruf ist kein Callback

            resultDelegate("Sind fertig! :-) "); //Hier wird FinishMessage aufgerufen 
        }

        public void StartWorkflow(int param1, int param2, Action<string> messageDelegate)
        {
            //Call SQLServer 
            //Asynchronität 
            //Threadings

            //Hier muss uns expliziet gesagt werden, wir sind fertig
            //Hier müssen wir mithilfe eines Delegates signalisieren, dass wir mit StartWorkflow fertig sind. 
            messageDelegate("bin fertig");
        }

        public void FinishMessage(string msg)
        {
            Console.WriteLine(msg); //Sind fertig! :-) 
        }
    }
}
