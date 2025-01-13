using Microsoft.EntityFrameworkCore;
using StarterKit.Models;
using StarterKit.Services;

namespace StarterKit
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .WithOrigins("http://localhost:5097")
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Configure services
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework Core with SQLite
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteDb")));

            // Add HttpContextAccessor and Services
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ILoginService, LoginService>();

            // Configure session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Use CORS before routing
            app.UseCors("AllowReactApp");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable session middleware
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
