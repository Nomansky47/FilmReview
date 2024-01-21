namespace FilmReview.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int FilmID { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
    }
}
