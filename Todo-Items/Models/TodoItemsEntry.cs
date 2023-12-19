using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo_Items.Models
{
    [Table("TodoItemList")]
    public class TodoItemsEntry
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string NameTodoItem { get; set; }=String.Empty;
        [Required]
        public DateTime DateStop { get; set; }= DateTime.Now;
        [Required]
        public StatusTodoItems StatusTodoItems { get; set; }
    }
}
