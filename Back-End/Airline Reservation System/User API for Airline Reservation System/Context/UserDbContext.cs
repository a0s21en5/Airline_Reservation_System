using Microsoft.EntityFrameworkCore;
using User_API_for_Airline_Reservation_System.Models;

namespace User_API_for_Airline_Reservation_System.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> Context) : base(Context)
        {

        }

        public DbSet<User> users { get; set; }
    }
}
