using Kidega.Core.Mappings;
using Kidega.Core.ServiceContracts;
using Kidega.Core.Services;
using Kidega.Domain.RepositoryContracts;
using Kidega.Infrastructure.DatabaseContexts;
using Kidega.Infrastructure.Repositories;
using Kidega.Web.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kidega.Web.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
        public static IServiceCollection ConfigureCookies(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            return services;
        }
        public static IServiceCollection ConfigureCaches(this IServiceCollection services)
        {
            //services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddResponseCaching();
            return services;
        }
        public static IServiceCollection ConfigureInjections(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlingFilter>(); // Exception Handling filter to handle exceptions

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
