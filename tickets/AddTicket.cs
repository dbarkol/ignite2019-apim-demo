using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tickets.Models;

namespace Tickets
{
    public class AddTicket
    {
        // Local instance of the tickets service implementation
        private readonly ITicketsService _ticketsService;

        public AddTicket(ITicketsService ticketsService)
        {
            // ITicketsService is injected into the 
            // class and saved for future reference.
            _ticketsService = ticketsService;
        }

        [FunctionName("AddTicket")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "tickets")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("AddTicket triggered");

            // Read the message body from the incoming request
            var requestBody = new StreamReader(req.Body).ReadToEnd();
            
            // Deserialize the body to a ticket object
            var ticket = JsonConvert.DeserializeObject<Ticket>(requestBody);

            // Add the ticket
            _ticketsService.AddTicket(ticket);

            return (ActionResult)new OkObjectResult($"Success");
        }
    }
}
