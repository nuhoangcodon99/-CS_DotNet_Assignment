using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Quiz
{
    public Guid Id { get; set; }

    public string Tile { get; set; } = null!;

    public string? Description { get; set; }

    public int Duration { get; set; }

    public string? ThumbnailUrl { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual ICollection<QuizUser> QuizUsers { get; set; } = new List<QuizUser>();
}
