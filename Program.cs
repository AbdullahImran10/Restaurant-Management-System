// using System;

// class Program
// {
//     static void Main()
//     {
// //         Menu menu = new Menu();

// //     Console.Write("How many items do you want to add? ");
// //     int n = Convert.ToInt32(Console.ReadLine());

// //     for (int i = 0; i < n; i++)
// // {
// //     Console.WriteLine($"\nEnter details for Item {i + 1}");

// //     Console.Write("Name: ");
// //     string name = Console.ReadLine();

// //     Console.Write("Category (Starter/Main Course/Dessert/Drink): ");
// //     string category = Console.ReadLine().ToUpper();

// //     Console.Write("Price: ");
// //     double price = Convert.ToDouble(Console.ReadLine());

// //     Console.Write("Availability (true/false): ");
// //     bool availability = Convert.ToBoolean(Console.ReadLine());

// //     MenuItem item = new MenuItem(name, category, price, availability);
// //     menu.AddItem(item);
// // }

// // menu.DisplayMenu();
//         Order order=new Order("Abdullah");
//         MenuItem i1=new MenuItem("Abdullah","Dessert",100.0,true);
//         MenuItem i2=new MenuItem("Abdullah","Dessert",100.0,true);
//         MenuItem i3=new MenuItem("Abdullah","Dessert",100.0,true);
//         order.AddItem(i1);
//         order.AddItem(i2);
//         order.AddItem(i3);
//         Console.WriteLine("Total Bill is: "+order.CalculateBill());
//         order.DisplayOrder();
//     }
// }



// using System;

// class Program
// {
//     static void Main()
//     {
//         // Create Restaurant
//         Restaurant restaurant = new Restaurant("Food Paradise");

//         // ================= MENU ITEMS =================
//         MenuItem burger = new MenuItem("Burger", "Main Course", 550, true);
//         MenuItem pizza = new MenuItem("Pizza", "Main Course", 1200, true);
//         MenuItem fries = new MenuItem("Fries", "Starter", 300, true);
//         MenuItem coke = new MenuItem("Coke", "Drink", 150, true);

//         restaurant.AddMenuItem(burger);
//         restaurant.AddMenuItem(pizza);
//         restaurant.AddMenuItem(fries);
//         restaurant.AddMenuItem(coke);

//         Console.WriteLine("========== MENU ==========");
//         restaurant.DisplayMenu();

//         // ================= CUSTOMERS =================
//         Customer c1 = new Customer("Ali", "03001234567");
//         Customer c2 = new Customer("Ahmed", "03111234567");

//         restaurant.AddCustomer(c1);
//         restaurant.AddCustomer(c2);

//         // ================= EMPLOYEES =================
//         Chef chef = new Chef("Usman", 70000, "Italian");

//         Waiter waiter = new Waiter("Hamza", 35000, 5);

//         Manager manager = new Manager("Sarah", 100000, 12, 20000);

//         restaurant.HireEmployee(chef);
//         restaurant.HireEmployee(waiter);
//         restaurant.HireEmployee(manager);

//         Console.WriteLine("\n========== EMPLOYEES ==========");
//         restaurant.DisplayEmployees();

//         // ================= TABLES =================
//         Table table1 = new Table(1, 4);
//         Table table2 = new Table(2, 6);

//         restaurant.AddTable(table1);
//         restaurant.AddTable(table2);

//         Console.WriteLine("\n========== TABLES ==========");
//         restaurant.DisplayTables();

//         // ================= RESERVATION =================
//         Reservation reservation =
//             new Reservation(1, c1, table1, "20-07-2026", "7:30 PM");

//         restaurant.AddReservation(reservation);

//         // ================= ORDER =================
//         Order order1 = new Order(c1.Name);

//         order1.AddItem(burger);
//         order1.AddItem(fries);
//         order1.AddItem(coke);

//         order1.Status = OrderStatus.Completed;

//         restaurant.PlaceOrder(order1);

//         Console.WriteLine("\n========== ORDER ==========");
//         order1.DisplayOrder();

//         // ================= BILL =================
//         Bill bill = new Bill(c1);

//         // Add items if your Bill class has an AddItem() method
//         bill.AddItem(burger);
//         bill.AddItem(fries);
//         bill.AddItem(coke);

//         bill.CalculateTotal();
//         bill.DisplayBill();

//         // ================= REPORTS =================
//         Console.WriteLine("\n========== REPORTS ==========");

//         restaurant.GenerateReports();

//         Console.WriteLine("\nProgram Executed Successfully.");
//     }
// }
using System;

