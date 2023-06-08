using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string IdentityUserId { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderTotal { get; set; }

        #region Shipment Details
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        #endregion

        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
