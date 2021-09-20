using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;

namespace Kobold.TodoApp.Api.Services
{

    public class TodoService
    {

        private static int nextId = 1;
        private static List<Todo> Todos = new List<Todo>();

        public IEnumerable<Todo> Get()
        {
            return Todos;
        }

        public Todo Create(TodoViewModel todovm)
        {
            var todo = new Todo { Id = nextId++, DataCriacao = DateTime.Now, Description = todovm.Description, Done = todovm.Done }; 
            Todos.Add(todo);

            return todo;
        }

        public Todo Update(int id, TodoViewModel todovm)
        {
            var todo = Todos.Single(todo => todo.Id == id);
            todo.Done = todovm.Done;

            return todo;
        }

        public Todo Get(int id)
        {
            return Todos.Single(todo => todo.Id == id);
        }

        public void Remove(int id)
        {
            var index = Todos.FindIndex(todo => todo.Id == id);
            Todos.RemoveAt(index);
        }

    }
}
