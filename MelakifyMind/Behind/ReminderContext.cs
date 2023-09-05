using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using melakify.Entities.Behind;
using Microsoft.EntityFrameworkCore;

namespace MelakifyMind.Behind
{
    public class ReminderContext : DbContext
    {
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"C:\emtudio\+Do\base.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reminder>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Reminder>().Property(x => x.Day).IsRequired().HasColumnType("integer");
            modelBuilder.Entity<Reminder>().Property(x => x.Month).IsRequired().HasColumnType("integer");
            modelBuilder.Entity<Reminder>().Property(x => x.Year).IsRequired().HasColumnType("integer");
            modelBuilder.Entity<Reminder>().Property(x => x.ShowDay).IsRequired().HasColumnType("integer");
            modelBuilder.Entity<Reminder>().Property(x => x.ShowYear).IsRequired().HasColumnType("integer");
            modelBuilder.Entity<Reminder>().Property(x => x.IsImportant).IsRequired();
            modelBuilder.Entity<Reminder>().Property(x => x.DaysBefore).IsRequired().HasColumnType("integer");
            modelBuilder.Entity<Reminder>().Ignore(x => x.DaysDistance);
            modelBuilder.Entity<Reminder>().Ignore(x => x.DateFolder);
            modelBuilder.Entity<Reminder>().Ignore(x => x.GregorianDateFolder);
            modelBuilder.Entity<Reminder>().Ignore(x => x.Matter);
            modelBuilder.Entity<Reminder>().Ignore(x => x.ImportantColor);
        }
    }
}
