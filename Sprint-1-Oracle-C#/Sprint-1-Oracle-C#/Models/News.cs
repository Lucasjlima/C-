using System.ComponentModel.DataAnnotations;

namespace Sprint_1_Oracle_C_.Models;

public class News
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="title is required")]
    [MaxLength(100, ErrorMessage = "title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "source content is required")]
    public string  Source { get; set; } = string.Empty;

    [Required(ErrorMessage = "published content is required")]
    public DateTime PublishedAt { get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
