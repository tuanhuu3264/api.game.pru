using PRU321.ComingHome.DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRU321.ComingHome.API.BaseResponse
{
    public class RequestCreate
    { 
        public double Score { get; set; }
        public double Time { get; set; }
        public int UserId { get; set; }
    }
}
