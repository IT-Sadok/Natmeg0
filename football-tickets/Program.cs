﻿// See https://aka.ms/new-console-template for more information
using ConsoleApp7;

Stadium stadium = new Stadium(10000);

while (true)
{
    Console.WriteLine("Write the command you want to choose: Buy ticket or Return ticket");
    string command = Console.ReadLine();

    switch (command)
    {
        case "buy":
            if (stadium.BuyTicket())
            {
                Console.WriteLine($"You bought a ticket. Tickets left:{stadium.GetAvailableTickets()}");
            }
            else
            {
                Console.WriteLine("You can't buy a ticket. Tickets are out");
            }
            break;

        case "return":
            if (stadium.ReturnTicket())
            {
                Console.WriteLine("You can't return a ticket.");
            }
            else
            {
                Console.WriteLine($"Ticket returned. Tickets left: {stadium.GetAvailableTickets()}");
            }
            break;
    }
}

