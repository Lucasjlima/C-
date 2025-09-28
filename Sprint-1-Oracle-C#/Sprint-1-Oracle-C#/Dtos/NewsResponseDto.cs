using System.ComponentModel.DataAnnotations;

namespace Sprint_1_Oracle_C_.Dtos;

public class NewsResponseDto
{
    public string Title { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;

    public DateTime PublishedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
