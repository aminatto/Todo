using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kobold.TodoApp.Api.Models
{
    public class TodoCollection
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        [JsonIgnore]
        public List<Todo> Todos { get; set; }  
    }
}
