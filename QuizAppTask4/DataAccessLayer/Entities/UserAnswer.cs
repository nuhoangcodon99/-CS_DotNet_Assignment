using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class UserAnswer
{
    public Guid Id { get; set; }

    public Guid UserQuizId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid AnswerId { get; set; }

    public bool IsCorrect { get; set; }

    public virtual Answer Answer { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual QuizUser UserQuiz { get; set; } = null!;
}
