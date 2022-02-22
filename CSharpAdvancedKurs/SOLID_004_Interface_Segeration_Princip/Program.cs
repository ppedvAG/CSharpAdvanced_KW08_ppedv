#nullable disable
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MyApp app = new MyApp();

SchwimmFlugzeug2 flugzeug2 = new SchwimmFlugzeug2();

flugzeug2.FlugzeugName = "Lufthansa";
flugzeug2.PilotWechsel(); //Pilot ist eine niormale Methode der Klasse SchwimmFlugzeug2

app.StartFlugzeug(flugzeug2);
app.ShowFlugzeug(flugzeug2);

ISwimPlan swimmPlain = new SchwimmFlugzeug2();
swimmPlain.Swim();
swimmPlain.Fly();


IFlyVehicle swimmPlan2 = new SchwimmFlugzeug2();
swimmPlan2.Fly();

ISwimVehicle swimVehicle = new  SchwimmFlugzeug2();



//Interfaces mit dem selben Methoden Namen
IFlyVehicle p1 = new MultiVehicle();
ISwimVehicle p2 = new MultiVehicle();
p1.TestMotor();
p2.TestMotor();




public class MyApp
{
    public void StartFlugzeug(ISwimPlan swimPlan)
    {
        swimPlan.Fly();
        swimPlan.Swim();
    }

    public void ShowFlugzeug(IFlyVehicle flyVehicle)
    {
        SchwimmFlugzeug2 plain = (SchwimmFlugzeug2)flyVehicle;

        plain.PilotWechsel();
        plain.Swim();
        plain.Fly();
    }
}



#region BadCode
public interface IBadVehicle
{
    void ICanFly();
    void ICanDrive();
    void ICanSwim();
}

public class BadMultiplesVehicle : IBadVehicle
{
    public void ICanDrive()
    {
        Console.WriteLine("Ich kann auf der Straße fahren"); 
    }

    public void ICanFly()
    {
        Console.WriteLine("Ich kann in der Luft fliegen");
    }

    public void ICanSwim()
    {
        Console.WriteLine("Ich kann schwimmen");
    }
}

public class BadCarVehicle : IBadVehicle
{
    public void ICanDrive()
    {
        Console.WriteLine("Ich kann auf der Straße fahren");
    }

    public void ICanFly()
    {
        throw new NotImplementedException(); //Es kann nicht fliegen 
    }

    public void ICanSwim()
    {
         //Es kann nicht schwimmen
    }
}

#endregion



#region BEst Practice

public interface IFlyVehicle
{
    void Fly();

    void TestMotor();
}

public interface IDriveVehicle
{
    void Drive();
}
public interface IDriveWithElektroMotor : IDriveVehicle
{
    void LoadBattery();
}

public interface ISwimVehicle
{
    void Swim();

    void TestMotor();
}


public interface ISwimPlan : ISwimVehicle, IFlyVehicle
{
    //Swim()
    //Fly()

    //2x TestMotor 
    // ISwimVehicle.TestMotor
    // IFlyVehicle.TestMotor
}




public class DriveVehicle : IDriveVehicle
{
    public void Drive()
    {
        Console.WriteLine("Ich fahre auf der Straße");
    }
}

public class MultiVehicle : IDriveVehicle, ISwimVehicle, IFlyVehicle
{
    public void Drive()
    {
        Console.WriteLine("Drive");
    }

    public void Fly()
    {
        Console.WriteLine("Fly");
    }

    public void Swim()
    {
        Console.WriteLine("Swimm");
    }

    void IFlyVehicle.Fly()
    {
        throw new NotImplementedException();
    }

    void ISwimVehicle.Swim()
    {
        throw new NotImplementedException();
    }


    //Impliziet Implementierung eines Interfaces -> Test-Methode ist von jedem Interface (das verwendet) zentral aufrufbar. 
    
    //public void TestMotor() //ISwimVehicle.TestMotor + IFlyVehicle.TestMotor
    //{

    //}


    #region Explizietes Implementierung eines Interfaces
    void ISwimVehicle.TestMotor()
    {
        Console.WriteLine("Teste den Schwimmmotor");
    }

    void IFlyVehicle.TestMotor()
    {
        Console.WriteLine("Teste den Flugmotor");
    }

  
}

public class SchwimmFlugzeug : IFlyVehicle, ISwimVehicle
{
    public void Fly()
    {
        Console.WriteLine("Fliege wie ein Flugzeug");
    }

    public void Swim()
    {
        Console.WriteLine("Verwende See als start und Landebahn");
    }

    public void TestMotor()
    {
        throw new NotImplementedException();
    }
}

public class SchwimmFlugzeug2 : ISwimPlan
{
    public void Fly()
    {
       
    }

    public void Swim()
    {
        
    }

    public void PilotWechsel()
    {

    }

    public void TestMotor()
    {
        throw new NotImplementedException();
    }

    public string FlugzeugName { get; set; }
}


#endregion




