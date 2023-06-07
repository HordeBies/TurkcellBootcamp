using System.ComponentModel.DataAnnotations;
namespace Kidega.Domain.Entities
{
    public class Book: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; } // Without a precision set Price will have 18,2 as default for 18 otal digits and 2 digits after the decimal point

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
