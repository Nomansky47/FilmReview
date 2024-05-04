using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmReview.Models
{
    public class Films
    {
        [Key]
        public int FilmID { get; set; }
        [Required]
        public string FilmImageLink { get; set; }
        [Required]
        public string FilmName { get; set; }
        [Required]
        public string Genres { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string MPAA { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public int Summ { get; set; } = 0;
        [Required]
        public int Total { get; set; } = 0;
        [Required]
        public string About { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comments> Comments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Videos> Videos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
