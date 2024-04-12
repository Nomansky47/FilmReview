namespace FilmReview.Models
{
    public class FilmsData
    {
        public Films Film { get; set; }
        public bool? isAdmin { get; set; }
        public int? currentUserID { get; set; }
        public int Rank { get; set; } = 0;
        public int? ReviewID { get; set; } =null;
    }
}
