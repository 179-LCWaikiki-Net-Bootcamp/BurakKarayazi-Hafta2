using System.ComponentModel.DataAnnotations.Schema;

namespace GenericCrud.Models
{
    public class ToDoItem:EntityBase
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        [ForeignKey("Note")]
        public long? NoteId { get; set; }
        public virtual Note TodoNote { get; set; }
    }
}
