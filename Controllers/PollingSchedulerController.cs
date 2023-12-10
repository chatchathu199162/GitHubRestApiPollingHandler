using Microsoft.AspNetCore.Mvc;

namespace PollingScheduler.Controllers
{
    [ApiController]
    [Route("/")]
    public class PollingSchedulerController : Controller
    {
        [HttpGet,Route("/status/ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }

        [HttpGet, Route("/status/Health")]
        public IActionResult Health()
        {
            return Ok("Healthy");
        }
    }
}
