using Airline_Reservation_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline_Reservation_System.Context
{
    public class AirlineReservationSystemContextDb:DbContext
    {
        public AirlineReservationSystemContextDb(DbContextOptions<AirlineReservationSystemContextDb> Context):base(Context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>().HasNoKey();
        }

        //Create Admin Table in Database
        public DbSet<Admin> admins { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Plain> plains { get; set; }

        public DbSet<Airline_Reservation_System.Models.UserLogin> UserLogin { get; set; }
    }
}
