using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Tickets.Startup))]

namespace Tickets
{
    public class Startup : FunctionsStartup
    {            
        public override void Configure(IFunctionsHostBuilder builder)
        {                    
            // Add a singleton instance of the tickets service class.
            builder.Services.AddSingleton<ITicketsService>(new TicketsService()); 
        }
    }
}