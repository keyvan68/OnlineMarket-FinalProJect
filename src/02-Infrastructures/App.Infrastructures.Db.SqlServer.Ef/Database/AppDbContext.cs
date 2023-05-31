using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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


        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MarketPlaceDB;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUser>().ToTable("Users");
            //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            //modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            //modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            modelBuilder.Entity<Auction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Auction__3214EC071A6D0BF4");

                entity.ToTable("Auction");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Auction_Seller");
            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Bids__3214EC0781B747A2");

                entity.Property(e => e.Id).ValueGeneratedNever();

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

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(x => x.ApplicationUser).WithOne(x => x.Buyer);
                
                //entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Buyer)
                //    .HasForeignKey<Buyer>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Buyers_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Category__3214EC074A2FB85E");

                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Paren).WithMany(p => p.InverseParen)
                    .HasForeignKey(d => d.ParenId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC073B5475E5");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Buyer).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Buyers");

                entity.HasOne(d => d.Invoice).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Products");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Gallery__43D54A714F55D535");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Product).WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC075E6685F1");

                entity.ToTable("Invoice");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Buyer).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Buyers");

                entity.HasOne(d => d.Seller).WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Seller");
            });

            modelBuilder.Entity<InvoiceProduct>(entity =>
            {
                entity.ToTable("InvoiceProduct");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceProduct_Invoice");

                entity.HasOne(d => d.Product).WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceProduct_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07B0E58F7C");

                entity.Property(e => e.Id).ValueGeneratedNever();
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
            });


            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Seller__3214EC07F9D7534D");

                entity.ToTable("Seller");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.HasOne(x => x.ApplicationUser).WithOne(x => x.Seller);
                //entity.HasOne(d => d.ApplicationUser).WithOne(p => p.Seller)
                //    .HasForeignKey<Seller>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Seller_User");
            });

            modelBuilder.Entity<Stall>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Stalls__3214EC07E433056E");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Stall)
                    .HasForeignKey<Stall>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stalls_Seller");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}