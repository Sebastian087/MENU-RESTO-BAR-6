using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(5, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        [MaxLength(30, ErrorMessage = "El nombre no debe superar los 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La direción es obligatoria")]
        [MaxLength(100, ErrorMessage = "La dirección no debe superar los 100 caracteres")]
        public string Email { get; set; }
        
        [Required]
        public string Contraseña { get; set; }


        public bool IsCheck { get; set; }
               
    }

  

}


