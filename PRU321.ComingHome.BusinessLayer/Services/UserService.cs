using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Identity.Client;
using PRU321.ComingHome.DataLayer.Models;
using PRU321.ComingHome.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.BusinessLayer.Services
{   
    public interface IUserService
    {
        public Task<User>  Login(string username, string password);
        public Task<User> Register(string email,string password);
        public Task<User> UpdateUser(User user);
        public Task<EndGame> GetRankTop(int rank, string email, double score);
    }
    public class UserService :IUserService
    {
        public GenericRepository<User> GenericRepository;
        public UserService() 
        { 
           GenericRepository ??= new GenericRepository<User> ();
        }

        public async Task<User> Login(string username, string password)
        {
            var users = await GenericRepository.GetAll();
            var user = users.Where(x => x.Email.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
            return user;
        }

        public async Task<User> Register(string email , string password)
        {
            var checking = (await GenericRepository.GetAllAsync()).Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (checking != null) throw new Exception("The email is existed.");
            await GenericRepository.CreateAsync(new User { Email = email, Password = password });
            var user = (await GenericRepository.GetAllAsync()).OrderBy(x=>x.Id).LastOrDefault();
            return user;
        }
        public async Task<User> UpdateUser(User user)
        {
            await GenericRepository.UpdateAsync(user);
            return (await GenericRepository.GetAllAsync()).First(x => x.Email.ToLower() == user.Email); 
        }
        public async Task<EndGame> GetRankTop(int rank, string email , double score)
        {
            var listUser = (await GenericRepository.GetAllAsync()).Where(x=>x.TotalScore!=0).OrderByDescending(x=>x.TotalScore);

            int i = 1;
            var returned = listUser.Select(x => new RankTop()
            {
                Email = x.Email,
                Score = x.TotalScore
            }).ToList();
            var flag = true;
            foreach(var item in returned)
            {
                if(item.Score==score&&item.Email==email) flag = false;
            }
            if (flag) returned.Add(new RankTop()
            {
                Email = email,
                Score = score,
            });
            EndGame endGame = new EndGame();
            returned=returned.OrderByDescending(x=>x.Score).ToList();
           foreach(var item in returned)
            {   
                
                item.Rank = i;
                if (item.Email == email && item.Score == score)
                {
                    endGame.Rank = i;
                    endGame.Email=email;
                    endGame.Score = score;
                }
                    i++;
            }
            endGame.RankTops = returned.Take(rank).ToList();
            return endGame;
        }
    }
}
