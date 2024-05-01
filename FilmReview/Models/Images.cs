using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Images
    {
        [Key]
        public int ImageID { get; set; }
        [Required]
        public int FilmID { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
    }
}
