namespace MENU_RESTO_BAR_6.Models

{
    public class CarritoViewModel
    {
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
        public decimal Total => Items.Sum(item => item.Precio * item.Cantidad);
    }
}
