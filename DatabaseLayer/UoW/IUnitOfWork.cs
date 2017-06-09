using System;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using DatabaseLayer.Repository;

namespace DatabaseLayer.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<BookProviderClicksLog> BookProviderClicksLogRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<DegreeProgram> DegreeProgramRepository { get; }
        IGenericRepository<EducationDegree> EducationDegreeRepository { get; }
        IGenericRepository<Notification> NotificationRepository { get; }
        IGenericRepository<Rating> RatingRepository { get; }
        IGenericRepository<School> SchoolRepository { get; }
        IGenericRepository<SellingBook> SellingBookRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<StudyCourse> StudyCourseRepository { get; }
        IGenericRepository<StudyCourseBook> StudyCourseBookRepository { get; }
        IGenericRepository<Wishlist> WishlistRepository { get; }
        
        void Commit();
        Task CommitAsync();
    }
}
