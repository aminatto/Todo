using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kobold.TodoApp.Api.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(TodoViewModel todoCollectionViewModel);
        Task UpdateTodoAsync(int id, TodoViewModel todoCollection);
        Task DeleteTodoAsync(int id);
    }
}
