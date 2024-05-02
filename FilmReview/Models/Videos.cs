using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Videos
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        public int FilmID { get; set; }
        [Required]
        public string Link { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
    }
}
