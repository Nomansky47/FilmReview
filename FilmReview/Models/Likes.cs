using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Likes
    {
        [Key]
        public int LikeID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int FilmID { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
    }
}
