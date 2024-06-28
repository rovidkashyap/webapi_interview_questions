using System.ComponentModel.DataAnnotations;

namespace dependency_injection_in_web_api.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{10}", ErrorMessage = "Invalid ISBN format")]
        public string ISBN { get; set; }
    }
}
