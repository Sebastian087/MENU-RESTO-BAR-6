using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Contraseña { get; set; }
               
    }

  

}


