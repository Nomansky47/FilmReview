using System.ComponentModel.DataAnnotations;

namespace FilmReview.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }
        [Required]
        public int ImageID { get; set; }
        [Required]
        public string FilmName { get; set; }
        [Required]
        public string FilmTags { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public float Rating { get; set; } = 0;
    }
}
