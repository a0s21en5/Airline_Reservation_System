using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline_Reservation_System.Models
{
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adminId { get; set; }

        [Required (ErrorMessage ="Please Enter your Email")]
        public string adminEmail { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$", ErrorMessage = "Your pass. should be the combination of one upper and one lower case and a symbol and a number ...")]
        [Required(ErrorMessage = "Please Enter your Password")]
        public string adminPassword { get; set; }
    }
}
