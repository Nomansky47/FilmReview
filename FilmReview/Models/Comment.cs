using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Comment
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
        [ForeignKey("UserID")]
        public virtual User Users { get; set; }
        [ForeignKey("FilmID")]
        public virtual Film Films { get; set; }
    }
}
