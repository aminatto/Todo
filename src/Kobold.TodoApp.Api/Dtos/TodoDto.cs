using System;

namespace Kobold.TodoApp.Api.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Done { get; set; }
        public string Description { get; set; }
    }
}
