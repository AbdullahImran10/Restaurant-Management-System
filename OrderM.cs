using System;
using System.Collections.Generic;
public enum OrderStatus
{
    Pending,
    Preparing,
    Ready,
    Completed,
    Cancelled    
}
public class Order
{
    private static int ordercount=0;
    public string OrderID {get;}
    public Customer Customer {get; set;}
    public List<MenuItem> Items {get;}
    public double TotalBill {get; private set;}
    public DateTime OrderDate{ get;}
    public OrderStatus Status{ get; set;}
    public Order(Customer Customer)
    {
        OrderID="O"+(++ordercount).ToString("D3");
        this.Customer=Customer;
        Items=new List<MenuItem>();
        TotalBill=0;
        Status=OrderStatus.Pending;
         OrderDate = DateTime.Now;
    }
    public void AddItem(MenuItem item)
    {
        Items.Add(item);
        TotalBill+=item.Price;
    }
    public void RemoveItem(MenuItem item)
    {
        if (Items.Remove(item))
        {
            TotalBill-=item.Price;
        }
    }
    public void DisplayOrder()
    {
        Console.WriteLine($"OrderID : {OrderID}");
        Console.WriteLine($"Customer : {Customer.Name}");
        Console.WriteLine($"Status   : {Status}");
        Console.WriteLine("\nItems:");

        foreach (MenuItem item in Items)
        {
            Console.WriteLine($"{item.Name} - Rs. {item.Price}");
        }

        Console.WriteLine($"\nTotal Bill : Rs. {TotalBill}");
        Console.WriteLine("Visits: " + Customer.Visits);
        Console.WriteLine("Loyalty Points: " + Customer.LoyaltyPoints);
    }
    public double CalculateBill()
    {
        // Customer.AddVisits();
        double total=0.0;
        foreach(MenuItem i in Items)
        {
            total+=i.Price;
        }
        return total;
    }


}