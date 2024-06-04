// See https://aka.ms/new-console-template for more information

using System;

int allTickets = 10000;
int soldTickets = 0;
void BuyTicket()
{
    if (soldTickets < allTickets)
    {
        soldTickets += 1;
        Console.WriteLine($"You bought a ticket. Tickets left: {allTickets - soldTickets}");
    }
    else
    {
        Console.WriteLine("You can't buy a ticket, tickets are out");
    }


}
void ReturnTicket()
{
    if (soldTickets < allTickets)
    {
        Console.WriteLine("You can't return a ticket.");
    }



}
BuyTicket();
ReturnTicket();