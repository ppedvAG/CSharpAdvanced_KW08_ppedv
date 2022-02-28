using HelloSerialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

Person person = new Person()
{
    Vorname = "Max",
    Nachname = "Moritz",
    Alter = 19,
    Kontostand = 5_000,
    KreditLitmit = 50_000
};

Stream stream = null;

#region Binär
//Binäre Datei schreiben
//System.Runtime.Serialization.Formatters.Binary;
BinaryFormatter binaryFormatter = new BinaryFormatter(); //BinaryFormatter zerlegt Objekte in einen binären stream
stream = File.OpenWrite("Person.bin");

binaryFormatter.Serialize(stream, person);
stream.Close();


//binäre Datei einlesen
stream = File.OpenRead("Person.bin");
Person geladenePerson = (Person) binaryFormatter.Deserialize(stream);
stream.Close();

#endregion


#region XmlFormatter
//Object -> Xml
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
stream = File.OpenWrite("Person.xml");
xmlSerializer.Serialize(stream, person);
stream.Close();


//XML -> Object
stream = File.OpenRead("Person.xml");
Person geladenePerson2 = (Person)xmlSerializer.Deserialize(stream);
stream.Close();
#endregion

#region JSON
//schreiben
string jsonString = JsonConvert.SerializeObject(person);
await File.WriteAllTextAsync("Person.json", jsonString);


//Auslesen
string readedJsonString = await File.ReadAllTextAsync("Person.json");
Person geleadenePerson2 = JsonConvert.DeserializeObject<Person>(readedJsonString);
#endregion

#region eigener CSV Parser
#endregion


person.Speichern("Person.csv"); //this person -> personen instanz

Person person1 = new();
person1.Laden("Person.csv");

Console.ReadLine();


[Serializable]
public class Person
{
    public string Vorname { get; set; } 
    public string Nachname { get; set; }
    public int Alter { get; set; }

    [field: NonSerialized]
    [XmlIgnore]
    [JsonIgnore]
    public decimal Kontostand { get; set; }

    [field: NonSerialized]
    [XmlIgnore]
    [JsonIgnore]
    public decimal KreditLitmit;
}