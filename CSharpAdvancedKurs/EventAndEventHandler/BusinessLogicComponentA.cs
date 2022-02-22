using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{

    //Diese "Komponente" ist in der Lage, Zustände nach "außen" zu kommunizieren -> via Event-Methode zb


    public delegate void ChangedPercentValueDelegate(int perventValue);
    public delegate void ResultDelegate(string msg);

    public class BusinessLogicComponentA
    {
        //Diese Struktur bietet das Delegate zum befüllen von aussen an
        //Das Event ChangedPercentValue bietet Methoden von ausserhalb an, ihren Funktionszeiger abzulegen
        public event ChangedPercentValueDelegate ChangedPercentValue;
        public event ResultDelegate ResultCompletedDelegate; 


        public void StartProcess()
        {
            //Progress etc. 
            for(int i = 0; i <=100; i++)
            {
                //ausgeben oder nach draußen kommunizieren
                //Bei jedem Durchlauf wird die neue Prozentanzeige nach draußen kommuniziert
                OnProcessPercentStatus(i);
            }
            //Kommunizieren wir nach "draußen" dass wir fertig sind 

            OnResult("Hallo liebes PRogramm, deine Komponete sauber durchgelaufen");
        }

        protected virtual void OnProcessPercentStatus(int percent)
            => ChangedPercentValue?.Invoke(percent); //Von hier gelangen wir in die Methode (Invoke)-> Program.cs -> BusinessLogicComponentA_ChangedPercentValue
    
    
        protected virtual void OnResult(string msg)
            => ResultCompletedDelegate?.Invoke(msg); //Was ist das Fragezeichen hier: Wenn ResultCompletedDelegate keinen Funktionzeige besitzt, wird auch kein Invoke aufgerufen 

    }
}
