using FilmReview.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace UnitTests
{
    public class Tests
    {
        [Fact]
        public void AuthorizationTest()
        {
            var options = new DbContextOptionsBuilder<MyContext>();
            options.UseSqlServer("Server=DESKTOP-77N4H71\\SQLEXPRESS;Database=FilmReviewR;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            var context = new MyContext(options.Options);
            var Login = "123";
            var Password = "123";
           var bytes= Encoding.UTF8.GetBytes(Password);
            var encoded=Convert.ToBase64String(bytes);
            Assert.NotNull(context.Users.FirstOrDefault(p=>p.Password==encoded&&p.UserLogin==Login));
            context.Dispose();
        }

        [Fact]
        public void FilmsTest()
        {
            var options = new DbContextOptionsBuilder<MyContext>();
            options.UseSqlServer("Server=DESKTOP-77N4H71\\SQLEXPRESS;Database=FilmReviewR;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            var context = new MyContext(options.Options);
            Assert.True(context.Films.ToList().Where(p=>p.Country!="ÑØÀ").ToList().Count>1);
            context.Dispose();
        }
    }
}