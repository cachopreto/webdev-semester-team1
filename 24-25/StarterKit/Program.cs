using Microsoft.EntityFrameworkCore;
using StarterKit.Models;
using StarterKit.Services;
using StarterKit.Utils;

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
                        .WithOrigins("http://localhost:3000")
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
            builder.Services.AddScoped<LoginService>();

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

//testing 
            // using (var scope = app.Services.CreateScope())
            // {
            //     var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            //     var existingAdmin = dbContext.Admins.FirstOrDefault(a => a.UserName == "www");

            //     if (existingAdmin == null)
            //     {
            //         var newAdmin = new Admin
            //         {
            //             UserName = "www",
            //             Password = EncryptionHelper.EncryptPassword("www")
            //         };

            //         dbContext.Admins.Add(newAdmin);
            //         dbContext.SaveChanges();

            //         Console.WriteLine("✅ Extra admin user created!");
            //     }
            //     else
            //     {
            //         Console.WriteLine("⚠️ Extra admin already exists, skipping insert.");
            //     }
            // }

            // using (var scope = app.Services.CreateScope())
            // {
            //     var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            //     var admins = dbContext.Admins.ToList();

            //     if (admins.Any())
            //     {
            //         Console.WriteLine("Admins in Database:");
            //         foreach (var admin in admins)
            //         {
            //             Console.WriteLine($"ID: {admin.AdminId}, Username: {admin.UserName}");
            //         }
            //     }
            //     else
            //     {
            //         Console.WriteLine("No admins found in the database.");
            //     }
            // }

            app.Run();
        }
    }
}