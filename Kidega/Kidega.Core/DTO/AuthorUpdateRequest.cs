using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.DTO
{
    public class AuthorUpdateRequest
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
