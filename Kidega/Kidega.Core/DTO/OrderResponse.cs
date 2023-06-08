using Kidega.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.DTO
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        #region Shipment Details
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        #endregion

        public IEnumerable<OrderItemResponse> OrderItems { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
