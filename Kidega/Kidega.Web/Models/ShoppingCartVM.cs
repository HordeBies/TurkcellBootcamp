namespace Kidega.Web.Models
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
        public ShipmentInformation ShipmentInformation { get; set; } = new ShipmentInformation();
    }
}
