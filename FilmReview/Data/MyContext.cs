using FilmReview.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmReview.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Film>? Films { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}