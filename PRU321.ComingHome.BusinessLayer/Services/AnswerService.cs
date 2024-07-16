using PRU321.ComingHome.DataLayer.Models;
using PRU321.ComingHome.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.BusinessLayer.Services
{
    public class AnswerService
    {
        public GenericRepository<Answer> _answerRepository; 
        public AnswerService()
        {
            _answerRepository ??= new GenericRepository<Answer>();
        }
        public async Task<List<Answer>> GetListAnswerByQuestionId(int questionId)
        {
            var answers = (await _answerRepository.GetAllAsync()).Where(x=>x.QuestionId==questionId);
            return answers.ToList();
        }
        public async Task<Answer> Create(Answer answer)
        {
            await _answerRepository.CreateAsync(answer);
            return (await _answerRepository.GetAllAsync()).OrderBy(x=>x.Id).LastOrDefault();
        }
        public async Task<Answer> Update(Answer answer)
        {
            var updatedAnswer = await _answerRepository.GetByIdAsync(answer.Id);
            if (updatedAnswer == null) throw new Exception("There is no answer that has id: " + answer.Id); 
            updatedAnswer.Content=answer.Content;
            updatedAnswer.Correct= answer.Correct;
            updatedAnswer.QuestionId=answer.QuestionId;
            await _answerRepository.UpdateAsync(updatedAnswer);
            return (await _answerRepository.GetAllAsync()).First(x=>x.Id==answer.Id);
        }
    }
}
