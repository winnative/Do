using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Emtudio.Systems.Entities
{
    public class ReminderContext : DbContext
    {
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=AppData\base.emlite;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reminder>().ToTable("Reminders");
            modelBuilder.Entity<Reminder>().HasKey(x => x.ID);
            modelBuilder.Entity<Reminder>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Reminder>().Ignore(x => x.DaysDistance);
            modelBuilder.Entity<Reminder>().Ignore(x => x.ImportantColor);
        }

        public void OnModelOpening()
        {
            Database.EnsureCreated();
        }
    }
}
