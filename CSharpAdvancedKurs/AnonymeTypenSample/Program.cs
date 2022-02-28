using System.Dynamic;

dynamic myObj = new ExpandoObject();

myObj.Vorname = "Max";
myObj.Nachname = "Moritz";
myObj.Feierabend = true;

Console.WriteLine(myObj.Vorname);
Console.WriteLine(myObj.Nachname);


if (myObj.Feierabend)
{
    Console.WriteLine("Feierabend!");
}