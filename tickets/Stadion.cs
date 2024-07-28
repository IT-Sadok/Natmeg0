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
        
        public Stadion(int totalTickets)
        {
            _maxSeats = totalTickets;
            _tickets = new Dictionary<Guid, Ticket>();
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

        public void ReturnTicket(Guid TicketID)
        {
            if (!_tickets.ContainsKey(TicketID))
            {
                throw new InvalidOperationException("Ticket with this ID not found");     
            }
            _tickets.Remove(TicketID);
            
        }

        
        public int GetAvailableTickets()
        {
            return _maxSeats - _tickets.Count;
        }

        public List<Ticket> Search(DateTime startDate, DateTime endDate)
        {
            return _tickets.Values
                 .Where( t => t.DateCreated >= startDate && t.DateCreated <= endDate)
                 .ToList();
        }

        public Ticket? Recent()
        {
            return _tickets.Values
                .OrderByDescending(t => t.DateCreated)
                .FirstOrDefault();
        }
    }
}
