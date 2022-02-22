using System;

namespace DelegatesActionsFuncsSamples
{

    //Delegate nennt sich ChangeNumber
    //Gibt ein int als Return-Wert zurück
    //Als Parameter wird int number verwendet
    delegate int ChangeNumber(int number);

    delegate int AddNumberDelegate(int z1, int z2);


    public class Program
    {
        static void Main(string[] args)
        {

            #region Delegate Beispiele
            //ChangeNumber erhält von AddOffset die StartAdresse (Funktionszeiger)
            //ChangeNumber kann daher die Methode AddOffset aufrufen
            ChangeNumber changeNumber = new ChangeNumber(/*Funktionszeiger*/AddOffset);

            int result = changeNumber(22); //Rufe über Delegate die Methode AddOffset
            Console.WriteLine(result); //27

            //Alternative Schreibweise 
            ChangeNumber changeNumber2 = null;
            changeNumber2 += AddOffset;
            changeNumber2 += SubDownSet;

            changeNumber2 -= AddOffset; //Funktionerzeiger von weggenommen
            changeNumber(22); //Es wird nur noch SubDownSet 

            //Von der letzten aufgerufenen Methode erhalte ich einen Return-Wert
            //Daher bringt es nicht, mehrere Methoden mit Return-Werten einzubinden 
            //besser wäre Methoden, die ein Void zurück geben 
            result = changeNumber2(42);

            Console.WriteLine(result); //27
            //Für jede neue Methode müsste man ein Delgate anlegen 
            AddNumberDelegate addNumberDelegate = new AddNumberDelegate(Addidiere);
            #endregion

            //Werden Methoden verwendet OHNE Return-Wert

            //delegate void OperationDelegate(int zahl1, int zahl2);
            //OperationDelegate operationDelegate = new OperationDelegate(AddNumberAndShowResult);
            Action<int, int> addiereActionDelegate = new Action<int, int>(AddNumberAndShowResult);


            //Func arbeitet mit Methoden mit Return-Wert zusammen
            Func<int, int, double> divideFuncDelegate = new Func<int, int, double>(Divide);

            double divideResult = divideFuncDelegate(15, 4);

            Console.WriteLine(divideResult);
            Console.ReadLine();
        }

        public static int AddOffset(int myNumber)
            => myNumber + 5;

        public static int SubDownSet(int myNumber)
            => myNumber - 5; //Kurzschreibweise für Methoden -> return myNumber - 5;


        public static int Addidiere(int zahl1, int zahl2)
            => zahl1 + zahl2;

        public static double Divide(int zahl1, int zahl2)
            => zahl1 / zahl2;

        public static void AddNumberAndShowResult(int zahl1, int zahl2)
            => Console.WriteLine(zahl1 + zahl2);



    }
}
