using System;
using System.Collections.Generic;

namespace QuizApp.WebAPI.Models;

public partial class QuizUser
{
    public Guid QuizzesId { get; set; }

    public Guid UsersId { get; set; }

    public DateTime StartedAt { get; set; }

    public string FinishedAt { get; set; } = null!;

    public virtual Quiz Quizzes { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
