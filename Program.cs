using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DailyQuotes.Data;
using DailyQuotes.Models;
using Microsoft.AspNetCore.Identity;
namespace DailyQuotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Konfigurasi Database dan Identity
            builder.Services.AddDbContext<DailyQuotesContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DailyQuotesContext")
                    ?? throw new InvalidOperationException("Connection string 'DailyQuotesContext' not found.")));

            // Tambahkan Identity
            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<DailyQuotesContext>();
            builder.Services.AddRazorPages(); // Tambahkan ini untuk UI Identity


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

          
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
