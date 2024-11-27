using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MENU_RESTO_BAR_6.Models
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarritoId { get; set; }
        public bool Comprado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<CarritoItem>? Items { get; set; }
    }
}
