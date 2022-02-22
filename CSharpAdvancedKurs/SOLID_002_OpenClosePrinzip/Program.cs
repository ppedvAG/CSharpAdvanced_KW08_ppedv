
using System.Collections.Generic;

CrystalReportGenerator crg1 = new CrystalReportGenerator();

FastReportGenerator fast1 = new FastReportGenerator();

ABCReporterGenerator abc1 = new ABCReporterGenerator();


//Eingabe (simulieren)
SelectReport SelectReport = SelectReport.FR;

if (SelectReport == SelectReport.FR)
{
    fast1.GeneratoreReport(new Employee());
}
else if (SelectReport == SelectReport.CR)
{
    crg1.GeneratoreReport(new Employee());
}




//Mögliches Verwendungs-Szneario
List<EmployeeGenerator> liste = new List<EmployeeGenerator>();
liste.Add(crg1);
liste.Add(fast1);
liste.Add(abc1);    

//Gehe komplette Liste von abgeleiteteden Klassen durch und führe jeweils die überschrieben abstrakte Methode aus
foreach(EmployeeGenerator e in liste)
{
    //Employee
    e.GeneratoreReport(new Employee() { Id=1, Name="Peter Musterfrau"});
}





public enum SelectReport { CR, FR, PDF }
public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }
}


#region Bad Code
public class BadReportGenerator
{
    public string ReportType { get; set; } = string.Empty;


    public string[] GetAllTemplates ()
    {
        if (ReportType == "CR")
        {
            //Generiere Crstal Reports
            //

            ///

            // CR

            // CR
        }
        else if (ReportType == "FastReport")
        {
            //Dll wird hier angeteuert
            //Generiere Fast Reports 


            //FastReport hier und da
        }
        else
        {
            //Generiere PDF 

            //PDF 
        }


        return Array.Empty<string>();
    }
    public void GnerateReport(Employee em)
    {
        //Gibt es hier komische Initialisierungen
        if (ReportType == "CR")
        {
            //Generiere Crstal Reports
        }
        else if(ReportType == "FastReport")
        {
            //Dll wird hier angeteuert
            //Generiere Fast Reports 


            //Trifft die Initialisierung auf mich hier zu? 
        }
        else  
        {
            //Generiere PDF 
        }
    }
}
#endregion

#region Good Code

#region Open-Part mit abstrakte Klasse und interface
//abstraktion -> Open-Part 
public abstract class EmployeeGenerator
{

    //abstrakten Methoden MÜSSEN in der Vererbten Klasse überschrieben werden 
    public abstract void GeneratoreReport(Employee em);
}

//Alternative  
public interface IEmployeeGenerator
{ 
    //nterface muss beim Implementiert werden
    void GeneratoreReport(Employee em);
}
#endregion


#region Close-Part Abgeleitede Klassen
public class CrystalReportGenerator : EmployeeGenerator
{
    public override void GeneratoreReport(Employee em)
    {
       //Crystal Report wird generiert 
    }

    //Weitere MEthoden die hier hinzukommen, arbeiten nur mit CR-Library.dll zusammena
}

public class FastReportGenerator : EmployeeGenerator
{
    public override void GeneratoreReport(Employee em)
    {
        //Fast Report
    }

    //Weitere Methoden hinzufügen, die FastReport relevant sind 
}


public class ABCReporterGenerator : EmployeeGenerator
{
    public override void GeneratoreReport(Employee em)
    {
        //Fast Report
    }

    //Weitere Methoden hinzufügen, die FastReport relevant sind 
}
#endregion







#region abstrakt vs Interface

//Open Part
public abstract class ReportGeneratorBase<T> 
{
    public abstract void GenerateItem(T itemToGenerate);

    public void Konfigurations()
    {
        //Basis-Implementierung -> Alle abgeleitete Klassen können diese Methode aufrufen
    }
}

public class EmployeeReportGenerator : ReportGeneratorBase<Employee>
{
    public override void GenerateItem(Employee itemToGenerate)
    {
        //Vorlage + Employee -> Report 
    }
}



#endregion
#endregion