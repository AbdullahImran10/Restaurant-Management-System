
using System;

public class Reservation
{
    public int ReservationID { get; set; }
    public Customer Customer { get; set; }
    public Table Table { get; set; }
   public DateTime ReservationDateTime { get; set; }

    public Reservation(int reservationID, Customer customer, Table table, DateTime reservationDateTime)
    {
        ReservationID = reservationID;
        Customer = customer;
        Table = table;
       ReservationDateTime = reservationDateTime;
    }

    public void BookReservation()
    {
        if (!Table.IsOccupied)
        {
            Table.Reserve(this);

            Console.WriteLine("\nReservation Booked Successfully!");
            Console.WriteLine("Reservation ID: " + ReservationID);
            Console.WriteLine("Customer: " + Customer.Name);
            Console.WriteLine("Table Number: " + Table.TableNumber);
            Console.WriteLine("Reservation Date: " +
            ReservationDateTime.ToString("dd-MM-yyyy"));
            Console.WriteLine("Reservation Time: " +
            ReservationDateTime.ToString("hh:mm tt"));
        }
        else
        {
            Console.WriteLine("Cannot book reservation. Table is already occupied.");
        }
    }

    public void CancelReservation()
    {
        if (Table.CurrentReservation == this)
        {
            Table.FreeTable();
            Console.WriteLine("Reservation cancelled successfully.");
        }
        else
        {
            Console.WriteLine("This reservation is not active.");
        }
    }
}

