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
        public string UsuarioEmail { get; set; }
        public Usuario? Usuario { get; set; }

        [Required]
        public int CantPersonas { get; set; }

        [Required(ErrorMessage = "La fecha y la hora son obligatorias")]
        public DateTime FechaReserva { get; set; }
        public bool Confirmada { get; set; }
    }
    
}
