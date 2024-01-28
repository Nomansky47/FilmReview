using System.ComponentModel.DataAnnotations;

namespace FilmReview.Models
{
    public class Films
    {
        [Key]
        public int FilmID { get; set; }
        [Required]
        public string FilmImageLink { get; set; }
        [Required]
        public string FilmName { get; set; }
        [Required]
        public string FilmTags { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public float Rating { get; set; } = 0;
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Images> Images { get; set; }
    }
}
