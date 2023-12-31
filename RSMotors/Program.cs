using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using RSMotors.Core.Interfaces;
using RSMotors.Core.Services;
using RSMotors.Infrastructure;
using RSMotors.Infrastructure.Models;

namespace RSMotors.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("RSMotorsDbContextConnection") ?? 
                throw new InvalidOperationException("Connection string 'RSMotorsDbContextConnection' not found.");

            builder.Services.AddDbContext<RSMotorsDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SingIn:ReqireConfirmeAccount");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Password:RequireLowercase");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Password:RequireUppercase");
                options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Password:RequireDigit");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Password:RequiredLength");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Password:RequireNonAlphanumeric");
            })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<RSMotorsDbContext>()
                .AddDefaultTokenProviders();

			builder.Services.AddScoped<ICarServices, CarService>();
			builder.Services.AddScoped<ICustomerServices, CustomerService>();

			builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}