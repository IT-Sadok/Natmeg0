// See https://aka.ms/new-console-template for more information

using ConsoleApp8;

Stadion stadion = new Stadion(2);

while (true)
{
    Console.WriteLine("Write the command you want to choose: buy, return, recent or search a ticket.");
    string command = Console.ReadLine().ToLower();

    switch (command)
    {
        case "buy":
            try
            {
                Ticket buyTicket = stadion.BuyTicket();
                Console.WriteLine($"You bought a ticket, ID:{buyTicket.ID} Tickets left: {stadion.GetAvailableTickets()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "return":
            Console.WriteLine("Write the ID to return the Ticket");
            string idInput = Console.ReadLine().ToLower();
            if (Guid.TryParse(idInput, out Guid TicketID))
            {
                try
                {
                    stadion.ReturnTicket(TicketID);
                    Console.WriteLine($"Ticket with ID:{TicketID} has been returned. Tickets left:{stadion.GetAvailableTickets}");
                }

                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Wrong ID");
            }
            break;

        case "search":
            Console.WriteLine("Write start date(dd-mm-yy)");
            string startDateInput = Console.ReadLine().ToLower();
            Console.WriteLine("Write end date(dd-mm-yy)");
            string endDateInput = Console.ReadLine().ToLower();

            if(DateTime.TryParse(startDateInput, out DateTime startDate) && DateTime.TryParse(endDateInput, out DateTime endDate))
            {
                var tickets = stadion.Search(startDate, endDate);
                if (tickets.Count > 0)
                {
                    Console.WriteLine("Tickets found:");
                    foreach (var Ticket in tickets)
                    {
                        Console.WriteLine($"ID: {Ticket.ID}, Created date:{Ticket.DateCreated}");    
                    }
                }
                else
                {
                    Console.WriteLine("\"There are no tickets available in the specified date range");
                }
            }
            else
            {
                Console.WriteLine("Incorrect dates.");
            }
            break;
        case "recent":
            var mostRecentTicket = stadion.Recent();
            if (mostRecentTicket != null)
            {
                Console.WriteLine($"The most recent ticket - ID:{mostRecentTicket.ID},  Created date:{mostRecentTicket.DateCreated}");
            }
            else
            {
                Console.WriteLine("No tickets purchased.");
            }
            break;

        default:
            Console.WriteLine("Invalid command. Choose buy, return, recent or search.");
            break;
    }
}
    

