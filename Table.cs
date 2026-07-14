
using System;

public class Table
{
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsOccupied { get; set; }

    // Reference to the current reservation
    public Reservation CurrentReservation { get; set; }

    public Table(int tableNumber, int capacity)
    {
        TableNumber = tableNumber;
        Capacity = capacity;
        IsOccupied = false;
        CurrentReservation = null;
    }

    public void Reserve(Reservation reservation)
    {
        if (!IsOccupied)
        {
            IsOccupied = true;
            CurrentReservation = reservation;
            Console.WriteLine("Table " + TableNumber + " reserved successfully.");
        }
        else
        {
            Console.WriteLine("Table " + TableNumber + " is already occupied.");
        }
    }

    public void FreeTable()
    {
        if (IsOccupied)
        {
            IsOccupied = false;
            CurrentReservation = null;
            Console.WriteLine("Table " + TableNumber + " is now available.");
        }
        else
        {
            Console.WriteLine("Table " + TableNumber + " is already free.");
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Table Number: " + TableNumber);
        Console.WriteLine("Capacity: " + Capacity);
        Console.WriteLine("Status: " + (IsOccupied ? "Occupied" : "Available"));

        if (CurrentReservation != null)
        {
            Console.WriteLine("Reserved By: " + CurrentReservation.Customer.Name);
            Console.WriteLine("Reservation ID: " + CurrentReservation.ReservationID);
        }
    }
}