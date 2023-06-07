using System.ComponentModel.DataAnnotations;

namespace Kidega.Domain.Entities
{
    public class Author : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Navigation property
        public List<Book> Books { get; set; }
    }
}
