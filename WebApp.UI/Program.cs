using Microsoft.EntityFrameworkCore;
using WebApp.BL.Repository;
using WebApp.Data.Entities;

namespace WebApp.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var constr = "Initial Catalog=MyShopDB;Data source=(localdb)\\mssqllocaldb;Integrated Security=true";
            builder.Services.AddDbContext<MyShopContext>(
                options=> options.UseSqlServer(constr));

            builder.Services.AddTransient<CategoryRepository>();
            builder.Services.AddTransient<ProductRepository>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}