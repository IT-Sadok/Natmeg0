using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Stadion
    {
        private int _maxSeats;
        private Dictionary<Guid, Ticket> _tickets;
        private List<Guid> _returnRequests;

        public Stadion(int totalTickets)
        {
            _maxSeats = totalTickets;
            _tickets = new Dictionary<Guid, Ticket>();
            _returnRequests = new List<Guid>();
        }
        public Ticket BuyTicket()
        {
            if (_tickets.Count >= _maxSeats)
            {
                throw new InvalidOperationException("Tickets are out");
            }

            Ticket newTicket = new Ticket();
            _tickets.Add(newTicket.ID, newTicket);
            return newTicket;
        }

        public void RequestReturnTicket(Guid TicketID)
        {
            if (!_tickets.ContainsKey(TicketID))
            {
                throw new InvalidOperationException("Ticket with this ID not found");     
            }
            _returnRequests.Add(TicketID);
        }

        public void ProcessReturnRequests()
        {
            foreach (var TicketID in _returnRequests)
            {
                if (_tickets.ContainsKey(TicketID))
                {
                    Console.WriteLine($"Ticket with ID:{TicketID} has been returned. Tickets left:{GetAvailableTickets}");
                }
                
            }
        }
        public int GetAvailableTickets()
        {
            return _maxSeats - _tickets.Count;
        }

        public List<Ticket> SearchTicketByDateRange(DateTime startDate, DateTime endDate)
        {
            var ticketsInRange = (from Ticket in _tickets.Values
                                  where Ticket.DateCreated >= startDate && Ticket.DateCreated <= endDate
                                  select Ticket).ToList();

            return ticketsInRange;
        }

        public Ticket? GetRecentTicket()
        {
            var recentTicket = (from Ticket in _tickets.Values
                                orderby Ticket.DateCreated descending
                                select Ticket).FirstOrDefault();
            return recentTicket;
        }
    }
}
