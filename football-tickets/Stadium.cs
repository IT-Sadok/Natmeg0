using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Stadium
    {
        private int _allTickets;
        private int _soldTickets;

        public Stadium(int totalTickets)
        {
            _allTickets = totalTickets;
            _soldTickets = 0;
        }
        public bool BuyTicket()
        {
            if (_soldTickets < _allTickets)
            {
                _soldTickets += 1;
                return true;
            }
            return false;
        }

        public bool ReturnTicket()
        {
            if (_soldTickets > 0)
            {
                _soldTickets -= 1;
                return true;
            }
            return false;
        }
        public int GetAvailableTickets()
        {
            return _allTickets - _soldTickets;
        }
    }
}
