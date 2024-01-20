using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Security.Policy;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Infrastructures.Db.SqlServer.Ef.Database
{
    //public class AppUser : IdentityUser<int>
    //{

    //}
    public partial class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        //public void DetachAllEntities()
        //{
        //    //var changedEntriesCopy = this.ChangeTracker.Entries()
        //    //    .Where(e => e.State == EntityState.Added ||
        //    //                e.State == EntityState.Modified ||
        //    //                e.State == EntityState.Deleted)
        //    //    .ToList();

        //    //foreach (var entry in changedEntriesCopy)
        //    //    entry.State = EntityState.Detached;
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auction> Auctions { get; set; }

        public virtual DbSet<Bid> Bids { get; set; }

        public virtual DbSet<Buyer> Buyers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<InvoiceProduct> InvoiceProducts { get; set; }

        public virtual DbSet<Product> Products { get; set; }



        public virtual DbSet<Seller> Sellers { get; set; }

        public virtual DbSet<Stall> Stalls { get; set; }
        public virtual DbSet<ApplicationUser> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Auction>(entity =>
            {



                entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Auction_Seller");
                entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                   .HasForeignKey(d => d.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Auctions_Products");
            });



            modelBuilder.Entity<Bid>(entity =>
            {


                entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Bids_Auction");

                entity.HasOne(d => d.Buyer).WithMany(p => p.Bids)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Bids_Buyers");
            });
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(11);

                entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Buyer).HasForeignKey<Buyer>(d => d.ApplicationUserId);

            });

            modelBuilder.Entity<Category>(entity =>
            {


                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParen)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
                entity.HasData(
                     new Category { Id = 4, Name = "گوشی موبایل و تبلت", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 5, Name = "لپ تاپ و کامپیوتر", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 6, Name = "لوازم خانگی", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 7, Name = "زیبایی و سلامت", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 8, Name = "ورزش و سرگرمی", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 9, Name = "خودرو و لوازم", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 10, Name = "فرهنگ و هنر", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 11, Name = "ابزار", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 12, Name = "ساختمان و فضای عمومی", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 13, Name = "مادر و کودک", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 14, Name = "مد و پوشاک", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 15, Name = "خوراکی ها", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 16, Name = "پت شاپ", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 17, Name = "گوشی موبایل", ParentId = 4, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 18, Name = "تبلت", ParentId = 4, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 19, Name = "هدست و هدفون", ParentId = 4, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 20, Name = "سیم کارت", ParentId = 4, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 21, Name = "لپ تاپ", ParentId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 22, Name = "کامپیوتر ", ParentId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 23, Name = "تجهیزات شبکه", ParentId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 24, Name = "تجهیزات اداری", ParentId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 25, Name = "لوازم جانبی لپ تاپ و کامپیوتر", ParentId = 5, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 26, Name = "دوربین", ParentId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 27, Name = "تهویه سرمایش و گرمایش", ParentId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 28, Name = "لوازم جانبی لوازم خانگی", ParentId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 29, Name = "صوتی و تصویری", ParentId = 6, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 30, Name = "تجهیزات پزشکی", ParentId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 31, Name = "ارایشو زیبایی", ParentId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 32, Name = "لوازم شخصی", ParentId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 33, Name = "عطر و ادکلن", ParentId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 34, Name = "محصولات طبی", ParentId = 7, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 35, Name = "وسایل ورزشی", ParentId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 36, Name = "اسباب بازی", ParentId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 37, Name = "تجهیزات سفر", ParentId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 38, Name = "سرگرمی", ParentId = 8, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 39, Name = "خودرو", ParentId = 9, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 40, Name = "بدنه خودرو", ParentId = 9, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 41, Name = "الکترونیک خودرو", ParentId = 9, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 42, Name = "موتور سیکلت", ParentId = 9, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 43, Name = "لوازم موتور سیکلت", ParentId = 9, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 44, Name = "کتاب و مجلات", ParentId = 10, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 45, Name = "رسانه های صوتی وتصویری", ParentId = 10, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 46, Name = "نرم افزار", ParentId = 10, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 47, Name = "ادوات موسیقی", ParentId = 10, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 48, Name = "اشیا قدیمی وکلکسیونی", ParentId = 10, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 49, Name = "ابزار دستی", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 50, Name = "ابزار و تجهیزات باغبانی", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 51, Name = "ابزار برقی", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 52, Name = "ابزار لوله کشی", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 53, Name = "ابزار نجاری", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 54, Name = "ابزار خراطی", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 55, Name = "تجهیزات ازمایشگاهی", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 56, Name = "تجهیزات الکترونیک", ParentId = 11, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 57, Name = "شیرالات ساختمانی", ParentId = 12, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 58, Name = "تجهیزات اشپز خانه", ParentId = 12, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 59, Name = "دکوراسیون فضای عمومی", ParentId = 12, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 60, Name = "منابع و مخازن", ParentId = 12, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 61, Name = "لوازم گردش و سفر نوزاد", ParentId = 13, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 62, Name = "بهداشت و حمام نوزاد", ParentId = 13, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 63, Name = "وسایل خواب نوزاد", ParentId = 13, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 64, Name = "لباس کودک و نوزاد", ParentId = 13, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 65, Name = "سرگرمی و اموزش کودک", ParentId = 13, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 66, Name = "پوشاک مردانه", ParentId = 14, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 67, Name = "پوشاک زنانه", ParentId = 14, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 68, Name = "زیورالات", ParentId = 14, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 69, Name = "کیف و کفش", ParentId = 14, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 70, Name = "ست هدیه", ParentId = 14, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 71, Name = "کمربند و بند شلوار", ParentId = 14, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 72, Name = "میوه و سبزیجات", ParentId = 15, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 73, Name = "اجیلو خشکبار", ParentId = 15, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 74, Name = "غلات و حبوبات", ParentId = 15, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 75, Name = "قنادی", ParentId = 15, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 76, Name = "سوپر مارکت", ParentId = 15, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 77, Name = "گیاهان دارویی", ParentId = 15, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 78, Name = "درمان و سلامت حیوانات", ParentId = 16, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 79, Name = "پوشاک حیوانات", ParentId = 16, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 80, Name = "لوازم بهداشتی حیوانات", ParentId = 16, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 81, Name = "لوازم نگهداری و بازی حیوانات", ParentId = 16, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 82, Name = "غذای حیوانات", ParentId = 16, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 83, Name = "وسایل اموزشی حیوانات", ParentId = 16, CreatedAt = DateTime.Now, IsDeleted = false }
                                );
            });


            modelBuilder.Entity<Comment>(entity =>
            {


                entity.HasOne(d => d.Buyer).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Comments_Buyers");

                entity.HasOne(d => d.Invoice).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Comments_Products");
                entity.HasData(
                    new Comment { Id = 1, BuyerId = 1, Description = "This is a comment", InvoiceId = 1, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false },
                    new Comment { Id = 2, BuyerId = 1, Description = "This is a comment1", InvoiceId = 2, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false },
                    new Comment { Id = 3, BuyerId = 1, Description = "This is a comment2", InvoiceId = 3, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false }
                                );
            });

            modelBuilder.Entity<Image>(entity =>
            {


                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Product).WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {

                entity.HasOne(d => d.Buyer).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Invoice_Buyers");

                entity.HasOne(d => d.Seller).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Invoice_Seller");
                entity.HasData(
                    new Invoice { Id = 1, BuyerId = 1, SellerId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
                    new Invoice { Id = 2, BuyerId = 1, SellerId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
                    new Invoice { Id = 3, BuyerId = 1, SellerId = 1, CreatedAt = DateTime.Now, IsDeleted = false }

                                );
            });

            modelBuilder.Entity<InvoiceProduct>(entity =>
            {


                entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_InvoiceProduct_Invoice");

                entity.HasOne(d => d.Product).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_InvoiceProduct_Products");
                entity.HasData(
                new InvoiceProduct { Id = 1, InvoiceId = 1, ProductId = 1 },
                new InvoiceProduct { Id = 2, InvoiceId = 2, ProductId = 2 },
                new InvoiceProduct { Id = 3, InvoiceId = 3, ProductId = 3 }
                );
            });

            modelBuilder.Entity<Product>(entity =>
            {

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Products_Category");

                entity.HasOne(d => d.Stall).WithMany(p => p.Products)
                    .HasForeignKey(d => d.StallId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Products_Stalls");
                entity.HasData(
                    new Product { Id = 1, Title = "Product Title1", Price = 10000, Description = "Product Description1", CategoryId = 1, NumberofProducts = 5, BuyerId = 1, StallId = 1, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false },
                    new Product { Id = 2, Title = "Product Title2", Price = 10000, Description = "Product Description2", CategoryId = 2, NumberofProducts = 5, BuyerId = 1, StallId = 1, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false },
                    new Product { Id = 3, Title = "Product Title3", Price = 10000, Description = "Product Description3", CategoryId = 3, NumberofProducts = 5, BuyerId = 1, StallId = 1, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false }
                            );
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Seller).HasForeignKey<Seller>(d => d.ApplicationUserId);

            });


            modelBuilder.Entity<Stall>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Stall)
                    .HasForeignKey<Stall>(d => d.Id)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Stores_Sellers");
                entity.HasData(
                new Stall { Id = 1, Name = "Stall1", IsDeleted = false }
                );
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}