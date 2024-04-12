using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Dislikes
    {
        [Key]
        public int DislikeID { get; set; }
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