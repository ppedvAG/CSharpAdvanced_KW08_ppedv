//TopLevel Statements ersetzen die Main Methode
using CSharp9Samples;

Console.WriteLine("Hello, World!");

PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");

#region Class vs Record  -> = - Operator

if (myPerson1Class.Name == myPerson2Class.Name)
    Console.WriteLine("Gleich");

if (myPerson1Class == myPerson2Class) // gleich oder ungleich? Achtung Speicheradressen werden
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
}


if (personRecord1 == personRecord2)
{
    Console.WriteLine("personRecord1 == personRecord2 -> gleich");
}
else
{
    Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
}
#endregion

if (myPerson1Class.Equals(myPerson2Class))
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
}

if (personRecord1.Equals(personRecord1))
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
}
else
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
}



//Dekonstruktion
/*
 * public void Deconstruct(out int Id, out string Name)
	{
		Id = this.Id;
		Name = this.Name;
	}
 * 
 * 
 */
(int id, string name) = personRecord1; //Dekonstruktion per Default mit dabei 

//JSON als Klassenausgabe
personRecord1.ToString();



#region Record mit With

Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[2] { "1234", "5678" } };

Console.WriteLine("Ausgabe von Record -> ToString()");
Console.WriteLine(person1); // ->  person1.ToString();
                            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }


//person1.FirstName = "Max"; //set - funktioniert so nicht

//Init-Zuweisung bei übergabe von Objekten mit with 
Person person2 = person1 with { FirstName = "John" }; //Init-Phase
Console.WriteLine(person2);
#endregion