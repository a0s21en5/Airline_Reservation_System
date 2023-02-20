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
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string plainNumber { get; set; }
    }
}
