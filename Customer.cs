using System;
public class Customer
{
    public string Name{get; set;}
    public string PhoneNumber{get; set;}
    private static int count=1000;
    public int LoyaltyPoints{get; set;}
    public int Visits{get; private set;}
    public int CustomerID{get;}
    public Customer(string name, string PhoneNumber)
    {
        this.Name=name;
        this.PhoneNumber=PhoneNumber;
        CustomerID=++count;
        Visits=0;
        LoyaltyPoints=0;
    }
    public void Display()
    {
        Console.WriteLine("================================");
        Console.WriteLine("\t\tCustomer Details");
        Console.WriteLine("================================");
        Console.WriteLine("Customer ID: "+CustomerID);
        Console.WriteLine("Customer Name: "+Name);
        Console.WriteLine("Customer Phone Number: "+PhoneNumber);
        Console.WriteLine("Customer Visits: "+Visits);
        Console.WriteLine("Customer Loyalty Points: "+LoyaltyPoints);
        Console.WriteLine("================================");
    }
    public void AddVisits()
    {
        Visits++;
        if (Visits > 2)
        {
            LoyaltyPoints+=3;
        }
    }
public bool RedeemLoyaltyPoints()
{
    if (LoyaltyPoints >= 10)
    {
        LoyaltyPoints -= 10;
        return true;
    }

    return false;
}
}