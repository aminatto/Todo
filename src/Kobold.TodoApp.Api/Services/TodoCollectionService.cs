using Kobold.TodoApp.Api.Context;
using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kobold.TodoApp.Api.Services
{
    public class TodoCollectionService : ITodoCollectionService
    {
        private readonly AppDbContext _context;

        public TodoCollectionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoCollectionDto>> GetTodoCollectionsAsync()
        {
            var todoCollections = await _context.TodoCollections.Include(x => x.Todos).ToListAsync();

            var todoCollectionDtos = todoCollections.Select(tc => new TodoCollectionDto
            {
                Id = tc.Id,
                Description = tc.Description,
                Type = tc.Type,
                Todos = tc.Todos.Select(t => new TodoDto
                {
                    Id = t.Id,
                    DataCriacao = t.DataCriacao,
                    Done = t.Done,
                    Description = t.Description
                }).ToList()
            }).ToList();

            return todoCollectionDtos;
        }

        public async Task<TodoCollectionDto> GetTodoCollectionByIdAsync(int id)
        {
            var todoCollection = await _context.TodoCollections
                        .Include(x => x.Todos)
                        .FirstOrDefaultAsync(tc => tc.Id == id);

            if (todoCollection == null)
                return null;

            var todoCollectionDto = new TodoCollectionDto()
            {
                Id = todoCollection.Id,
                Description = todoCollection.Description,
                Type = todoCollection.Type,
                Todos = todoCollection.Todos?.Select(t => new TodoDto
                {
                    Id = t.Id,
                    DataCriacao = t.DataCriacao,
                    Done = t.Done,
                    Description = t.Description
                }).ToList(),
            };

            return todoCollectionDto;
        }

        public async Task CreateTodoCollectionAsync(TodoCollectionViewModel todoCollectionViewModel)
        {
            var todoCollection = new TodoCollection()
            {
                Description = todoCollectionViewModel.Description,
                Type = todoCollectionViewModel.Type,
            };

            await _context.TodoCollections.AddAsync(todoCollection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoCollectionAsync(int id, TodoCollectionViewModel todoCollection)
        {
            var collection = await _context.TodoCollections.FindAsync(id);
            if (collection == null)
                throw new Exception("Coleção não encontrada.");

            collection.Description = todoCollection.Description;
            collection.Type = todoCollection.Type;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoCollectionAsync(int id)
        {
            var todoCollection = await _context.TodoCollections
                .Include(tc => tc.Todos)
                .FirstOrDefaultAsync(tc => tc.Id == id);

            if (todoCollection == null)
                throw new Exception("Coleção não encontrada.");

            _context.Todos.RemoveRange(todoCollection.Todos);
            _context.TodoCollections.Remove(todoCollection);

            await _context.SaveChangesAsync();
        }

    }
}
