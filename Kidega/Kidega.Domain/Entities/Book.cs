using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidega.Domain.Entities
{
    public class Book: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        // Foreign key properties
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AuthorId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}
