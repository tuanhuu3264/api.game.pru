using PRU321.ComingHome.DataLayer.Models;
using PRU321.ComingHome.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.BusinessLayer.Services
{
    public class PlayingServices
    {
        public GenericRepository<Playing> _playingRepository; 
        public PlayingServices()
        {
            _playingRepository ??= new GenericRepository<Playing>();
        }
        public async Task<List<Playing>> GetAllFromDistUser(int number)
        {
            var palying = (await _playingRepository.GetAll()).OrderByDescending(x => x.Score).DistinctBy(x => x.UserId).Take(number); 
            return palying.ToList();
        }
        public async Task<Playing> Create(Playing playing)
        {

         
            await _playingRepository.CreateAsync(playing);
            return (await _playingRepository.GetAllAsync()).OrderBy(x => x.Id).LastOrDefault();
        }
        public async Task<Playing> Update(Playing playing)
        {
            await _playingRepository.UpdateAsync(playing);
            return (await _playingRepository.GetByIdAsync(playing.Id)); 
        }
        public async Task<bool> Delete(int id)
        {   
            var playing = await _playingRepository.GetByIdAsync(id);
            if (playing == null) throw new Exception("There is no playing that has id: " + id);
            await _playingRepository.RemoveAsync(playing);
            return true;
        }


    }
}
