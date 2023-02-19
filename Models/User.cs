using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Airline_Reservation_System.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string userEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$", ErrorMessage = "Your pass. should be the combination of one upper and one lower case and a symbol and a number ...")]
        public string userPassword { get; set; }

        [Required]
        public string userImage { get; set; }

        public string Role { get; set; } = "user";
    }
}
