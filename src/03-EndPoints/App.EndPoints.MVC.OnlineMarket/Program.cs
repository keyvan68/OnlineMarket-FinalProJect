using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.OnlineMarket.Models.AutoMapperViewModels;
using App.Infrastructures.Data.Repositories.AutoMaper;
using App.Infrastructures.Data.Repositories.Repositories;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.MVC.OnlineMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account";
                //options.AccessDeniedPath = "/AccessDenied";
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string  not found.");


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(
                options =>
                {

                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;

                }
                )
            .AddEntityFrameworkStores<AppDbContext>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileVM());
                cfg.AddProfile(new AutoMapperProfileDto());
            });

            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
            #region repository
            builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            builder.Services.AddScoped<IBidRepository, BidRepository>();
            builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ISellerRepository, SellerRepository>();
            builder.Services.AddScoped<IStallRepository, StallRepository>();
            builder.Services.AddScoped<IAccountApplicationRepository, AccountApplicationRepository>();
            builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();

            #endregion repository

            #region ApplicationService
            builder.Services.AddScoped<IApplicationUserApplicationService, ApplicationUserApplicationService>();
            builder.Services.AddScoped<IAccountApplicationService, AccountApplicationService>();
            builder.Services.AddScoped<IAuctionApplicationService, AuctionApplicationService>();
            builder.Services.AddScoped<IBidApplicationService, BidApplicationService>();
            builder.Services.AddScoped<IBuyerApplicationService, BuyerApplicationService>();
            builder.Services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
            builder.Services.AddScoped<ICommentApplicationService, CommentApplicationService>();
            builder.Services.AddScoped<IImageApplicationService, ImageApplicationService>();
            builder.Services.AddScoped<IInvoiceApplicationService, InvoiceApplicationService>();
            builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();
            builder.Services.AddScoped<ISellerApplicationService, SellerApplicationService>();
            builder.Services.AddScoped<IStallApplicationService, StallApplicationService>();
            #endregion ApplicationService



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

            app.MapAreaControllerRoute(
                name: "areas",
                areaName: "Admin",
                pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapAreaControllerRoute(
            // areaName: "Admin",
            // name: "areas",
            // pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            //app.MapAreaControllerRoute(
            //    name: "admin",
            //    areaName: "Admin",
            //    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
            //);

            app.Run();
        }
    }
}