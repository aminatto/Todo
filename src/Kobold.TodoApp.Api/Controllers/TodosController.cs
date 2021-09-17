using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;

namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly TodoService _todoService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
            _todoService = new TodoService();
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoService.Get();
        }

        [HttpPost]
        public Todo Create([FromBody] TodoViewModel todovm)
        {
            return _todoService.Create(todovm);
        }

        [HttpPut("{id}")]
        public Todo Update([FromRoute] int id, [FromBody] TodoViewModel todovm)
        {
            return _todoService.Update(id, todovm);
        }

        [HttpGet("{id}")]
        public Todo Get([FromRoute] int id)
        {
            return _todoService.Get(id);
        }

        [HttpDelete("{id}")]
        public void Remove([FromRoute] int id)
        {
            _todoService.Remove(id);
        }

    }
}
