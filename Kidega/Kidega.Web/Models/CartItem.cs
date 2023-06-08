using Kidega.Core.DTO;

namespace Kidega.Web.Models
{
    public class CartItem
    {
        public BookResponse Book { get; set; }
        public int Quantity { get; set; }
    }
}
