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
    }
}
