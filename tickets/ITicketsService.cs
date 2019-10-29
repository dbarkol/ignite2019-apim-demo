using System.Collections.Generic;
using Tickets.Models;

namespace Tickets
{
    public interface ITicketsService
    {
        List<Ticket> GetAllTickets();

        Ticket GetTicketById(int id);

        void DeleteTickets();

        void DeleteTicketById(int id);

        void AddTicket(Ticket ticket);
    }
}