using System.Collections.Generic;
using System.Linq;
using Tickets.Models;

namespace Tickets
{
    public class TicketsService : ITicketsService
    {
        public List<Ticket> GetAllTickets()
        {
            var tickets = new List<Ticket>{
                new Ticket{
                    Id = 1,
                    Description = "description1",
                    Impact = "impact1",
                    ProductLine = "product line 1",
                    Title = "title1"
                },
                new Ticket{
                    Id = 2,
                    Description = "description2",
                    Impact = "impact2",
                    ProductLine = "product line 2",
                    Title = "title2"
                },                
            };

            return tickets;
        }

        public Ticket GetTicketById(int id)
        {
            var tickets = GetAllTickets();
            var t = tickets.Where(x => x.Id == id).ToList();
            return t.FirstOrDefault();
        }

        public void DeleteTickets()
        {
            // TODO: Implement
        }

        public void DeleteTicketById(int id)
        {
            // TODO: Implement
        }

        public void AddTicket(Ticket ticket)
        {
            // TODO: Implement
        }
    }
}