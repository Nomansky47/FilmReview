using System.ComponentModel.DataAnnotations;

namespace FilmReview.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
    }
}
