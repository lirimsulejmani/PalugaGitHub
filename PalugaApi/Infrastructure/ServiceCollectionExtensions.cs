using DatabaseLayer;
using DatabaseLayer.UoW;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PalugaApi.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            var connection = Configuration.GetSection("Data:ConnectionString").Value;
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            DbContextOptionsBuilder<DatabaseContext> builder = new DbContextOptionsBuilder<DatabaseContext>();
            UnitOfWork.DbContextOptions = builder.UseSqlServer(connection);

            services.AddScoped<IBookService, BookService>()
                .AddScoped<IBookProviderClicksLogService, BookProviderClicksLogService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IDegreeProgramService, DegreeProgramService>()
                .AddScoped<IEducationDegreeService, EducationDegreeService>()
                .AddScoped<INotificationService, NotificationService>()
                .AddScoped<IRatingService, RatingService>()
                .AddScoped<ISchoolService, SchoolService>()
                .AddScoped<ISellingBookService, SellingBookService>()
                .AddScoped<IStudentService, StudentService>()
                .AddScoped<IStudyCourseBookService, StudyCourseBookService>()
                .AddScoped<IStudyCourseService, StudyCourseService>()
                .AddScoped<IWishlistService, WishlistService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IMailService, MailService>()
                .AddScoped<ISecurityService, SecurityService>()
                .AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

            return services;
        }
    }
}
