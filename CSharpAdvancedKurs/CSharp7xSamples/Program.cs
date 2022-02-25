using System;

namespace CSharp7xSamples
{
    internal class Program
    {
        public static string Vorname { get; set; }
        public static string Nachname { get; set; }
        public static string ZweiterVorname { get; set; }

        static void Main(string[] args)
        {
            #region Tupel
            var items = VollenNamenAusgeben();
            Console.WriteLine(items.Item1 + " " + items.Item2 + " " + items.Item3);

            (string vn, string zv, string nn) = VollenNamenAusgeben();
            Console.WriteLine(vn + zv + nn);

            var (vorname, zweitervname, familienname) = VollenNamenAusgeben();
            #endregion

            #region Dekonstruktion
            Kunde kunde = new Kunde { Id = 11, Name = "Tester", Stammkunde = true };

            var (id, name, stammkunde) = kunde; //kunde->Dekonstruktor

            #endregion

            #region Out 
            int result = 0; //Int ist ein Wertetyp

            //Was macht ein Wertetyp - Er kopiert seinen Inhalt und gibt den Inhalt als Kopie in eine andere Variabe
            Addieren1(result, 5, 6);
            Console.WriteLine(result); //0


            Addieren(out result, 5, 6);

            Console.WriteLine(result); //11

            string numberAsText = "12345";

            if (int.TryParse(numberAsText, out result))
            {
                //wenn wr hier sind, hat das casten funktioniert
                Console.WriteLine(result); //12345 als int
            }
            #endregion
        }

        #region Out Sample
        public static void Addieren1(int result, int zahll1, int zahl2)
        {
            //hier ist Result: 11
            result = zahll1 + zahl2;

        }

        public static void Addieren( out int result, int zahl1, int zahl2)
        {
            
            result = zahl1 + zahl2;
        }
        #endregion

        public static (string, string, string) VollenNamenAusgeben()
        {
            return (Vorname, !string.IsNullOrEmpty(ZweiterVorname) ? ZweiterVorname : string.Empty, Nachname);
        }
    }


    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Stammkunde { get; set; }

        public void Deconstruct(out int Id, out string Name, out bool Stammkunde)
        {
            Id = this.Id;
            Name = this.Name;
            Stammkunde = this.Stammkunde;
        }

    }
}
