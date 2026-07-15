
using System;
using System.Collections.Generic;

public class Report
{
    public void TotalSales(List<Order> orders)
    {
        double sales = 0;

        foreach (Order order in orders)
        {
            if (order.Status == OrderStatus.Completed)
            {
                sales += order.TotalBill;
            }
        }

        Console.WriteLine("Total Sales: Rs. " + sales);
    }

    public void TodaysOrders(List<Order> orders)
    {
        Console.WriteLine("Today's Orders:");

        foreach (Order order in orders)
        {
            if (order.OrderDate.Date == DateTime.Today)
            {
                Console.WriteLine(order.OrderID + " - " + order.Customer);
            }
        }
    }

    public void MostOrderedItem(List<Order> orders)
    {
        Dictionary<string, int> itemCount = new Dictionary<string, int>();

        foreach (Order order in orders)
        {
            foreach (MenuItem item in order.Items)
            {
                if (itemCount.ContainsKey(item.Name))
                    itemCount[item.Name]++;
                else
                    itemCount[item.Name] = 1;
            }
        }

        string itemName = "";
        int max = 0;

        foreach (var item in itemCount)
        {
            if (item.Value > max)
            {
                max = item.Value;
                itemName = item.Key;
            }
        }

        Console.WriteLine("Most Ordered Item: " + itemName);
    }
public void NumberOfCustomers(List<Customer> customers)
{
    Console.WriteLine("Number of Customers: " + customers.Count);
}
   

    public void PendingOrders(List<Order> orders)
    {
        Console.WriteLine("Pending Orders:");

        foreach (Order order in orders)
        {
            if (order.Status == OrderStatus.Pending)
            {
                Console.WriteLine(order.OrderID + " - " + order.Customer);
            }
        }
    }
}

