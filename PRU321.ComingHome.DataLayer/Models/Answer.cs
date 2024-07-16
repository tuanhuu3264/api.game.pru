using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.DataLayer.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool? Correct { get; set; }
        public int QuestionId {  get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Question? Question { get; set; }

    }
}
