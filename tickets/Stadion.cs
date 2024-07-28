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
        private SemaphoreSlim _buysemaphore = new SemaphoreSlim(2);
        private SemaphoreSlim _returnsemaphore = new SemaphoreSlim(2);
        public Stadion(int totalTickets)
        {
            _maxSeats = totalTickets;
            _tickets = new Dictionary<Guid, Ticket>();
        }
        public async Task<Ticket> BuyTicketAsync()
        {
            await _buysemaphore.WaitAsync();
            try
            {
                await Task.Delay(2000);

                if (_tickets.Count >= _maxSeats)
                {
                    throw new InvalidOperationException("Tickets are out");
                }
              
                Ticket newTicket = new Ticket();
                _tickets.Add(newTicket.ID, newTicket);
                return newTicket;
            }
            finally
            {
                _buysemaphore.Release();
            }   
        }

        public async Task ReturnTicketAsync(Guid TicketID)
        {
            await _returnsemaphore.WaitAsync();

            try
            {
                await Task.Delay(1000);

                if (!_tickets.ContainsKey(TicketID))
                {
                    throw new InvalidOperationException("Ticket with this ID not found");
                }
                _tickets.Remove(TicketID);
            }
            finally
            {
                _returnsemaphore.Release();
            }    
        }

        public async Task UpdateTicketAsync(Guid TicketID)
        {
            await Task.Delay(2000);

            if(_tickets.TryGetValue(TicketID, out Ticket? ticket))
            {
                ticket.DateCreated = DateTime.UtcNow;
            }
            else
            {
                throw new InvalidOperationException("Ticket not found");
            }
        }

        public async Task UpdateTicketAsync()
        {
            var tasks = _tickets.Keys.Select(UpdateTicketAsync);
            await Task.WhenAll(tasks);
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
