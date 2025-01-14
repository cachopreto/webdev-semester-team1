using Microsoft.EntityFrameworkCore;
using StarterKit.Utils;

namespace StarterKit.Models
{
    public class DatabaseContext : DbContext
    {
        // The admin table will be used in both cases

        // You can comment out or remove the case you are not going to use.

        // Tables for the Theatre ticket case
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<TheatreShowDate> TheatreShowDate { get; set; }
        public DbSet<TheatreShow> TheatreShow { get; set; }
        public DbSet<Venue> Venue { get; set; }

        // Tables for the event calendar case

        // public DbSet<User> User { get; set; }
        // public DbSet<Attendance> Attendance { get; set; }
        // public DbSet<Event_Attendance> Event_Attendance { get; set; }
        // public DbSet<Event> Event { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasIndex(p => p.UserName).IsUnique();

            modelBuilder.Entity<Admin>()
                .HasData(new Admin { AdminId = 1, Email = "admin1@example.com", UserName = "admin1", Password = "password" });
            modelBuilder.Entity<Admin>()
                .HasData(new Admin { AdminId = 2, Email = "admin2@example.com", UserName = "admin2", Password = "tooeasytooguess" });
            modelBuilder.Entity<Admin>()
                .HasData(new Admin { AdminId = 3, Email = "admin3@example.com", UserName = "admin3", Password = "helloworld" });
            modelBuilder.Entity<Admin>()
                .HasData(new Admin { AdminId = 4, Email = "admin4@example.com", UserName = "admin4", Password = "Welcome123" });
            modelBuilder.Entity<Admin>()
                .HasData(new Admin { AdminId = 5, Email = "admin5@example.com", UserName = "admin5", Password = "Whatisapassword?" });

            // Seed theatre data
            modelBuilder.Entity<Venue>()
                .HasData(new Venue { VenueId = 1, Name = "Main Theatre", Capacity = 200 });

            modelBuilder.Entity<TheatreShow>()
                .HasData(
                    new TheatreShow { 
                        TheatreShowId = 1, 
                        Title = "Romeo and Juliet", 
                        Description = "Shakespeare's classic tale of star-crossed lovers",
                        Price = 25.00,
                        VenueId = 1
                    },
                    new TheatreShow { 
                        TheatreShowId = 2, 
                        Title = "The Phantom of the Opera", 
                        Description = "Andrew Lloyd Webber's musical masterpiece",
                        Price = 35.00,
                        VenueId = 1
                    }
                );

            modelBuilder.Entity<TheatreShowDate>()
                .HasData(
                    new TheatreShowDate { 
                        TheatreShowDateId = 1, 
                        DateAndTime = DateTime.Now.AddDays(7).Date.AddHours(19), 
                        TheatreShowId = 1 
                    },
                    new TheatreShowDate { 
                        TheatreShowDateId = 2, 
                        DateAndTime = DateTime.Now.AddDays(8).Date.AddHours(19), 
                        TheatreShowId = 1 
                    },
                    new TheatreShowDate { 
                        TheatreShowDateId = 3, 
                        DateAndTime = DateTime.Now.AddDays(7).Date.AddHours(20), 
                        TheatreShowId = 2 
                    },
                    new TheatreShowDate { 
                        TheatreShowDateId = 4, 
                        DateAndTime = DateTime.Now.AddDays(9).Date.AddHours(20), 
                        TheatreShowId = 2 
                    }
                );
        }

    }

}
