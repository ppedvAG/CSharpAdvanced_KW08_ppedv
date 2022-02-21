// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#region Anti-Beispiel


public class EmployeeBad
{
    //Datenstruktur einer Tabelle in einer DB -> 
    public int Id { get; set; } //Properties
    public string Name { get; set; }    


    //InsertEmployeeToTable -> DataAccess Layer -> (MEthode redet mit DB) 
    public void InsertEmployeeToTable(EmployeeBad employee)
    {
        //any Code
    }

    //Ausgabe-> UI Präsentation Layer oder Service Layer (als JSON) 
    public void GenerateReport()
    {
        //any Code
    }
}
#endregion

#region Besser Variante

public class Employee
{
    public int Id { get; set; } 

    public string Name { get; set; }    
}

//Ein Repository stellt das Manipilieren und Auslesesn gegenüber einer DB->Tabelle dar. 
//Eine REpository-Klasse beartbeitet eine Tabelle -> 1:1 
public class EmployeeRepository
{
    public void Insert(Employee employee)
    {
        //Any Code für das Speichern eines Employee Datensatzes
    }
}

public class EmployeeReport
{
    public void GenerateReport()
    {

    }
}
#endregion
