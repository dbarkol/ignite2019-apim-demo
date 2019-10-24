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
    public static class AddLocation
    {
        [FunctionName("AddLocation")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "locations")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("AddLocation triggered");

            return (ActionResult)new OkObjectResult($"");
        }
    }
}
