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
        Queue<Guid> _returnQueue;

        public Stadion(int totalTickets)
        {
            _maxSeats = totalTickets;
            _tickets = new Dictionary<Guid, Ticket>();
            _returnQueue = new Queue<Guid>();
        }
        public void BuyTicket()
        {
            if (_tickets.Count >= _maxSeats)
            {
                throw new InvalidOperationException("Tickets are out");
            }

            Ticket newTicket = new Ticket();
            _tickets.Add(newTicket.ID, newTicket);
        }

        public void RequestReturnTicket(Guid TicketID)
        {
            if (!_tickets.ContainsKey(TicketID))
            {
                throw new InvalidOperationException("Ticket with this ID not found");     
            }
            _returnQueue.Enqueue(TicketID);
            Console.WriteLine($"A request to return a ticket with ID: {TicketID} has been added to the queue.");
        }

        public void ProcessReturnRequests()
        {
            while(_returnQueue.Count > 0)
            {
                Guid TicketID = _returnQueue.Dequeue();
                _tickets.Remove(TicketID);
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
