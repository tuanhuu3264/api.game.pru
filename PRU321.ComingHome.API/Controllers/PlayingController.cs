using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRU321.ComingHome.API.BaseResponse;
using PRU321.ComingHome.BusinessLayer.Services;
using PRU321.ComingHome.DataLayer.Models;

namespace PRU321.ComingHome.API.Controllers
{

    [ApiController]
    public class PlayingController : ControllerBase
    {
        public PlayingServices PlayingServices { get; set; }
        public PlayingController() 
        { 
         PlayingServices ??= new PlayingServices();
        }
        [HttpGet("palyings/ranks/{number}")]
        public async Task<List<Playing>> GetRank([FromRoute] int number)
        {
            var playings = await PlayingServices.GetAllFromDistUser(number);
            return playings;
        }
        [HttpPost("playings")]
        public async Task<Playing> CreatePlaying(RequestCreate playing)
        {
            var createdPlayingRequest = new Playing()
            {
                Score = playing.Score,
                Time = playing.Time,
                UserId = playing.UserId,
            };
            var createdPlaying = await PlayingServices.Create(createdPlayingRequest);
            return createdPlaying;
        }
    }
}
