using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRU321.ComingHome.BusinessLayer.Services;
using PRU321.ComingHome.DataLayer.Models;

namespace PRU321.ComingHome.API.Controllers
{
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public QuestionService QuestionService { get; set; }
        public QuestionController()
        {
            QuestionService ??= new QuestionService();
        }
        [HttpGet("questions/{number}")]
        public async Task<List<Question>> Get([FromRoute] int number)
        {
            var questions = await QuestionService.Get(number);
            return questions;
        }
        [HttpPost("questions")]
        public async Task<Question> Create(Question question)
        {
            var createdQuestion = await QuestionService.Create(question);
            return createdQuestion;
        }
        [HttpPut("questions")]
        public async Task<Question> Update(Question question)
        {
            var updatedQuestion = await QuestionService.Update(question);
            return updatedQuestion;
        }

    }
}
