using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class Question
{
    public Guid Id { get; set; }

    public string Content { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
