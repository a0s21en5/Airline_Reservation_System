using Microsoft.EntityFrameworkCore;
using Plane_API_for_Airline_Reservation_System.Models;

namespace Plane_API_for_Airline_Reservation_System.Context
{
    public class AirlineReservationSystemContextDb : DbContext
    {
        public AirlineReservationSystemContextDb(DbContextOptions<AirlineReservationSystemContextDb> Context) : base(Context)
        {

        }

        public DbSet<Plain> plains { get; set; }
    }
}
