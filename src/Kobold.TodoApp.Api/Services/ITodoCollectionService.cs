using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kobold.TodoApp.Api.Services
{
    public interface ITodoCollectionService
    {
        Task<IEnumerable<TodoCollectionDto>> GetTodoCollectionsAsync();
        Task<TodoCollectionDto> GetTodoCollectionByIdAsync(int id);
        Task CreateTodoCollectionAsync(TodoCollectionViewModel todoCollectionViewModel);
        Task UpdateTodoCollectionAsync(int id, TodoCollectionViewModel todoCollection);
        Task DeleteTodoCollectionAsync(int id);
    }
}