class Program
{
    static void Main()
    {
        Restaurant restaurant = new Restaurant("Food Paradise");

        int choice;

        do
        {
            Console.Clear();

            Console.WriteLine("==================================");
            Console.WriteLine(" RESTAURANT MANAGEMENT SYSTEM");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. Display Menu");
            Console.WriteLine("3. Register Customer");
            Console.WriteLine("4. Hire Employee");
            Console.WriteLine("5. Add Table");
            Console.WriteLine("6. Make Reservation");
            Console.WriteLine("7. Place Order");
            Console.WriteLine("8. Display Orders");
            Console.WriteLine("9. Generate Reports");
            Console.WriteLine("10. Display Employees");
            Console.WriteLine("11. Display Tables");
            Console.WriteLine("12. Clear Menu");
            Console.WriteLine("13. Exit");
            Console.Write("\nEnter Choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (choice)
            {
                case 1:
                {
                    Console.Write("Item Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category (Starter/Main Course/Dessert/Drink): ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = Convert.ToDouble(Console.ReadLine());

                    MenuItem item = new MenuItem(name, category, price, true);

                    restaurant.AddMenuItem(item);

                    Console.WriteLine("Menu Item Added Successfully.");
                    break;
                }

                case 2:
                {
                    restaurant.DisplayMenu();
                    break;
                }

                case 3:
                {
                    Console.Write("Customer Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Phone Number (03XX-XXXXXX): ");
                    string phone = Console.ReadLine();

                    Customer customer = new Customer(name, phone);
                        if (restaurant.AddCustomer(customer))
                        {
                            Console.WriteLine($"Customer {customer.CustomerID} Registered.");
                        }
                        break;
                }

                case 4:
                {
                    Console.WriteLine("1. Chef");
                    Console.WriteLine("2. Waiter");
                    Console.WriteLine("3. Manager");

                    int type = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Salary: ");
                    double salary = Convert.ToDouble(Console.ReadLine());

                    if (type == 1)
                    {
                        Console.Write("Specialty: ");
                        string specialty = Console.ReadLine();

                        restaurant.HireEmployee(new Chef(name, salary, specialty));
                    }
                    else if (type == 2)
                    {
                        Console.Write("Tables Assigned: ");
                        int tables = Convert.ToInt32(Console.ReadLine());

                        restaurant.HireEmployee(new Waiter(name, salary, tables));
                    }
                    else if (type == 3)
                    {
                        Console.Write("Team Size: ");
                        int team = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Bonus: ");
                        double bonus = Convert.ToDouble(Console.ReadLine());

                        restaurant.HireEmployee(new Manager(name, salary, team, bonus));
                    }

                    Console.WriteLine("Employee Added.");
                    break;
                }

                case 5:
                {
                    Console.Write("Table Number: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Capacity: ");
                    int capacity = Convert.ToInt32(Console.ReadLine());

                    restaurant.AddTable(new Table(number, capacity));

                    Console.WriteLine("Table Added.");
                    break;
                }

                case 6:
                {

                    Console.Write("Reservation ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nCustomers:");
                    foreach (Customer c in restaurant.Customers)
                    {
                        Console.WriteLine(c.CustomerID + ". " + c.Name);
                    }

                    Console.Write("Enter Customer ID: ");
                    int customerId = Convert.ToInt32(Console.ReadLine());

                    Customer customer = restaurant.Customers.Find(c => c.CustomerID == customerId);

                    Console.WriteLine("\nTables:");
                    foreach (Table t in restaurant.Tables)
                    {
                        Console.WriteLine("Table " + t.TableNumber + " (Capacity: " + t.Capacity + ")");
                    }

                    Console.Write("Enter Table Number: ");
                    int tableNo = Convert.ToInt32(Console.ReadLine());

                    Table table = restaurant.Tables.Find(t => t.TableNumber == tableNo);

                    Console.Write("Enter Date (dd-MM-yyyy): ");
                        string date = Console.ReadLine();

                        Console.Write("Enter Time (HH:mm): ");
                        string time = Console.ReadLine();

                        DateTime reservationDateTime = DateTime.ParseExact(
                            date + " " + time,
                            "dd-MM-yyyy HH:mm",
                            null);

                        Reservation reservation = new Reservation(
                            id,
                            customer,
                            table,
                            reservationDateTime
                        );

                        restaurant.AddReservation(reservation);

                    break;
                }

                case 7:
                    {
                        Console.Write("Customer Name: ");
                        string customerName = Console.ReadLine().ToUpper();

                        Customer customer = null;

                        foreach (Customer c in restaurant.Customers)
                        {
                            if (c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase))
                            {
                                customer = c;
                                break;
                            }
                        }
                        // Console.WriteLine($"Hi! {}")

                        if (customer == null)
                        {
                            Console.WriteLine("Customer not found! Please register the customer first.");
                            break;
                        }

                        Order order = new Order(customer);

                        char ch;

                        do
                        {
                        restaurant.DisplayMenu();

                        Console.Write("\nEnter Item ID: ");
                        string id = Console.ReadLine();
                        id=id.ToUpper();

                       MenuItem item = restaurant.Menu.SearchItem(id);
                        if (item != null)
                        {
                            order.AddItem(item);
                            Console.WriteLine("Item Added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Item ID.");
                        }

                        Console.Write("Add another item? (Y/N): ");
                        ch = Convert.ToChar(Console.ReadLine().ToUpper());

                    } while (ch == 'Y');

                    order.Status = OrderStatus.Completed;

                    restaurant.PlaceOrder(order);

                    Console.WriteLine("\nOrder Placed Successfully!");
                    order.DisplayOrder();
                        Bill bill = new Bill(customer);

                        // Copy all ordered items into bill
                        foreach (MenuItem item in order.Items)
                        {
                            bill.AddItem(item);
                        }

                        // Optional
                        bill.Discount = 0;
                        bill.Tax = 5;

                        // Display final bill (this applies loyalty discount)
                        bill.DisplayBill();


                        break;
                }

                case 8:
                {
                    restaurant.DisplayOrders();
                    break;
                }

                case 9:
                {
                    restaurant.GenerateReports();
                    break;
                }

                case 10:
                {
                    restaurant.DisplayEmployees();
                    break;
                }

                case 11:
                {
                    restaurant.DisplayTables();
                    break;
                }

                case 12:
                {
                    restaurant.Menu.DeleteAllMenu();
                    break;
                }
                case 13:
                {
                        Console.WriteLine("Thanks you for using RMS !");
                        break;
                }

                default:
                {
                    Console.WriteLine("Invalid Choice.");
                    break;
                }
            }

            if (choice != 13)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

        } while (choice != 13);
    }
}


