using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class Question
{
    [Key,Required]
    public Guid Id { get; set; }
    [Required,StringLength(5000),MinLength(5)]
    public string? Content { get; set; }
    [Required]
    public string? QuestionType { get; set; }
}