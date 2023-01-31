using Airline_Reservation_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline_Reservation_System.Context
{
    public class AirlineReservationSystemContextDb:DbContext
    {
        public AirlineReservationSystemContextDb(DbContextOptions<AirlineReservationSystemContextDb> Context):base(Context)
        {

        }

        //Create Admin Table in Database
        public DbSet<Admin> admins { get; set; }

        public DbSet<User> users { get; set; }
    }
}
