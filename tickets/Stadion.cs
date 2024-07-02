using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Stadion
{
    private int _maxSeats;
    private List<Ticket> _tickets;
    private FileManager<Ticket> _fileManager;

    public Stadion(int totalTickets)
    {
        _maxSeats = totalTickets;
        _fileManager = new FileManager<Ticket>();
        
    }

    public void BuyTicket()
    {
        if (_tickets.Count >= _maxSeats)
        {
            throw new InvalidOperationException("Tickets are out");
        }
        _tickets.Add(new Ticket());
        _fileManager.Save(_tickets); 
    }

    public void ReturnTicket()
    {
        if (_tickets.Count <= 0)
        {
            throw new InvalidOperationException("No tickets to return");
        }
        _tickets.RemoveAt(0);
        _fileManager.Save(_tickets); 
    }

    public int GetAvailableTickets()
    {
        return _maxSeats - _tickets.Count;
    }
}
