using System;
using System.Collections.Generic;

public class Bill
{
    public int BillID { get; }
    private static int nextBillID = 1000;

    public List<MenuItem> OrderedItems { get; }
    public Customer customer {get; set;}

    public double Discount { get; set; }   // Percentage
    public double Tax { get; set; }        // Percentage

    public Bill(Customer customer)
    {
        BillID = ++nextBillID;
        OrderedItems = new List<MenuItem>();
        Discount = 0;
        Tax = 0;
        this.customer=customer;
    }

    public void AddItem(MenuItem item)
    {
        OrderedItems.Add(item);
    }

    public void RemoveItem(string itemID)
    {
        MenuItem? item = OrderedItems.Find(x => x.ItemID == itemID);
        if (item != null)
        {
            OrderedItems.Remove(item);
        }
    }
    public double CalculateSubtotal()
    {
        double subtotal = 0;
        foreach (MenuItem item in OrderedItems)
        {
            subtotal += item.Price;
        }
       return subtotal;
    }
    public double CalculateTotal()
    {
        //10 LOYALTY POINTS Rs.1000 OFF
        double subtotal = CalculateSubtotal();
        double discountAmount = subtotal * Discount / 100;
        double taxAmount = (subtotal - discountAmount) * Tax / 100;
        double total= subtotal - discountAmount + taxAmount;
        if(customer.RedeemLoyaltyPoints())
        {
            Console.WriteLine($"Loyalty Points Redeemed! {customer.LoyaltyPoints} points left!");
            total-=500;
        }
        if (total < 0)
        {
            total=0.0;
        }
        return total;
    }
    public void PayBill()
    {
        double total=CalculateTotal();
        Console.WriteLine($"Amount Paid: Rs.{total}");
        // customer.AddVisits();
    }
    public void DisplayBill()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("\t\tBILL");
        Console.WriteLine("========================================");
        foreach (MenuItem item in OrderedItems)
        {
            Console.WriteLine($"{item.Name,-20} Rs.{item.Price}");
        }
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Subtotal : Rs.{CalculateSubtotal()}");
        Console.WriteLine($"Discount : {Discount}%");
        Console.WriteLine($"Tax      : {Tax}%");
        Console.WriteLine($"Total    : Rs.{CalculateTotal()}");
        Console.WriteLine("========================================");
    }
}