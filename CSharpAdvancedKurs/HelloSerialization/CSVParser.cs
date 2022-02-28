using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSerialization
{

    //Erweiterungsmethoden

    //wichtig static class!
    public static  class CSVParser
    {

        //Methode Speichern wird jeder Personen-Instanz hinzugefügt. 
        public static void Speichern(this Person p, string savePath)
        {
            File.WriteAllText(savePath, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand};{p.KreditLitmit}");
        }

        public static void Laden(this Person p, string path)
        {
            string content = File.ReadAllText(path);

            string[] csvPart = content.Split(';');

            p.Vorname = csvPart[0];
            p.Nachname = csvPart[1];
            p.Alter = int.Parse(csvPart[2]);
            p.Kontostand = Convert.ToInt32(csvPart[3]);
            p.KreditLitmit = Convert.ToInt32(csvPart[4]);
        }
    }
}
