using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.DataLayer.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password {  get; set; }
        public bool IsAnyCompleted { get; set; }
        public double TotalScore { get; set; }
        public int NumberCheckpoint { get; set; }
        public float XPosition { get; set; }
        public int IndexScene { get; set; }
        public float YPosition { get; set; }
        public double CurrentScore { get; set; }
        public double CurrentTime { get; set; }
        public double CurrentScale { get; set; }
        public double CurrentJump { get; set; }
        public double CurrentSpeed { get; set; }
        public double CurrentDame { get; set; }
        public double CurrentHealth { get; set; }

        
        public List<Playing>? Playings { get; set; }

    }
}
