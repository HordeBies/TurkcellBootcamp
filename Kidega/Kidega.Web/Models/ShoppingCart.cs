namespace Kidega.Web.Models
{
    public class ShoppingCart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public void ClearAll() => CartItems.Clear();

        public decimal TotalPrice() => CartItems.Sum(item => item.Book.Price * item.Quantity);
        public int TotalItemCount() => CartItems.Count;

        public void AddItem(CartItem item)
        {
            var exists = CartItems.FirstOrDefault(c => c.Book.Id == item.Book.Id);
            if (exists != null)
            {
                //var existingCourse = CourseItems.FirstOrDefault(c => c.Course.Id == courseItem.Course.Id);
                exists.Quantity += item.Quantity;
            }
            else
            {
                CartItems.Add(item);
            }
        }


    }
}
