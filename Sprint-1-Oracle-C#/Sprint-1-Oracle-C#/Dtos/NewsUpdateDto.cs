using System.ComponentModel.DataAnnotations;

namespace Sprint_1_Oracle_C_.Dtos;

public class NewsUpdateDto
{
    [Required(ErrorMessage = "title is required")]
    [MaxLength(100, ErrorMessage = "title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "source content is required")]
    public string Source { get; set; } = string.Empty;
}
