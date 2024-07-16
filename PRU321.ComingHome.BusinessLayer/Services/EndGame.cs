using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.BusinessLayer.Services
{
    public class EndGame
    {
        public int Rank {  get; set; }
        public string Email { get; set; }
        public double Score { get; set; }
        public List<RankTop>? RankTops { get; set; }
    }
}
