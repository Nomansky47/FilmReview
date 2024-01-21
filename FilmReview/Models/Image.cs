using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReview.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        [Required]
        public int FilmID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [ForeignKey("FilmID")]
        public virtual Film Films { get; set; }
    }
}
