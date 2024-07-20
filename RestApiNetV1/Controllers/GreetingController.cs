using Microsoft.AspNetCore.Mvc;

namespace RestApiNetV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        // POST api/Greeting
        [HttpPost]
        public string PostGreeting([FromBody] string value)
        {
            var response = $"Hello! You have sent me: {value}";
            return response;
            //return Content(response, "text/plain");
        }
    }
}
