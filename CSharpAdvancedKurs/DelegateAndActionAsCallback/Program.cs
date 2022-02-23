using System;
using System.Threading;

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


            #region UseCase
            MyApp app = new MyApp();


            LoadedFinishDelegate loadedFinishDelegate = new LoadedFinishDelegate(app.ShowUI);

            //Hier werden meine Konfugirationen ausgelesen 
            LoadingProcess(loadedFinishDelegate);

            #endregion




            #region Bespiel Delegate
                ClassWithMethode classWithMethode = new();
            ResultDelegate resultDelegate = new ResultDelegate(classWithMethode.FinishMessage);
            resultDelegate("hallo finish Methode");
            //Von hier könnte man auch die FinishMethode aufrufen, ob es intelligent ist...ist offen :-) 

            ResultDelegate resultDelegate2 = new ResultDelegate(FinishOutputInProgrammCS);
            PercentChangeDelegate percentChangeDelegate = new PercentChangeDelegate(ShowPercent);
            classWithMethode.StartWorkflow(11, 22, resultDelegate2, percentChangeDelegate);

            #endregion

            //Action Callback
            #region Action Delegate
            //Variante, wenn Action-Delage anstatt klassisches Delegate 
            Action<string> actionMessageDelegate = new Action<string>(FinishOutputInProgrammCS);
            Action<int> actionPercentDelegate = new Action<int>(ShowPercent);


            classWithMethode.StartWorkflow(11, 33, actionMessageDelegate, actionPercentDelegate);
            #endregion
        }

        public static void LoadingProcess(LoadedFinishDelegate loadedFinishDelegate)
        {
            Thread.Sleep(5000);
            //Konfigurationen werden ausgelesen

            MySettings mySettings = new ();
            mySettings.ContentPath = "Haribo";
            mySettings.ConnectionString = "localhost.....";

            loadedFinishDelegate(mySettings);
            //Ich will signalsieren, dass ich fertig bin und meine geladenen Werte sollen irgendwo versendbar via Delegate sein 
        }

        public static void FinishOutputInProgrammCS(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void ShowPercent(int percent)
        {
            Console.WriteLine(percent);
        }
    }


    public delegate void LoadedFinishDelegate(MySettings settings);
    public class MySettings
    {
        public string ContentPath { get; set; }
        public string ConnectionString { get; set; }    

    }
    public class MyApp
    {
        public string Name { get; set; }

        public void ShowUI(MySettings mySettings )
        {

        }
    }



    public delegate void ResultDelegate(string msg);
    public delegate void PercentChangeDelegate(int value);
    public class ClassWithMethode
    {
        public void StartWorkflow(int param, int param1, ResultDelegate resultDelegate, PercentChangeDelegate percentDelegate ) //FinishMessage ist dabei
        {
            //komplizierte Logic verarbeitet

            for (int i = 0; i <= 100; i++)
                percentDelegate(i);

            //Ganz am Ende wird ein Callback aufgeruf

           /*  FinishMessage("bin fertig");*/ //-> Direkter Methodenaufruf ist kein Callback

            resultDelegate("Sind fertig! :-) "); //Hier wird FinishMessage aufgerufen 
        }

        public void StartWorkflow(int param1, int param2, Action<string> messageDelegate, Action<int> percentActionDelegate)
        {
            //Call SQLServer 
            //Asynchronität 
            //Threadings

            for (int i = 0; i <= 100; i++)
                ShowPercentValue(i); //ClassWithMethode-> 
            

            for (int i = 0; i <= 100; i++)
                percentActionDelegate(i); //ClassWithMethode-> 

            //Hier muss uns expliziet gesagt werden, wir sind fertig
            //Hier müssen wir mithilfe eines Delegates signalisieren, dass wir mit StartWorkflow fertig sind. 
            messageDelegate("bin fertig");
        }

        public void FinishMessage(string msg)
        {
            Console.WriteLine(msg); //Sind fertig! :-) 
        }

        public void ShowPercentValue(int value)
            => Console.WriteLine(value.ToString());
    }
}
