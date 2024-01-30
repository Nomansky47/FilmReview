using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewID { get; set; }
        [Required]
        public int UserID {  get; set; }
        [Required]
        public int FilmID { get; set; }
        [Required]
        public int Rank { get; set; }
        [ForeignKey("FilmID")]
        public virtual Films Films { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
    }
}
