using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRU321.ComingHome.DataLayer.Models
{
    public class Context : DbContext
    {

        public Context() { }

        DbSet<User>  Users { get; set; }
        DbSet<Playing> Playings { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer > Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=34.123.203.83;initial catalog=ComingHome;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;");
        }

    }
}
