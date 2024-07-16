using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRU321.ComingHome.BusinessLayer.Services;
using PRU321.ComingHome.DataLayer.Models;

namespace PRU321.ComingHome.API.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService { get; set; }
        public UserController()
        {
            userService ??= new UserService();
        }
        [HttpGet("users/{email}/{password}")]
        public async Task<User> Login([FromRoute] string email, [FromRoute] string password)
        {
            var user = await userService.Login(email, password);
            return user;
        }
        [HttpPost("users/{email}/{password}")]
        public async Task<User> Register([FromRoute] string email, [FromRoute] string password)
        {
            var user = await userService.Register(email, password);
            return user;
        }
        [HttpPut("users")]
        public async Task<User> Update([FromBody] User request)
        {
            var user = await userService.UpdateUser(request);
            return user;
        }
        [HttpGet("users/rank-tops/{email}/{score}/{rank}")]
        public async Task<EndGame> RankTops([FromRoute] int rank, [FromRoute] string email,[FromRoute] double score)
        {
            var endGame = await userService.GetRankTop(rank, email, score);
            return endGame;
        }
    }
}
