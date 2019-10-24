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
    public static class GetLocationById
    {
        [FunctionName("GetLocationById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "locations/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            log.LogInformation("GetLocationById triggered");

            var location = Models.Location.GetLocationById(id);

            if (location == null)
                return (ActionResult)new NotFoundObjectResult($"Location not found.");

            return (ActionResult)new OkObjectResult(location);
        }
    }
}
