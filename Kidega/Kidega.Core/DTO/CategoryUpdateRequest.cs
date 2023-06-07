using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.DTO
{
    public class CategoryUpdateRequest
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
