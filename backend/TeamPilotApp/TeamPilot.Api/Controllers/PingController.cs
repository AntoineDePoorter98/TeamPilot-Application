using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.test;

namespace TeamPilot.Api.Controllers
{

    [ApiController]
    [Route("tests")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<PingDTO> GetPing()
        {
            var ticks = DateTime.Now.Ticks.ToString();
            Console.WriteLine("PingController.GetPing");
            return new PingDTO
            {
                PingResponse = "Pong " + ticks
            };
        }
    }
}
