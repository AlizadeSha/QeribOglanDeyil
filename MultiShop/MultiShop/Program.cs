using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;

namespace MultiShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>();
            var app = builder.Build();
            app.UseStaticFiles();
            
            app.MapControllerRoute(
                "default",
                "{controller=home}/{action=index}"
                );

            app.Run();
        }
    }
}
