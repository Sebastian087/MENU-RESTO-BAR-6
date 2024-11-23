using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class MotivoCancelacion
    {
        public int MotivoCancelacionId { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}
