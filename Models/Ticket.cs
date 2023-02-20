using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Airline_Reservation_System.Models
{
    public class Ticket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketId { get; set; }
        //Associated with user
        public int userId { get; set; }
        //userId Associated with Plain
        public int plainId { get; set; }

        [ForeignKey("userId")]
        public virtual User User { get; set; }

        [ForeignKey("plainId")]
        public virtual Plain Plain { get; set; }
    }
}
