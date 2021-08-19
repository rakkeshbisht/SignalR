using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace SignalrSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IHubContext<InformHub, IHubClient> _informHub;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IHubContext<InformHub, IHubClient> hubContext,ILogger<WeatherForecastController> logger)
        {
            _informHub = hubContext;
            _logger = logger;
        }
        
       
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _informHub.Clients.All.InformClient(value);
        }
    }

    public interface IHubClient
    {
        Task InformClient(string message);
    }

    public class InformHub : Hub<IHubClient>
    {

    }
}
