using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Tickets
{
    public class DeleteTickets
    {
        // Local instance of the tickets service implementation
        private readonly ITicketsService _ticketsService;

        public DeleteTickets(ITicketsService ticketsService)
        {
            // ITicketsService is injected into the 
            // class and saved for future reference.
            _ticketsService = ticketsService;
        }

        [FunctionName("DeleteTickets")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "tickets")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("DeleteTickets triggered");        

            // Delete all the tickets
            _ticketsService.DeleteTickets();

            return (ActionResult)new NoContentResult();
        }
    }
}
