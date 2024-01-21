using System.ComponentModel.DataAnnotations;

namespace FilmReview.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        [Required]
        public string ImageLink { get; set; }
    }
}
