// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class Bruch
{

    public int Zähler { get; set; }
    public int Nenner { get; set; }

    public Bruch(int Zähler, int Nenner)
    {
        this.Zähler = Zähler;
        this.Nenner = Nenner;
    }

    #region == und !=

    public static bool operator ==(Bruch left, Bruch right)
    {
        if (left.Nenner != right.Nenner)
            return false;

        if (left.Zähler != right.Zähler)
            return false;


        return true; //Beide sind Gleich
    }

    public static bool operator != (Bruch left, Bruch right)
    {
        if (left.Nenner == right.Nenner)
            return false;

        if (left.Zähler == right.Zähler)
            return false;

        return true;
    }
    #endregion

    #region Verbund < und >
    public static bool operator > (Bruch left, Bruch right)
    {
        return true;
    }
    public static bool operator < (Bruch left, Bruch right)
    {
        return true;
    }
    #endregion

    #region >= und <= 
    public static bool operator >=(Bruch left, Bruch right)
    {
        return true;
    }

    public static bool operator <=(Bruch left, Bruch right)
    {
        return true;
    }
    #endregion


    //Operatoren sind Überladbar

    public static Bruch operator *(Bruch left, Bruch right)
            => new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);

    public static Bruch operator *(Bruch left, int right)
    {
        return new Bruch(left.Zähler * right, left.Nenner);
    }
}