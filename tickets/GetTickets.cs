using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Tickets
{
    public class GetTickets
    {
        // Local instance of the tickets service implementation
        private readonly ITicketsService _ticketsService;

        public GetTickets(ITicketsService ticketsService)
        {
            // ITicketsService is injected into the GetTickets
            // class and saved for future reference.
            _ticketsService = ticketsService;
        }

        [FunctionName("GetTickets")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "tickets")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetTickets triggered");

            // Retrieve all the records from the tickets service.
            var tickets = _ticketsService.GetAllTickets();

            // Return the list of tickets to the client.            
            return (ActionResult)new OkObjectResult(tickets);
        }
    }
}
