
using System;
using System.Collections.Generic;

public class Restaurant
{
    public string Name { get; set; }

    public Menu Menu { get; }
    public List<Customer> Customers { get; }
    public List<Employee> Employees { get; }
    public List<Order> Orders { get; }
    public List<Table> Tables { get; }
    public List<Reservation> Reservations { get; }

    public Restaurant(string name)
    {
        Name = name;

        Menu = new Menu();
        Customers = new List<Customer>();
        Employees = new List<Employee>();
        Orders = new List<Order>();
        Tables = new List<Table>();
        Reservations = new List<Reservation>();
    }

    // MENU
    public void AddMenuItem(MenuItem item)
    {
        Menu.AddItem(item);
    }

    public void RemoveMenuItem(MenuItem item)
    {
        Menu.RemoveItem(item);
    }

    public void DisplayMenu()
    {
      Menu.DisplayMenu();
    }

    // CUSTOMERS
   public bool AddCustomer(Customer customer)
{
    foreach (Customer c in Customers)
    {
        if (c.Name.Equals(customer.Name, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Customer {c.CustomerID} already exists.");
            return false;
        }
    }

    Customers.Add(customer);
    Console.WriteLine("Customer added successfully.");
    return true;
}

    // EMPLOYEES
    public void HireEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        Employees.Remove(employee);
    }

    public void DisplayEmployees()
    {
        Console.WriteLine("\n----- EMPLOYEES -----");

        foreach (Employee employee in Employees)
        {
            employee.DisplayInfo();
            Console.WriteLine();
        }
    }

    // TABLES
    public void AddTable(Table table)
    {
        Tables.Add(table);
    }

    public void DisplayTables()
    {
        Console.WriteLine("\n----- TABLES -----");

        foreach (Table table in Tables)
        {
            table.DisplayStatus();
            Console.WriteLine();
        }
    }

    // ORDERS
    public void PlaceOrder(Order order)
    {
        Orders.Add(order);
        order.Customer.AddVisits();
        Console.WriteLine("Order placed successfully.");
    }

    public void DisplayOrders()
    {
        Console.WriteLine("\n----- ORDERS -----");

        foreach (Order order in Orders)
        {
            order.DisplayOrder();
            Console.WriteLine();
        }
    }

    // RESERVATIONS
    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
        reservation.BookReservation();
    }

    public void CancelReservation(Reservation reservation)
    {
        reservation.CancelReservation();
        Reservations.Remove(reservation);
    }

    public void DisplayReservations()
    {
        Console.WriteLine("\n----- RESERVATIONS -----");

        foreach (Reservation reservation in Reservations)
        {
            Console.WriteLine("Reservation ID: " + reservation.ReservationID);
            Console.WriteLine("Customer: " + reservation.Customer.Name);
            Console.WriteLine("Table: " + reservation.Table.TableNumber);
            Console.WriteLine("Date: " + reservation.ReservationDateTime);
            Console.WriteLine();
        }
    }
    public void NumberOfCustomers(List<Customer> customers)
{
    Console.WriteLine("Number of Customers: " + customers.Count);
}

    // REPORTS
    public void GenerateReports()
    {
        Report report = new Report();

        Console.WriteLine("\n===== REPORTS =====");

        report.TotalSales(Orders);
        Console.WriteLine();

        report.TodaysOrders(Orders);
        Console.WriteLine();

        report.MostOrderedItem(Orders);
        Console.WriteLine();

        report.NumberOfCustomers(Customers);
        Console.WriteLine();

        report.PendingOrders(Orders);
    }
}

