using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;
using Kobold.TodoApp.Api.ViewModels;
using System.Linq.Expressions;

namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly ITodoService _todoService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
        {
            try
            {
                var todos = await _todoService.GetTodosAsync();
                
                if (todos == null)
                    return NotFound("Não existem tarefas cadastradas.");
                return Ok(todos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetById(int id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);

                if (todo == null)
                    return NotFound("Tarefa não encontrada.");
                return Ok(todo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodo([FromBody] TodoViewModel todovm)
        {
            try
            {
                await _todoService.CreateTodoAsync(todovm);
                return Ok(todovm);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar tarefa: " + e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoViewModel>> Update([FromRoute] int id, [FromBody] TodoViewModel todovm)
        {
            try
            {
                await _todoService.UpdateTodoAsync(id, todovm);
                return Ok($"A tarefa de id {id} foi atualizada.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

   

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoViewModel>> Delete(int id)
        {
            try
            {
                await _todoService.DeleteTodoAsync(id);
                return Ok($"A Tarefa de id {id} foi deletada.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
