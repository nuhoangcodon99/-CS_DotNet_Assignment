using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class QuizUser
{
    public Guid QuizzesId { get; set; }

    public Guid UsersId { get; set; }

    public DateTime StartedAt { get; set; }

    public string FinishedAt { get; set; } = null!;

    public Guid Id { get; set; }

    public virtual Quiz Quizzes { get; set; } = null!;

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();

    public virtual User Users { get; set; } = null!;
}
