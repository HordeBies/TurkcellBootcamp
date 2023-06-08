using System.ComponentModel.DataAnnotations;

namespace Kidega.Web.Models
{
    public class ShipmentInformation
    {
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
    }
}
