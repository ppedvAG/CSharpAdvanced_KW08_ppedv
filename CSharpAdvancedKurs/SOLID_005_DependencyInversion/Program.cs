ICar myCar1 = new Car() { Marke = "VW", Modell = "Polo", Baujahr = 1987 };
Car normalCar = new Car() { Marke = "VW", Modell = "Polo 2", Baujahr = 1990 };

//Für Testzwecke:
ICar mockCarObj = new DummyTestCarObj();
ICarService service = new CarService();

service.Repair(mockCarObj); //Testbares OBject für Tag 4/5
service.Repair(myCar1); //Fertige Implemtierung 
service.Repair(normalCar);  //In Car 
#region BadCode Auto/Werkstatt

//Programmierer A: 5 Tage -> Startet an Tag 1 bis Tag 5
public class BadCar //BadCar.dll
{
    public string Marke { get; set; }   
    public string Modell { get; set; }   
    public int Baujahr { get; set; }
}

//Programmierer B: 3 Tage ->Startet wahrscheinlich am Tag 5 -> und Endet am Tag 8
public class BadCarService //BadCarService.dll -> benötige immer die BadCar´.dll
{
    public void Repair (BadCar car) //Feste Kopplung 
    {
        //repariere Auto

        //car.Modell -> wenn das fehlt....muss Programmierer B auf A warten 
    }
}
#endregion



#region Best Pratice

//Contract First -> Bedeutet -> Enwickler A und B definieren Interfaces, die die Lösung umreißen. 
public interface ICar
{
    string Marke { get; set; }  
    string Modell { get; set; } 
    int Baujahr { get; set;}
}

public interface ICarService
{
    void Repair(ICar car);
}


//Programmierer A -> 5 Tage (Tag 1 -> bis Tag 5)
public class Car : ICar
{
    public string Marke { get; set; }
    public string Modell { get; set; }
    public int Baujahr { get; set; }
}

//Programmierer B -> 3 (Tag 1 bis Tag3)
public class CarService : ICarService
{
    public void Repair(ICar car) //Lose Kopplung (Klassen kennen sich nicht untereinander , sondern kommunizieren via Interfaces 
    {
       //repariere Auto
    }
}

public class DummyTestCarObj : ICar
{
    public string Marke { get; set; } = "Mercedes"; //Defaultwerte
    public string Modell { get; set; } = "AMG";
    public int Baujahr { get; set; } = 2012;
}

#endregion
