using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.ViewModels;
using Kobold.TodoApp.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Kobold.TodoApp.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await _context.Todos
                 .Include(x => x.TodoCollection)
                 .ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _context.Todos
                .Include(x => x.TodoCollection)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateTodoAsync(TodoViewModel todoCollectionViewModel)
        {

            var todo = new Todo()
            {
                Description = todoCollectionViewModel.Description,
                Done = todoCollectionViewModel.Done,
                DataCriacao = DateTime.Now,
                TodoCollectionId = todoCollectionViewModel.CollectionId
            };


            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(int id, TodoViewModel todoCollection)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                throw new Exception("Tarefa não encontrada.");

            todo.Description = todoCollection.Description;
            todo.TodoCollectionId = todoCollection.CollectionId;
            todo.Done = todoCollection.Done;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                throw new Exception("Tarefa não encontrada.");

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }




    }
}
