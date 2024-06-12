using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Stadium
    {
        private int _maxSeats;
        private int _reservedSeats;

        public Stadium(int totalTickets)
        {
            _maxSeats = totalTickets;
            _reservedSeats = 0;
        }
        public bool BuyTicket()
        {
            if (_reservedSeats < _maxSeats)
            {
                _reservedSeats += 1;
                return true;
            }
            return false;
        }

        public bool ReturnTicket()
        {
            if (_reservedSeats > 0)
            {
                _reservedSeats -= 1;
                return true;
            }
            return false;
        }
        public int GetAvailableTickets()
        {
            return _maxSeats - _reservedSeats;
        }
    }
}
