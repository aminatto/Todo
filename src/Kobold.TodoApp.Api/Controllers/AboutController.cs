using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AboutController : ControllerBase
    {

        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            return new {
                Nome = "Kobold.TodoApp.Api",
                Versao = "1.0.0"
            };
        }

    }
}
