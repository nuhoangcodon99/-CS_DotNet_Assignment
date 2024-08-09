using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Answer
{
    public Guid Id { get; set; }

    public string Content { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public bool IsActive { get; set; }

    public Guid QuestionId { get; set; }

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
