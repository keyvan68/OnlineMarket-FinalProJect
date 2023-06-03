using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Security.Policy;
using static System.Formats.Asn1.AsnWriter;

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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<ApplicationUser>().HasData(
            //new ApplicationUser { Id = 1, Email = "user1@example.com", EmailConfirmed = true, PhoneNumber = "09129999999", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username1", SecurityStamp = "", ConcurrencyStamp = "", PasswordHash = hasher.HashPassword() },
            //new ApplicationUser { Id = 2, Email = "user2@example.com", EmailConfirmed = true, PhoneNumber = "09129999999", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username2", SecurityStamp = "", ConcurrencyStamp = "", PasswordHash = "1224".GetHashCode().ToString() },
            //new ApplicationUser { Id = 3, Email = "user3@example.com", EmailConfirmed = true, PhoneNumber = "09129999999", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username3", SecurityStamp = "", ConcurrencyStamp = "", PasswordHash = "1256".GetHashCode().ToString() },
            //new ApplicationUser { Id = 4, Email = "user4@example.com", EmailConfirmed = true, PhoneNumber = "09129999999", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username4", SecurityStamp = "", ConcurrencyStamp = "", PasswordHash = "1212".GetHashCode().ToString() },
            //new ApplicationUser { Id = 5, Email = "user5@example.com", EmailConfirmed = true, PhoneNumber = "09129999999", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username5", SecurityStamp = "", ConcurrencyStamp = "", PasswordHash = "1267".GetHashCode().ToString() },
            //new ApplicationUser { Id = 6, Email = "user6@example.com", EmailConfirmed = true, PhoneNumber = "09129999999", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UserName = "AppUser1username6", SecurityStamp = "", ConcurrencyStamp = "", PasswordHash = "1245".GetHashCode().ToString() }


            //);

            //modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            //    new IdentityUserRole<int> { UserId = 1, RoleId = 2 },
            //    new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
            //    new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
            //    new IdentityUserRole<int> { UserId = 4, RoleId = 3 },
            //    new IdentityUserRole<int> { UserId = 5, RoleId = 3 },
            //    new IdentityUserRole<int> { UserId = 6, RoleId = 3 }
            //    );

            //modelBuilder.Entity<IdentityRole<int>>().HasData(
            //    new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            //    new IdentityRole<int> { Id = 2, Name = "Buyer", NormalizedName = "BUYER" },
            //    new IdentityRole<int> { Id = 3, Name = "Seller", NormalizedName = "SELLER" }
            //    );
            modelBuilder.Entity<Auction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Auction__3214EC071A6D0BF4");

                entity.HasIndex(e => e.Id, "IX_Auctions_1").IsUnique();

                entity.HasIndex(e => e.SellerId, "IX_Auctions_SellerId");

                entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Auction_Seller");
            });



            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Bids__3214EC0781B747A2");

                entity.HasIndex(e => e.Id, "IX_Bids_1").IsUnique();

                entity.HasIndex(e => e.AuctionId, "IX_Bids_AuctionId");

                entity.HasIndex(e => e.BuyerId, "IX_Bids_BuyerId");

                entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bids_Auction");

                entity.HasOne(d => d.Buyer).WithMany(p => p.Bids)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bids_Buyers");
            });
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Buyers__3214EC0784B1BC85");

                entity.HasIndex(e => e.Id, "IX_Buyers_1").IsUnique();

                entity.HasIndex(e => e.ApplicationUserId, "IX_Buyers_ApplicationUserId").IsUnique();

                entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Buyer).HasForeignKey<Buyer>(d => d.ApplicationUserId);
                //    entity.HasData(
                //        new Buyer { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123456789", Birthdayte = new DateTime(1990, 1, 1), Address = "123 Main St", ApplicationUserId = 1 },
                //        new Buyer { Id = 2, FirstName = "John1", LastName = "Doe1", PhoneNumber = "123456789", Birthdayte = new DateTime(1990, 1, 1), Address = "123 Main St", ApplicationUserId = 2 },
                //        new Buyer { Id = 3, FirstName = "John2", LastName = "Doe2", PhoneNumber = "123456789", Birthdayte = new DateTime(1990, 1, 1), Address = "123 Main St", ApplicationUserId = 3 }
                //);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Category__3214EC074A2FB85E");

                entity.HasIndex(e => e.ParentId, "IX_Categories_ParenId");

                entity.HasIndex(e => e.Id, "IX_Categorys_1").IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParen)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
                //entity.HasData(
                //     new Category{Id = 1,Name = "Category Name",ParenId = null,CreatedAt = DateTime.Now,IsDeleted = false},
                //     new Category{Id = 2,Name = "Category Name2",ParenId = null,CreatedAt = DateTime.Now,IsDeleted = false},
                //     new Category{Id = 3,Name = "Category Name3",ParenId = null,CreatedAt = DateTime.Now,IsDeleted = false}
                //                );
            });


            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC073B5475E5");

                entity.HasIndex(e => e.Id, "IX_Comments_1").IsUnique();

                entity.HasIndex(e => e.BuyerId, "IX_Comments_BuyerId");

                entity.HasIndex(e => e.InvoiceId, "IX_Comments_InvoiceId");

                entity.HasOne(d => d.Buyer).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Buyers");

                entity.HasOne(d => d.Invoice).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Products");
                //entity.HasData(
                //    new Comment { Id = 1, BuyerId = 1, Description = "This is a comment",InvoiceId=1 ,IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false },
                //    new Comment { Id = 2, BuyerId = 2, Description = "This is a comment1", InvoiceId = 2, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false },
                //    new Comment { Id = 3, BuyerId = 3, Description = "This is a comment2", InvoiceId = 3, IsAccepted = false, CreatedAt = DateTime.Now, IsDeleted = false }
                //                );
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Gallery__43D54A714F55D535");

                entity.HasIndex(e => e.Id, "IX_Galleries_1").IsUnique();

                entity.HasIndex(e => e.ProductId, "IX_Images_ProductId");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Product).WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC075E6685F1");

                entity.HasIndex(e => e.Id, "IX_Carts_1").IsUnique();

                entity.HasIndex(e => e.BuyerId, "IX_Invoices_BuyerId");

                entity.HasIndex(e => e.SellerId, "IX_Invoices_SellerId");

                entity.Property(e => e.Commision).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Buyer).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Buyers");

                entity.HasOne(d => d.Seller).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Seller");
                //entity.HasData(
                //    new Invoice { Id = 1, BuyerId = 1,SellerId=1, CreatedAt = DateTime.Now, IsDeleted = false },
                //    new Invoice { Id = 2, BuyerId = 2,SellerId=2, CreatedAt = DateTime.Now, IsDeleted = false },
                //    new Invoice { Id = 3, BuyerId = 3,SellerId=3, CreatedAt = DateTime.Now, IsDeleted = false }

                //                );
            });

            modelBuilder.Entity<InvoiceProduct>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_InvoiceProducts_1").IsUnique();

                entity.HasIndex(e => e.InvoiceId, "IX_InvoiceProducts_InvoiceId");

                entity.HasIndex(e => e.ProductId, "IX_InvoiceProducts_ProductId");

                entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceProduct_Invoice");

                entity.HasOne(d => d.Product).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceProduct_Products");
                //entity.HasData(
                //new InvoiceProduct{Id = 1,InvoiceId = 1,ProductId = 1},
                //new InvoiceProduct{Id = 2,InvoiceId = 2,ProductId = 2},
                //new InvoiceProduct{Id = 3,InvoiceId = 3,ProductId = 3}
                //);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07B0E58F7C");

                entity.HasIndex(e => e.Id, "IX_Products_1").IsUnique();

                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

                entity.HasIndex(e => e.StallId, "IX_Products_StallId");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Category");

                entity.HasOne(d => d.Stall).WithMany(p => p.Products)
                    .HasForeignKey(d => d.StallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Stalls");
                //entity.HasData(
                //    new Product{Id = 1,Title = "Product Title1",Price = 10.99m,Description = "Product Description1", CategoryId = 1,NumberofProducts = 5,BuyerId = 1,StallId = 1,IsAccepted = false,CreatedAt = DateTime.Now,IsDeleted = false},
                //    new Product{Id = 2,Title = "Product Title2",Price = 10.99m,Description = "Product Description2", CategoryId = 2, NumberofProducts = 5,BuyerId = 2,StallId = 2,IsAccepted = false,CreatedAt = DateTime.Now,IsDeleted = false},
                //    new Product{Id = 3,Title = "Product Title3",Price = 10.99m,Description = "Product Description3", CategoryId = 3, NumberofProducts = 5,BuyerId = 3,StallId = 3,IsAccepted = false,CreatedAt = DateTime.Now,IsDeleted = false}
                //            );
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Seller__3214EC07F9D7534D");

                entity.HasIndex(e => e.Id, "IX_Sellers_1").IsUnique();

                entity.HasIndex(e => e.ApplicationUserId, "IX_Sellers_ApplicationUserId").IsUnique();


                entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Seller).HasForeignKey<Seller>(d => d.ApplicationUserId);
                //entity.HasData(
                //    new Seller { Id = 1, Name = "Seller1", FirstName = "John", LastName = "Doe", Address = "123 Main St", PhoneNumber = "123456789", CommissionAmount = 10, ApplicationUserId = 4, Birthdate = new DateTime(1990, 1, 1) },
                //    new Seller { Id = 2, Name = "Seller2", FirstName = "John", LastName = "Doe", Address = "123 Main St", PhoneNumber = "123456789", CommissionAmount = 10, ApplicationUserId = 5, Birthdate = new DateTime(1990, 1, 1) },
                //    new Seller { Id = 3, Name = "Seller3", FirstName = "John", LastName = "Doe", Address = "123 Main St", PhoneNumber = "123456789", CommissionAmount = 10, ApplicationUserId = 6, Birthdate = new DateTime(1990, 1, 1) }
                //             );
                //entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Seller)
                //    .HasForeignKey<Seller>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Seller_User");
            });

           
            modelBuilder.Entity<Stall>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Stall)
                    .HasForeignKey<Stall>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stores_Sellers");
                //entity.HasData(
                //new Stall { Id = 1, Name = "Stall1", IsDeleted = false },
                //new Stall { Id = 2, Name = "Stall2", IsDeleted = false },
                //new Stall { Id = 3, Name = "Stall3", IsDeleted = false }
                //);
            });

       

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}