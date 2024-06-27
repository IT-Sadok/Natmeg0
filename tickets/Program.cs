// See https://aka.ms/new-console-template for more information

using ConsoleApp8;

Stadion stadion = new Stadion(2);

while (true)
{
    Console.WriteLine("Write the command you want to choose: Buy or Return a ticket.");
    string command = Console.ReadLine().ToLower();

    switch (command)
    {
        case "buy":
            try
            {
                stadion.BuyTicket();
                Console.WriteLine($"You bought a ticket. Tickets left: {stadion.GetAvailableTickets()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "return":
            try
            {
                stadion.ReturnTicket();
                Console.WriteLine($"Ticket returned. Tickets left: {stadion.GetAvailableTickets()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        default:
            Console.WriteLine("Invalid command. Choose buy or return.");
            break;
    }
}
