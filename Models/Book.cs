using System.ComponentModel.DataAnnotations;

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

        //will implement image later
        //public string? Image { get; set; }

        //will be used to identify if book belongs to specific user
        public string? UserId { get; set; }

        public bool Whishlist { get; set; }
    }
}
