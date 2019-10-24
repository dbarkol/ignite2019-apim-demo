using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Location.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Location.Api
{
    public static class GetLocations
    {
        [FunctionName("GetLocations")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "locations")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetLocations triggered");

            // Simulate a slow response - TESTING ONLY
            //System.Threading.Thread.Sleep(500);

            var locations = Models.Location.GetAllLocations();

            return (ActionResult)new OkObjectResult(locations);
        }
    }
}

