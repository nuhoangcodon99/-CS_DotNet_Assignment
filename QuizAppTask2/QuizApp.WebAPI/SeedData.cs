using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new QuizAppDbContext(serviceProvider.GetRequiredService<DbContextOptions<QuizAppDbContext>>()))
        {
            if (context.Quizzes.Any() || context.Questions.Any() || context.Answers.Any())
            {
                return; // DB has been seeded
            }

            var quizzes = new Quiz[]
            {
                new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 1", Description = "Description 1", Duration = 60, ThumbnailUrl = "url1" },
                new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 2", Description = "Description 2", Duration = 90, ThumbnailUrl = "url2" },
                new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 3", Description = "Description 3", Duration = 120, ThumbnailUrl = "url3" },
                new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 4", Description = "Description 4", Duration = 150, ThumbnailUrl = "url4" },
                new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 5", Description = "Description 5", Duration = 180, ThumbnailUrl = "url5" }
            };

            context.Quizzes.AddRangeAsync(quizzes);

            var questions = new Question[]
            {
                new Question { Id = Guid.NewGuid(), Content = "Question 1", QuestionType = "MultipleChoice", QuizQuestions = new List<QuizQuestion>()},
                new Question { Id = Guid.NewGuid(), Content = "Question 2", QuestionType = "MultipleChoice", QuizQuestions = new List<QuizQuestion>() },
                new Question { Id = Guid.NewGuid(), Content = "Question 3", QuestionType = "MultipleChoice", QuizQuestions = new List<QuizQuestion>() },
                new Question { Id = Guid.NewGuid(), Content = "Question 4", QuestionType = "MultipleChoice", QuizQuestions = new List<QuizQuestion>() },
                new Question { Id = Guid.NewGuid(), Content = "Question 5", QuestionType = "MultipleChoice", QuizQuestions = new List<QuizQuestion>() }
            };

            context.Questions.AddRangeAsync(questions);

            var answers = new Answer[]
            {
                new Answer { Id = Guid.NewGuid(), Content = "Answer 1", IsCorrect = true, QuestionId = questions[0].Id },
                new Answer { Id = Guid.NewGuid(), Content = "Answer 2", IsCorrect = false, QuestionId = questions[1].Id },
                new Answer { Id = Guid.NewGuid(), Content = "Answer 3", IsCorrect = true, QuestionId = questions[2].Id },
                new Answer { Id = Guid.NewGuid(), Content = "Answer 4", IsCorrect = false, QuestionId = questions[3].Id },
                new Answer { Id = Guid.NewGuid(), Content = "Answer 5", IsCorrect = true, QuestionId = questions[4].Id }
            };

            await context.Answers.AddRangeAsync(answers);

            await context.SaveChangesAsync();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            var roles = new Role[]
            {
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "User" }
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var users = new User[]
            {
                new User { UserName = "admin", Email = "admin@example.com" },
                new User { UserName = "user1", Email = "user1@example.com" },
                new User { UserName = "user2", Email = "user2@example.com" },
                new User { UserName = "user3", Email = "user3@example.com" },
                new User { UserName = "user4", Email = "user4@example.com" }
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Password123!");
                await userManager.AddToRoleAsync(user, "User");
            }

            var adminUser = users.First();
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
