using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Airline_Reservation_System.Models
{
    public class Plain
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int plainId { get; set; }

        [Required]
        public string plainName { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }
    }
}
