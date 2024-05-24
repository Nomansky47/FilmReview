using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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
        public int Likes { get; set; } = 0;
        [Required]
        public int Dislikes { get; set; } = 0;
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
        [AllowNull]
        public int? TrackingOn { get; set; }
    }
}
