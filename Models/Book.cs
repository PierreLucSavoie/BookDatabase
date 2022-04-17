using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookDatabase.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Author { get; set; }
        
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile BookImageFile { get; set; }
        
        //Path to the image file
        public string? ImagePath { get; set; }
        //will be used to identify if book belongs to specific user
        public string? UserId { get; set; }

        public bool Whishlist { get; set; }
    }
}
