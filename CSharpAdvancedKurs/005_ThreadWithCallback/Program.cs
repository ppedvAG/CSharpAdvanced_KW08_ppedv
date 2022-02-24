using System;
using System.Threading;

namespace _005_ThreadWithCallback
{

    public delegate void ExampleCallbackDelegate(MyReturnObject myReturnObject);

    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState threadWithState = 
                new ThreadWithState("Hallo liebe Teilnehmer", 111, new ExampleCallbackDelegate(ResultCallback));

         

            Thread t = new Thread(new ThreadStart(threadWithState.ThreadProc)); 
            t.Start();

            t.Join();

            Console.WriteLine("Unabhängiger Thread ist jetzt mit seiner Arbeit fertig geworden");

            Console.ReadLine();
        }

        public static void ResultCallback(MyReturnObject myReturnObject)
        {
            Console.WriteLine($"Rückgabewerte -> {myReturnObject.Text} und {myReturnObject.Zahl}");
        }
    }

    public class ThreadWithState
    {
        private string myStringText;
        private int myNumberValue;
        private ExampleCallbackDelegate callback; //Achtung hier wird eine Methode mitgeführt!

        //ctor + tab + tab
        public ThreadWithState(string text, int zahl, ExampleCallbackDelegate callbackDelegate)
        {
            myStringText = text;
            myNumberValue = zahl;
            callback = callbackDelegate;
        }

        public void ThreadProc()
        {
            //Mach etwas Rechenintensives

            //Rückgabe-Object bauen wir zusammen
            MyReturnObject myReturnObject = new MyReturnObject(); 
            myReturnObject.Text = myStringText;
            myReturnObject.Zahl = myNumberValue;

            //Rückgabe wird mit Callback gesendet
            if (callback != null)
                callback(myReturnObject); // Program->public static void ResultCallback(MyReturnObject myReturnObject)
        }

    }


   
    
    public class MyReturnObject
    {
        public MyReturnObject()
        {
        }

        public string Text { get; set; }    
        public int Zahl { get; set; }   
    }
}
