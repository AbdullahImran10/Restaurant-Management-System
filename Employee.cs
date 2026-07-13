using System;
using System.Collections.Generic;
public class Employee
{
    private static int Ecount=400;
    public int EmployeeID { get; }
    public string Name { get; set; }
    public string Role { get; set; }
    public double Salary { get; set; }
    public Employee( string name, string role, double salary)
    {
        EmployeeID=++Ecount;
        Name=name;
        Role=role;
        Salary=salary;
    }
    public virtual void DisplayInfo()
    {
    Console.WriteLine("================================");
    Console.WriteLine($"Employee ID : {EmployeeID}");
    Console.WriteLine($"Name        : {Name}");
    Console.WriteLine($"Role        : {Role}");
    Console.WriteLine($"Salary      : Rs. {Salary}");
    }
    public virtual double CalculateSalary()
    {
        return Salary;
    }
    public virtual void UpdateSalary(double amount)
    {
         if (amount > 0)
    {
        Salary += amount;
    }
    }
}
public class Chef : Employee
{
      public string Specialty { get; set; }
    public int DishesPrepared { get; set; }

    public Chef(string name, double salary, string specialty)
        : base(name, "Chef", salary)
    {
        Specialty = specialty;
        DishesPrepared = 0;
    }

    public void CookFood()
    {
        Console.WriteLine(Name + " is cooking " + Specialty + " food.");
    }

    public void UpdateDishesPrepared(int count)
    {
        DishesPrepared += count;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Specialty: " + Specialty);
        Console.WriteLine("Dishes Prepared: " + DishesPrepared);
    }
}
public class Waiter: Employee
{
        public int TablesAssigned { get; set; }
    public int OrdersServed { get; set; }

    public Waiter(string name, double salary, int tablesAssigned)
        : base( name, "Waiter", salary)
    {
        TablesAssigned = tablesAssigned;
        OrdersServed = 0;
    }

    public void TakeOrder()
    {
        Console.WriteLine(Name + " is taking an order.");
    }

    public void ServeFood()
    {
        Console.WriteLine(Name + " is serving food.");
        OrdersServed++;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Tables Assigned: " + TablesAssigned);
        Console.WriteLine("Orders Served: " + OrdersServed);
    }
}
public class Manager : Employee
{
    public int TeamSize { get; set; }
    public double Bonus { get; set; }

    public Manager(string name, double salary, int teamSize, double bonus)
        : base( name, "Manager", salary)
    {
        TeamSize = teamSize;
        Bonus = bonus;
    }

    public void AssignTask()
    {
        Console.WriteLine(Name + " is assigning tasks to employees.");
    }

    public void ApproveLeave()
    {
        Console.WriteLine(Name + " approved an employee's leave request.");
    }

 
    public override double CalculateSalary()
    {
        Console.WriteLine("Total Salary: " + (Salary + Bonus));
        return Salary+Bonus;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Team Size: " + TeamSize);
        Console.WriteLine("Bonus: " + Bonus);
    }
}

