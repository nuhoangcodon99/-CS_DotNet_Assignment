

using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class Answer
{
    [Key,Required]
    public Guid Id { get; set; }
    [Required,MaxLength(255),MinLength(5)]
    public string? Content { get; set; }
    [Required]
    public bool IsCorrect { get; set; }
}