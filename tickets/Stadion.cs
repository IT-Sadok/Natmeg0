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
        private int _reservedSeats;

        public Stadion(int totalTickets)
        {
            _maxSeats = totalTickets;
            _reservedSeats = 0;
        }
        public void BuyTicket()
        {
            if (_reservedSeats >= _maxSeats)
            {
                throw new InvalidOperationException("Tickets are out");   
            }
            _reservedSeats += 1;
        }

        public void ReturnTicket()
        {
            if (_reservedSeats <= 0)
            {
                throw new InvalidOperationException("No tickets to return");     
            }
            _reservedSeats -= 1;
        }
        public int GetAvailableTickets()
        {
            return _maxSeats - _reservedSeats;
        }
    }
}
