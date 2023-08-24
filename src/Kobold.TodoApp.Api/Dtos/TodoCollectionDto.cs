using System.Collections.Generic;

namespace Kobold.TodoApp.Api.Dtos
{
    public class TodoCollectionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<TodoDto> Todos { get; set; }
    }
}
