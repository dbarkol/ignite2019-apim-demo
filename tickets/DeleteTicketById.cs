using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Tickets
{
    public class DeleteTicketById
    {
        // Local instance of the tickets service implementation
        private readonly ITicketsService _ticketsService;

        public DeleteTicketById(ITicketsService ticketsService)
        {
            // ITicketsService is injected into the 
            // class and saved for future reference.
            _ticketsService = ticketsService;
        }

        [FunctionName("DeleteTicketById")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "tickets/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            log.LogInformation("DeleteTicketById triggered");

            // Delete a ticket with the passed in ID
            _ticketsService.DeleteTicketById(id);

            return (ActionResult)new NoContentResult();
        }
    }
}
