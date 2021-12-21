namespace DesignPatterns.Structural._3_Composite;

//Composite pattern lets clients treat the individual objects in a uniform manner

public interface IEmployee
{
    float GetSalary();
    string GetRole();
    string GetName();
}

public class Developer : IEmployee
{
    private string _name;
    private float _salary;

    public Developer(string name, float salary)
    {
        _name = name;
        _salary = salary;
    }

    public float GetSalary() => _salary;
    public string GetRole() => "Developer";
    public string GetName() => _name;
}

public class Designer : IEmployee
{
    private string _name;
    private float _salary;

    public Designer(string name, float salary)
    {
        _name = name;
        _salary = salary;
    }

    public float GetSalary() => _salary;
    public string GetRole() => "Designer";
    public string GetName() => _name;
}

public class Organization
{
    protected List<IEmployee> employees;
    public Organization() => employees = new List<IEmployee>();
    public void AddEmployee(IEmployee employee) => employees.Add(employee);

    public float GetNetSalaries()
    {
        float netSalary = 0;
        foreach (var e in employees) netSalary += e.GetSalary();
        return netSalary;
    }
}

public static class CompositeOutPut
{
    public static void Display()
    {
        //Arrange Employees, Organization and add employees
        var developer = new Developer("John", 5000);
        var designer = new Designer("Arya", 5000);
        var organization = new Organization();
        organization.AddEmployee(developer);
        organization.AddEmployee(designer);
        Console.WriteLine($"Net Salary of Employees in Organization is {organization.GetNetSalaries()}");
        //Ouptut: Net Salary of Employees in Organization is $10000.00
    }
}