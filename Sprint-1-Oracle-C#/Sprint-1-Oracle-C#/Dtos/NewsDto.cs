using System.ComponentModel.DataAnnotations;

namespace Sprint_1_Oracle_C_.Dtos;

public class NewsDto
{
    [Required(ErrorMessage = "title is required")]
    [MaxLength(100, ErrorMessage = "title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "source content is required")]
    public string Source { get; set; } = string.Empty;

    [Required(ErrorMessage = "published content is required")]
    [Range(typeof(DateTime), "1/1/1900", "12/31/2099", ErrorMessage = "Published date must be between 1/1/1900 and 12/31/2099")]
    public DateTime PublishedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
