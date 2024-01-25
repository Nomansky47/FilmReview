using FilmReview.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmReview.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Users>? Users { get; set; }
        public DbSet<Films>? Films { get; set; }
        public DbSet<Images>? Images { get; set; }
        public DbSet<Comments>? Comments { get; set; }
    }
}