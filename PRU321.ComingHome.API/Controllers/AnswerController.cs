using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRU321.ComingHome.BusinessLayer.Services;
using PRU321.ComingHome.DataLayer.Models;

namespace PRU321.ComingHome.API.Controllers
{

    [ApiController]
    public class AnswerController : ControllerBase
    {
        public AnswerService AnswerService { get; set; }
        public AnswerController() 
        {
            AnswerService ??= new AnswerService();
        }
        [HttpGet("answers/questions/{questionId}")]
        public async Task<List<Answer>> GetListAnswerByQuestionId(int questionId)
        {
             var answers = await AnswerService.GetListAnswerByQuestionId(questionId);
            return answers;
        }
        [HttpPost("answers")]
        public async Task<Answer> Create(Answer answer)
        {
            var createdAnswer  = await AnswerService.Create(answer);
            return createdAnswer;
        }
        [HttpPut("answers")]
        public async Task<Answer> Update(Answer answer)
        {
            var updatedAnswer = await AnswerService.Update(answer);
            return updatedAnswer;
        }
    }
}
