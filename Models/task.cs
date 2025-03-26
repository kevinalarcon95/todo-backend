using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Represents a task entity in the to-do application.
/// </summary>
/// <remarks>
/// This class is used to define the structure of a task, including its 
/// properties such as title, description, status, and timestamps. 
/// It is mapped to the "tasks" table in the database.
/// </remarks>
namespace todoApp.Models
{
    [Table("tasks")]
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [RegularExpression("pending|completed", ErrorMessage = "El estado debe ser 'pending' o 'completed'.")]
        public string Status { get; set; } = "pending";

        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? CompletedAt { get; set; }
    }
}