using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidega.Domain.Entities
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPriceOnPurchase { get; set; } // Book price can change after purchase we need to keep the price at the time of purchase
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        // Navigation Property
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
