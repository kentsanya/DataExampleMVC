using DataExampleMVC.Data.Repository;
using DataExampleMVC.Models;
using Microsoft.Data.SqlClient;

namespace DataExampleMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string conectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<IRepository<Course>, CourseRepository>(proveder=>new CourseRepository(conectionstring));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}