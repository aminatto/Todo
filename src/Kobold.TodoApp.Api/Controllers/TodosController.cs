using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;

namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Todo Create([FromBody] TodoViewModel todovm)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Todo Update([FromRoute] int id, [FromBody] TodoViewModel todovm)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Todo Get([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Remove([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

    }
}
