using Games.Data;
using Games.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("defaultconnection") ?? throw new InvalidOperationException("sorry but no connection");
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Applicationcontext>(option => option.UseSqlServer(connection));

            // register some services
            builder.Services.AddScoped<ICategoryservice, CategoryService>();
            builder.Services.AddScoped<IDeviceService, DevicesServices>();
            builder.Services.AddTransient<IGameService, GameService>();



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