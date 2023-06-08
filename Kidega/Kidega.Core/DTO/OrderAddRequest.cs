using Kidega.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.DTO
{
    public class OrderAddRequest
    {
        [Required]
        public string IdentityUserId { get; set; }
        public DateTime OrderDate { get; set; }
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

        public IEnumerable<OrderItemAddRequest> OrderItems { get; set; }

    }
}
