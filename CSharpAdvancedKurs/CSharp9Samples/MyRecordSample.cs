using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Samples
{
    public record PersonRecord(int Id, string Name); //get/set/init Properties

    public record EmployeeRecord : PersonRecord
    {
        public decimal Gehalt { get; set; }

        public EmployeeRecord(int Id, string Name, decimal Gehalt)
           : base(Id, Name) //Aufruf des Konstruktor der Basisklasse
        {
            this.Gehalt = Gehalt;
        }
    }


    public record Car
    {
        public int Id { get; set; } //Man kann auch anstatt init -> set verwenden. !!! Wichtig man muss dann die Klasse ein wenig ausschreiben
        public string Brand { get; set; }

        public void StarteMotor()
        {

        }
    }





    public class PersonClass
    {
        public PersonClass(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }



    public record Person(string FirstName, string LastName)
    {
        public string[] PhoneNumbers { get; init; }
    }
}
