using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;
using Kobold.TodoApp.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kobold.TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosCollectionController : ControllerBase
    {
        private readonly ITodoCollectionService _todoCollectionService;
        private readonly ILogger<TodosController> _logger;

        public TodosCollectionController(ILogger<TodosController> logger, ITodoCollectionService todoCollectionService)
        {
            _logger = logger;
            _todoCollectionService = todoCollectionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoCollectionViewModel>>> GetAll()
        {
            try
            {
                var todoCollections = await _todoCollectionService.GetTodoCollectionsAsync();
                if (todoCollections == null)
                    return NotFound("Não existem coleções cadastradas.");

                return Ok(todoCollections);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoCollection>> GetById(int id)
        {
            try
            {
                var todoCollection = await _todoCollectionService.GetTodoCollectionByIdAsync(id);
                if (todoCollection == null)
                    return NotFound("Coleção não encontrada.");

                return Ok(todoCollection);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodoCollection([FromBody] TodoCollectionViewModel todoCollectionViewModel)
        {
            try
            {
                await _todoCollectionService.CreateTodoCollectionAsync(todoCollectionViewModel);
                return Ok(todoCollectionViewModel);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar a coleção: " + e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TodoCollectionViewModel>> Update(int id, [FromBody] TodoCollectionViewModel todoCollectionViewModel)
        {
            try
            {
                await _todoCollectionService.UpdateTodoCollectionAsync(id, todoCollectionViewModel);
                return Ok(todoCollectionViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TodoCollectionViewModel>> Delete(int id)
        {
            try
            {
                await _todoCollectionService.DeleteTodoCollectionAsync(id);
                return Ok($"A coleção de id {id} foi deletada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
