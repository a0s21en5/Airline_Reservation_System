using System.ComponentModel.DataAnnotations;

namespace Airline_Reservation_System.Models
{
    public class UserLogin
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
