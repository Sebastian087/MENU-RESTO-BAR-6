using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class ReservaModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Telefono { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Range(1, 20)]
        public int Personas { get; set; }

        public string Comentarios { get; set; }
    }

}

