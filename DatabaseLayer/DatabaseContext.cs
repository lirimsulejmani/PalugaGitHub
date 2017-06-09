using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DegreeProgram> DegreePrograms { get; set; }
        public DbSet<EducationDegree> EducationDegrees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SellingBook> SellingBooks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudyCourse> StudyCourses { get; set; }
        public DbSet<StudyCourseBook> StudyCourseBooks { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<BookProviderClicksLog> BookProviderClicksLogs { get; set; }
    }
}
