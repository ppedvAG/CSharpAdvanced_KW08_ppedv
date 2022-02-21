// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


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
}

public interface IDriveVehicle
{
    void Drive();
}

public interface ISwimVehicle
{
    void Swim();
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
}


#endregion

