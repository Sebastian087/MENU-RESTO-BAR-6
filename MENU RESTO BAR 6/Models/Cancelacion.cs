using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class Cancelacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CancelacionId { get; set; }

        public int ReservaId { get; set; }

        [Required]
        public string Motivo { get; set; }

        [Required]
        public DateTime FechaCancelacion { get; set; } = DateTime.Now;

    }

}

