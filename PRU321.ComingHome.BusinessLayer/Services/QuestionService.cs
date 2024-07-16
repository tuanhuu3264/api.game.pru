using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PRU321.ComingHome.DataLayer.Models;
using PRU321.ComingHome.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.BusinessLayer.Services
{
    public class QuestionService
    {
        public GenericRepository<Question> _questionRepository;
        public QuestionService() 
        { 
          _questionRepository ??= new GenericRepository<Question>();
        }
        public async Task<List<Question>> Get(int number)
        {
            var allQuestions = await _questionRepository.GetAllAsync();

            var random = new Random();
            var randomQuestions = allQuestions.OrderBy(q => random.Next()).Take(number).ToList();

            return randomQuestions;
        }
        public async Task<Question> Create(Question question)
        {
            await _questionRepository.CreateAsync(question);
            return (await _questionRepository.GetAllAsync()).OrderBy(x => x.Id).LastOrDefault();
        }
        public async Task<Question> Update(Question question)
        {   var updatedQuestion  = await _questionRepository.GetByIdAsync(question.Id);
            if(updatedQuestion ==null) throw new Exception("There is no question that has id: "+question.Id);   
            updatedQuestion.Content = question.Content;
            await _questionRepository.UpdateAsync(question); 
            return await _questionRepository.GetByIdAsync(question.Id);
        }
        
    }
}
