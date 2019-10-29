using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Tickets
{
    public class GetTicketById
    {
        // Local instance of the tickets service implementation
        private readonly ITicketsService _ticketsService;

        public GetTicketById(ITicketsService ticketsService)
        {
            // ITicketsService is injected into the GetTicketById
            // class and saved for future reference.
            _ticketsService = ticketsService;
        }

        [FunctionName("GetTicketById")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "tickets/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            log.LogInformation("GetTicketById triggered");

            // Look up the ticket with the passed in ID parameter.
            var ticket = _ticketsService.GetTicketById(id);

            // Return a not found (404) status code if the ticket
            // is not available.
            if (ticket == null)
                return (ActionResult)new NotFoundObjectResult($"Ticket not found.");

            // Return the ticket
            return (ActionResult)new OkObjectResult(ticket);
        }
    }
}
