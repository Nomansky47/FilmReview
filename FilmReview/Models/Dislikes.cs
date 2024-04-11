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
        public int FilmID { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
    }
}