using System;

namespace Kobold.TodoApp.Api.ViewModels
{

    public class TodoViewModel
    {
        public bool Done { get; set; }

        public string Description { get; set; }

        public int CollectionId { get; set; }

    }
}
