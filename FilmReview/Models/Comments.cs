using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int FilmID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int Likes { get; set; }
        [Required]
        public int Dislikes { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
        public int SubCommentID { get; set; }
        public virtual ICollection<Comments> CommentsCollection
        [ForeignKey("CommentIDID")]
        public virtual Comments Comments { get; set; }
    }
}
