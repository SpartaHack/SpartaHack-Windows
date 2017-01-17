using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SpartaHack.BLL.Models
{
    public class SpartaHackDataStore: DbContext
    {
        public DbSet<Schedule> ScheduleItems { get; set; }
        public DbSet<User> CurrentUser { get; set; }

        public DbSet<Prize> Prizes { get; set; }

        public DbSet<Sponsor> Sponsors { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SpartaHack.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // make primary
           /* modelBuilder.Entity<Schedule>()
                .HasKey(s => s.id)
                .HasName("PrimaryKey_id");
            */

        }







        public static void InitializeMigration()
        {
            using (var database = new SpartaHackDataStore())
            {
                database.Database.Migrate();
            }
        }


    }
}
