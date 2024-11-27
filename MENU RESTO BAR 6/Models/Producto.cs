using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MENU_RESTO_BAR_6.Models
{
    public class Producto
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }
      

        [EnumDataType(typeof(Categoria))]
        public Categoria Categoria { get; set; }
    }

}
