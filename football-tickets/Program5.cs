// See https://aka.ms/new-console-template for more information

using ConsoleApp5;

Stadium stadium = new Stadium(10000);

if (stadium.BuyTicket())
{
    Console.WriteLine($"You bought a ticket. Tickets left:{stadium.GetAvailableTickets()}");
}
else
{
    Console.WriteLine("You can't buy a ticket. Tickets are out");
}


if (stadium.ReturnTicket())
{
    Console.WriteLine("You can't return a ticket.");
}
else
{
    Console.WriteLine($"Ticket returned. Tickets left: {stadium.GetAvailableTickets()}");
}