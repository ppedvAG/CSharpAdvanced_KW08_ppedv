using System;

namespace Modul019_01_StructVsClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Erstellung von Objekten
            PersonC cPerson = new PersonC("Heiko", 35);

            PersonS sPerson = new PersonS("Anna", 35);
            PersonS sPersonB;

            //Hier wird jede einzelne Property/Fields seperat kopiert. (langsamer Weg)
            sPersonB = sPerson; //Kopie wird übergeben (Wertetyp)


            //Mit einer Zuweisung kann ich die komplette Struktur übergegben (Referenz übergeben)
            ref PersonS referenz = ref sPerson; //struct wird als Referenztyp hier behandelt. 

            //Ausgabe
            Console.WriteLine($"{cPerson.name}: {cPerson.alter}"); //35
            Console.WriteLine($"{sPerson.name}: {sPerson.alter}"); //35 

            //Funktionsaufruf
            Altern(cPerson); //Refrenz
            Altern(sPerson);


            //Erneute Ausgabe: Nur das Klassenobjekt (Referenztyp) hat sich verändert
            Console.WriteLine($"{cPerson.name}: {cPerson.alter}");
            Console.WriteLine($"{sPerson.name}: {sPerson.alter}");

            //Übergabe des Wertetyps als Refernz mittels Ref-Stichwort
            Altern(ref sPerson);
            Console.WriteLine($"{sPerson.name}: {sPerson.alter}");
        }

        public static void Altern(PersonC cPerson) //Bei der Klasse wird die Referenz übergeben
        {
            cPerson.alter++;
        }

        public static void Altern(PersonS sPerson) //Hier wird eine Kopie übegeben
        {
            sPerson.alter++;
        }

        //Mittels des REF-Stichworts können Wertetypen als Referenz an Methoden übergeben werden. D.h. die übergebene Speicherstelle selbst 
        ///wird manipuliert und nicht, wie normalerweise bei Wertetypen, eine Kopie des Werts.
        public static void Altern(ref PersonS sPerson)
        {
            sPerson.alter++;
        }
    }


    public class PersonC //Referenztypen
    {
        public string name;
        public int alter;

        public PersonC(string name, int alter)
        {
            this.name = name;
            this.alter = alter;
        }
    }

    //STRUCTS sind Klassenähnliche Konstrukte, welche nicht, wie Klassen, als Referenztypen behandelt werden, sondern ein Wertetyp sind. D.h
    //bei Übergabe eines Structs an eine Methode oder Variable wird eine Kopie dieses Objekts erstellt
    public struct PersonS
    {
        public string name;
        public int alter;

        public PersonS(string name, int alter)
        {
            this.name = name;
            this.alter = alter;
        }
    }
}
