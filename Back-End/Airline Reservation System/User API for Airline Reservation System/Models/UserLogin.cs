using System.ComponentModel.DataAnnotations;

namespace User_API_for_Airline_Reservation_System.Models
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
