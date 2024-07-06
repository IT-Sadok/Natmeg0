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
        private List<Ticket> _tickets;

        public Stadion(int totalTickets)
        {
            _maxSeats = totalTickets;
            _tickets = new List<Ticket>();
        }
        public void BuyTicket()
        {
            if (_tickets.Count >= _maxSeats)
            {
                throw new InvalidOperationException("Tickets are out");   
            }
            _tickets.Add(new Ticket());    
        }

        public void ReturnTicket()
        {
            if (_tickets.Count <= 0)
            {
                throw new InvalidOperationException("No tickets to return");     
            }
            _tickets.RemoveAt(0);
        }
        public int GetAvailableTickets()
        {
            return _maxSeats - _tickets.Count;
        }
    }
}
