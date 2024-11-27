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
        [Range(1, 8, ErrorMessage = "La cantidad de personas debe estar entre 1 y 8.")]
        public int CantPersonas { get; set; }

        [Required(ErrorMessage = "La fecha y la hora son obligatorias")]
        


        public DateTime FechaReserva { get; set; }

        public EstadoReserva Estado { get; set; } = EstadoReserva.Pendiente;

        
    }
   
}
