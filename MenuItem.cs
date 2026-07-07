using System;
using System.Collections.Generic;
public class MenuItem
{
     private static int starterCount = 0;
    private static int mainCourseCount = 0;
    private static int dessertCount = 0;
    private static int drinkCount = 0;
    public string ItemID{get;}
    public string Name{get;set;}
    public string Category{get; set;}
    private double price;
    public double Price
    {
        get{return price;}
        set
        {
            if(value<0)
            price=0;
            else
            price=value;
        }
    }
    public bool Availability{get; set;}

    public MenuItem()
    {
        Name="";
        Category="";
        Price=0.0;
        Availability=false;
        ItemID="UNASSIGNED";
    }
    public MenuItem(string name, string category , double price, bool availability)
    {
        Name=name.ToUpper();
        Category=category.Trim().ToUpper();
        this.Price=price;
        this.Availability=availability;
        switch (Category)
        {
            case "STARTER":
            ItemID="S"+(++starterCount).ToString("D3");
            break;

            case "MAIN COURSE":
            ItemID="M"+(++mainCourseCount).ToString("D3");
            break;

            case "DESSERT":
            ItemID="D"+(++dessertCount).ToString("D3");
            break;

            case "DRINK":
            ItemID="DR"+(++drinkCount).ToString("D3");
            break;

            default:
            ItemID="XXXXXXXXX";
            break;        
        }
      
    }
    public void UpdatePrice(double newPrice)
{
    if (newPrice > 0)
        Price = newPrice;
}
public void SetAvailability(bool available)
{
    Availability = available;
}
   public void DisplayItem()
{
    Console.WriteLine("======================================");
    Console.WriteLine("\t\tMenu Item");
    Console.WriteLine("======================================");
    Console.WriteLine($"Item ID      : {ItemID}");
    Console.WriteLine($"Name         : {Name}");
    Console.WriteLine($"Category     : {Category}");
    Console.WriteLine($"Price        : Rs. {Price}");
    Console.WriteLine($"Availability : {(Availability ? "Available" : "Not Available")}");
    Console.WriteLine("======================================");
}
}