// Models/Book.cs
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title must be at most 100 characters long")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(50, ErrorMessage = "Author must be at most 50 characters long")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre must be at most 50 characters long")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "Price must be a number with up to 8 digits and 2 decimal places")]
        public decimal Price { get; set; }

        // Add the OwnerId property
        public string OwnerId { get; set; }
    }
}
