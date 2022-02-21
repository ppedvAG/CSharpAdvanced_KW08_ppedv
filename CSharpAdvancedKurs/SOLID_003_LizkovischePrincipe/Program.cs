// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#region Bad Code

public class BadKirsche
{
    public int TageDerReife = 100;
    public string GetColor()
    {
        return "rot";
    }
}


public class BadErdbeere : BadKirsche
{
    public string GetColor()
    {
        return base.GetColor(); // Das ist flasch 
    }
}
#endregion

#region Good Code

//Open Part
public abstract class Fruits
{
    public abstract string GetColor();
}

public class IVitaminB12
{
    //Konzentrat pro mg
    public int Konzentrat()
    {
        return 23; //23 mg
    }
}

public class IVataminC : IVitaminB12
{
    public int Konzentrat()
    {
        return base.Konzentrat();
    }
}


//Close Part
public class Kirsche : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}

public class Erdbeer : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}
#endregion