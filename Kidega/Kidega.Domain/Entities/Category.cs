using System.ComponentModel.DataAnnotations;

namespace Kidega.Domain.Entities
{
    public class Category: IEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation property
        public List<Book> Books { get; set; }
    }
}
