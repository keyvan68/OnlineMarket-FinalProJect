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
                     new Category { Id = 1, Name = "Category Name", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 2, Name = "Category Name2", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false },
                     new Category { Id = 3, Name = "Category Name3", ParentId = null, CreatedAt = DateTime.Now, IsDeleted = false }
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
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_InvoiceProduct_Invoice");

                entity.HasOne(d => d.Product).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.NoAction)
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