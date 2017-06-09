using DatabaseLayer;
using DatabaseLayer.UoW;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.APIs;

namespace Paluga.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            var connection = Configuration.GetSection("Data:ConnectionString").Value;
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            DbContextOptionsBuilder<DatabaseContext> builder = new DbContextOptionsBuilder<DatabaseContext>();
            UnitOfWork.DbContextOptions = builder.UseSqlServer(connection);

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookProviderClicksLogService, BookProviderClicksLogService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDegreeProgramService, DegreeProgramService>();
            services.AddScoped<IEducationDegreeService, EducationDegreeService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISellingBookService, SellingBookService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudyCourseBookService, StudyCourseBookService>();
            services.AddScoped<IStudyCourseService, StudyCourseService>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

            return services;
        }
    }
}
