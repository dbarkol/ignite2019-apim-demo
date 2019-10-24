using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Location.Api
{
    public static class DeleteLocations
    {
        [FunctionName("DeleteLocations")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "locations")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("DeleteLocations triggered");

            return (ActionResult)new NoContentResult();
        }
    }
}
