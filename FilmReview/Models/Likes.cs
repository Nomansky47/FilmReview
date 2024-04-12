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
        public int CommentID { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
        [ForeignKey("CommentID")]
        public virtual Comments Comments { get; set; }
    }
}
