using System;
using System.Collections.Generic;
public class Menu
{
    private List<MenuItem> menuItems;
    public Menu()
    {
        menuItems=new List<MenuItem>();
        AddItem(new MenuItem("Pizza","main course",2000,true));
        AddItem(new MenuItem("Burger","main course",1650,true));
        AddItem(new MenuItem("Lemonade","drink",2000,true));
        AddItem(new MenuItem("Shwarma","main course",450,true));
        AddItem(new MenuItem("Cake","dessert",1100,true));
        AddItem(new MenuItem("Fries","Starter",2000,true));

    }
    public void AddItem(MenuItem item)
    {
        menuItems.Add(item);
        Console.WriteLine($"Item {item.ItemID} Added Succesfully!");
    }
   public void RemoveItem(MenuItem item)
{
    if (menuItems.Remove(item))
    {
        Console.WriteLine("Item Removed Successfully");
    }
    else
    {
        Console.WriteLine("Item Not Found!");
    }
}
      public void UpdatePrice(string itemID, double newPrice)
    {
        MenuItem  item = menuItems.Find(x => x.ItemID == itemID);

        if (item != null)
        {
            item.Price = newPrice;
            Console.WriteLine("Price updated successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
     public MenuItem  SearchItem(string itemID)
    {
        return menuItems.Find(x => x.ItemID == itemID);
    }
    public void DisplayMenu()
{
    if (menuItems.Count == 0)
    {
        Console.WriteLine("Menu is empty.");
        return;
    }

    Console.WriteLine("==========================================");
    Console.WriteLine("\t\tRESTAURANT MENU");
    Console.WriteLine("==========================================");

    string[] categories = { "STARTER", "MAIN COURSE", "DESSERT", "DRINK" };

    foreach (string category in categories)
    {
        Console.WriteLine($"\n----- {category} -----");

        bool found = false;

        foreach (MenuItem item in menuItems)
        {
            if (item.Category == category)
            {
                Console.WriteLine(
                    $"{item.ItemID,-6} {item.Name,-20} Rs.{item.Price,-8} {(item.Availability ? "Available" : "Not Available")}"
                );
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No items available.");
        }
    }

    Console.WriteLine("==========================================");
}
public void DeleteAllMenu()
{
    if (menuItems.Count == 0)
    {
        Console.WriteLine("Menu is already empty.");
        return;
    }

    menuItems.Clear();
    Console.WriteLine("All menu items have been deleted successfully.");
}

}