using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructures.Db.SqlServer.Ef.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdayte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionAmount = table.Column<int>(type: "int", nullable: false),
                    Medal = table.Column<bool>(type: "bit", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Final = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Commision = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Buyers",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_Seller",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Sellers",
                        column: x => x.Id,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Buyers",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Products",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberofProducts = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    StallId = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Auction = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Stalls",
                        column: x => x.StallId,
                        principalTable: "Stalls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HighestBid = table.Column<int>(type: "int", nullable: false),
                    DeactiveProduct = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auction_Seller",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Auctions_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Invoice",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Products",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Auction",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bids_Buyers",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6678), null, null, false, null, "گوشی موبایل و تبلت", null },
                    { 5, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6696), null, null, false, null, "لپ تاپ و کامپیوتر", null },
                    { 6, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6699), null, null, false, null, "لوازم خانگی", null },
                    { 7, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6701), null, null, false, null, "زیبایی و سلامت", null },
                    { 8, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6702), null, null, false, null, "ورزش و سرگرمی", null },
                    { 9, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6704), null, null, false, null, "خودرو و لوازم", null },
                    { 10, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6706), null, null, false, null, "فرهنگ و هنر", null },
                    { 11, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6708), null, null, false, null, "ابزار", null },
                    { 12, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6709), null, null, false, null, "ساختمان و فضای عمومی", null },
                    { 13, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6711), null, null, false, null, "مادر و کودک", null },
                    { 14, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6713), null, null, false, null, "مد و پوشاک", null },
                    { 15, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6715), null, null, false, null, "خوراکی ها", null },
                    { 16, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6717), null, null, false, null, "پت شاپ", null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BuyerId", "Commision", "CreatedAt", "DeletedAt", "Final", "IsDeleted", "LastModifiedAt", "Quantity", "SellerId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 8, 29, 15, 3, 4, 767, DateTimeKind.Local).AddTicks(5858), null, false, false, null, 0, 1, 0 },
                    { 2, 1, null, new DateTime(2023, 8, 29, 15, 3, 4, 767, DateTimeKind.Local).AddTicks(5865), null, false, false, null, 0, 1, 0 },
                    { 3, 1, null, new DateTime(2023, 8, 29, 15, 3, 4, 767, DateTimeKind.Local).AddTicks(5867), null, false, false, null, 0, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stalls",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "Description", "ImageUrl", "IsDeleted", "LastModifiedAt", "Name" },
                values: new object[] { 1, null, null, null, null, null, false, null, "Stall1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 17, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6719), null, null, false, null, "گوشی موبایل", 4 },
                    { 18, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6721), null, null, false, null, "تبلت", 4 },
                    { 19, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6723), null, null, false, null, "هدست و هدفون", 4 },
                    { 20, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6725), null, null, false, null, "سیم کارت", 4 },
                    { 21, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6726), null, null, false, null, "لپ تاپ", 5 },
                    { 22, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6729), null, null, false, null, "کامپیوتر ", 5 },
                    { 23, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6730), null, null, false, null, "تجهیزات شبکه", 5 },
                    { 24, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6732), null, null, false, null, "تجهیزات اداری", 5 },
                    { 25, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6734), null, null, false, null, "لوازم جانبی لپ تاپ و کامپیوتر", 5 },
                    { 26, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6736), null, null, false, null, "دوربین", 6 },
                    { 27, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6737), null, null, false, null, "تهویه سرمایش و گرمایش", 6 },
                    { 28, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6739), null, null, false, null, "لوازم جانبی لوازم خانگی", 6 },
                    { 29, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6741), null, null, false, null, "صوتی و تصویری", 6 },
                    { 30, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6743), null, null, false, null, "تجهیزات پزشکی", 7 },
                    { 31, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6745), null, null, false, null, "ارایشو زیبایی", 7 },
                    { 32, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6748), null, null, false, null, "لوازم شخصی", 7 },
                    { 33, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6750), null, null, false, null, "عطر و ادکلن", 7 },
                    { 34, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6752), null, null, false, null, "محصولات طبی", 7 },
                    { 35, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6754), null, null, false, null, "وسایل ورزشی", 8 },
                    { 36, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6755), null, null, false, null, "اسباب بازی", 8 },
                    { 37, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6757), null, null, false, null, "تجهیزات سفر", 8 },
                    { 38, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6759), null, null, false, null, "سرگرمی", 8 },
                    { 39, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6761), null, null, false, null, "خودرو", 9 },
                    { 40, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6763), null, null, false, null, "بدنه خودرو", 9 },
                    { 41, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6765), null, null, false, null, "الکترونیک خودرو", 9 },
                    { 42, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6820), null, null, false, null, "موتور سیکلت", 9 },
                    { 43, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6822), null, null, false, null, "لوازم موتور سیکلت", 9 },
                    { 44, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6824), null, null, false, null, "کتاب و مجلات", 10 },
                    { 45, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6826), null, null, false, null, "رسانه های صوتی وتصویری", 10 },
                    { 46, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6828), null, null, false, null, "نرم افزار", 10 },
                    { 47, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6831), null, null, false, null, "ادوات موسیقی", 10 },
                    { 48, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6832), null, null, false, null, "اشیا قدیمی وکلکسیونی", 10 },
                    { 49, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6834), null, null, false, null, "ابزار دستی", 11 },
                    { 50, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6836), null, null, false, null, "ابزار و تجهیزات باغبانی", 11 },
                    { 51, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6838), null, null, false, null, "ابزار برقی", 11 },
                    { 52, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6839), null, null, false, null, "ابزار لوله کشی", 11 },
                    { 53, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6841), null, null, false, null, "ابزار نجاری", 11 },
                    { 54, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6843), null, null, false, null, "ابزار خراطی", 11 },
                    { 55, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6845), null, null, false, null, "تجهیزات ازمایشگاهی", 11 },
                    { 56, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6847), null, null, false, null, "تجهیزات الکترونیک", 11 },
                    { 57, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6848), null, null, false, null, "شیرالات ساختمانی", 12 },
                    { 58, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6850), null, null, false, null, "تجهیزات اشپز خانه", 12 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 59, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6852), null, null, false, null, "دکوراسیون فضای عمومی", 12 },
                    { 60, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6853), null, null, false, null, "منابع و مخازن", 12 },
                    { 61, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6855), null, null, false, null, "لوازم گردش و سفر نوزاد", 13 },
                    { 62, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6858), null, null, false, null, "بهداشت و حمام نوزاد", 13 },
                    { 63, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6861), null, null, false, null, "وسایل خواب نوزاد", 13 },
                    { 64, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6863), null, null, false, null, "لباس کودک و نوزاد", 13 },
                    { 65, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6864), null, null, false, null, "سرگرمی و اموزش کودک", 13 },
                    { 66, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6866), null, null, false, null, "پوشاک مردانه", 14 },
                    { 67, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6868), null, null, false, null, "پوشاک زنانه", 14 },
                    { 68, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6870), null, null, false, null, "زیورالات", 14 },
                    { 69, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6872), null, null, false, null, "کیف و کفش", 14 },
                    { 70, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6874), null, null, false, null, "ست هدیه", 14 },
                    { 71, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6875), null, null, false, null, "کمربند و بند شلوار", 14 },
                    { 72, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6877), null, null, false, null, "میوه و سبزیجات", 15 },
                    { 73, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6879), null, null, false, null, "اجیلو خشکبار", 15 },
                    { 74, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6881), null, null, false, null, "غلات و حبوبات", 15 },
                    { 75, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6882), null, null, false, null, "قنادی", 15 },
                    { 76, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6885), null, null, false, null, "سوپر مارکت", 15 },
                    { 77, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6887), null, null, false, null, "گیاهان دارویی", 15 },
                    { 78, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6892), null, null, false, null, "درمان و سلامت حیوانات", 16 },
                    { 79, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6893), null, null, false, null, "پوشاک حیوانات", 16 },
                    { 80, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6895), null, null, false, null, "لوازم بهداشتی حیوانات", 16 },
                    { 81, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6897), null, null, false, null, "لوازم نگهداری و بازی حیوانات", 16 },
                    { 82, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6899), null, null, false, null, "غذای حیوانات", 16 },
                    { 83, new DateTime(2023, 8, 29, 15, 3, 4, 766, DateTimeKind.Local).AddTicks(6900), null, null, false, null, "وسایل اموزشی حیوانات", 16 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BuyerId", "CreatedAt", "DeletedAt", "Description", "InvoiceId", "IsAccepted", "IsDeleted", "LastModifiedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 29, 15, 3, 4, 767, DateTimeKind.Local).AddTicks(565), null, "This is a comment", 1, false, false, null },
                    { 2, 1, new DateTime(2023, 8, 29, 15, 3, 4, 767, DateTimeKind.Local).AddTicks(571), null, "This is a comment1", 2, false, false, null },
                    { 3, 1, new DateTime(2023, 8, 29, 15, 3, 4, 767, DateTimeKind.Local).AddTicks(573), null, "This is a comment2", 3, false, false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Auction", "BuyerId", "CategoryId", "CreatedAt", "DeletedAt", "Description", "IsAccepted", "IsActive", "IsDeleted", "LastModifiedAt", "NumberofProducts", "Price", "StallId", "Title" },
                values: new object[,]
                {
                    { 1, false, 1, 1, new DateTime(2023, 8, 29, 15, 3, 4, 768, DateTimeKind.Local).AddTicks(3211), null, "Product Description1", false, false, false, null, 5, 10000, 1, "Product Title1" },
                    { 2, false, 1, 2, new DateTime(2023, 8, 29, 15, 3, 4, 768, DateTimeKind.Local).AddTicks(3220), null, "Product Description2", false, false, false, null, 5, 10000, 1, "Product Title2" },
                    { 3, false, 1, 3, new DateTime(2023, 8, 29, 15, 3, 4, 768, DateTimeKind.Local).AddTicks(3294), null, "Product Description3", false, false, false, null, 5, 10000, 1, "Product Title3" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "Id", "InvoiceId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "Id", "InvoiceId", "ProductId", "Quantity" },
                values: new object[] { 2, 2, 2, 0 });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "Id", "InvoiceId", "ProductId", "Quantity" },
                values: new object[] { 3, 3, 3, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ProductId",
                table: "Auctions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BuyerId",
                table: "Bids",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_ApplicationUserId",
                table: "Buyers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BuyerId",
                table: "Comments",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_InvoiceId",
                table: "Comments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_InvoiceId",
                table: "InvoiceProducts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_ProductId",
                table: "InvoiceProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BuyerId",
                table: "Invoices",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SellerId",
                table: "Invoices",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StallId",
                table: "Products",
                column: "StallId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_ApplicationUserId",
                table: "Sellers",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "InvoiceProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stalls");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
