using Microsoft.AspNetCore.Mvc;

namespace PracticalSixteen.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Return string message
        /// </summary>
        /// <returns>Hello World</returns>
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("{0} method of {1}Controller is invoked.", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName);
            return "Hello World!!";
        }

        /// <summary>
        /// Return greeting message
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Greet()
        {
            var hour = DateTime.Now.Hour;
            if (hour < 12) return "Good morning!!";
            else if (hour < 18) return "Good afternoon!!";
            else return "Good evening!!";
        }
    }
}