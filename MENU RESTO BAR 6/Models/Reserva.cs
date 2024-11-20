using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class Reserva
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }
        
        [Required]
        public required Usuario Usuario { get; set; }

        [Required]
        public int CantPersonas { get; set; }
        public DateTime FechaReserva { get; set; }
        public bool Confirmada { get; set; }
    }
    
}
