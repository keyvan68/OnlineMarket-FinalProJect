using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructures.Db.SqlServer.Ef.Migrations
{
    public partial class hasdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 9, 17, 33, 51, 284, DateTimeKind.Local).AddTicks(8149), null, null, false, null, "Category Name", null },
                    { 2, new DateTime(2023, 6, 9, 17, 33, 51, 284, DateTimeKind.Local).AddTicks(8168), null, null, false, null, "Category Name2", null },
                    { 3, new DateTime(2023, 6, 9, 17, 33, 51, 284, DateTimeKind.Local).AddTicks(8170), null, null, false, null, "Category Name3", null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BuyerId", "Commision", "CreatedAt", "DeletedAt", "Final", "IsDeleted", "LastModifiedAt", "SellerId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 6, 9, 17, 33, 51, 285, DateTimeKind.Local).AddTicks(9851), null, false, false, null, 1, 0 },
                    { 2, 1, null, new DateTime(2023, 6, 9, 17, 33, 51, 285, DateTimeKind.Local).AddTicks(9859), null, false, false, null, 1, 0 },
                    { 3, 1, null, new DateTime(2023, 6, 9, 17, 33, 51, 285, DateTimeKind.Local).AddTicks(9861), null, false, false, null, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Stalls",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImageUrl", "IsDeleted", "LastModifiedAt", "Name" },
                values: new object[] { 1, null, null, null, false, null, "Stall1" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BuyerId", "CreatedAt", "DeletedAt", "Description", "InvoiceId", "IsAccepted", "IsDeleted", "LastModifiedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 9, 17, 33, 51, 285, DateTimeKind.Local).AddTicks(2761), null, "This is a comment", 1, false, false, null },
                    { 2, 1, new DateTime(2023, 6, 9, 17, 33, 51, 285, DateTimeKind.Local).AddTicks(2768), null, "This is a comment1", 2, false, false, null },
                    { 3, 1, new DateTime(2023, 6, 9, 17, 33, 51, 285, DateTimeKind.Local).AddTicks(2772), null, "This is a comment2", 3, false, false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Auction", "BuyerId", "CategoryId", "CreatedAt", "DeletedAt", "Description", "IsAccepted", "IsDeleted", "LastModifiedAt", "NumberofProducts", "Price", "StallId", "Title" },
                values: new object[,]
                {
                    { 1, false, 1, 1, new DateTime(2023, 6, 9, 17, 33, 51, 286, DateTimeKind.Local).AddTicks(8860), null, "Product Description1", false, false, null, 5, 10000, 1, "Product Title1" },
                    { 2, false, 1, 2, new DateTime(2023, 6, 9, 17, 33, 51, 286, DateTimeKind.Local).AddTicks(8870), null, "Product Description2", false, false, null, 5, 10000, 1, "Product Title2" },
                    { 3, false, 1, 3, new DateTime(2023, 6, 9, 17, 33, 51, 286, DateTimeKind.Local).AddTicks(8874), null, "Product Description3", false, false, null, 5, 10000, 1, "Product Title3" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "Id", "InvoiceId", "ProductId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "Id", "InvoiceId", "ProductId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "Id", "InvoiceId", "ProductId" },
                values: new object[] { 3, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stalls",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
