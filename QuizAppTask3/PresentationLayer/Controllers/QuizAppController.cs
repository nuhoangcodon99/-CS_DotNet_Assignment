using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizAppController : ControllerBase
{

    private readonly ILogger<QuizAppController> _logger;
    private readonly UserService _userService;
    private readonly QuizService _quizService;
    public QuizAppController(ILogger<QuizAppController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<IEnumerable<User>> GetAllUser()
    {
        return await _userService.GetAllAsync();
    }

    [HttpGet("{id:guid}")]
    public async Task<User?> GetUserById([FromRoute]Guid id)
    {
        return await _userService.GetByIdAsync(id);
    }

    [HttpGet("quiz")]
    public async Task<IEnumerable<Quiz>> GetAllQuiz()
    {
        return await _quizService.GetAllAsync();
    }
    [HttpPost("add")]
    public async Task<ActionResult<Quiz>> CreatQuiz([FromBody]Quiz quiz)
    {
          _quizService.AddAsync(quiz);
         return quiz;
    }
    
}