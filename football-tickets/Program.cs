// See https://aka.ms/new-console-template for more information

using ConsoleApp8;

Stadion stadion = new Stadion(10000);

while (true)
{
    Console.WriteLine("Write the command you want to choose: Buy or Return a ticket");
    string command = Console.ReadLine();

    switch (command)
    {
        case "buy":
            if (stadion.BuyTicket())
            {
                Console.WriteLine($"You bought a ticket. Tickets left:{stadion.GetAvailableTickets()}");
            }
            else
            {
                Console.WriteLine("You can't buy a ticket. Tickets are out");
            }
            break;

        case "return":
            if (stadion.ReturnTicket())
            {
                Console.WriteLine("You can't return a ticket.");
            }
            else
            {
                Console.WriteLine($"Ticket returned. Tickets left: {stadion.GetAvailableTickets()}");

            }
            break;
    }
}