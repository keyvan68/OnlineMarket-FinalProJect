using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructures.Db.SqlServer.Ef.Migrations
{
    public partial class CreateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(164), null, null, false, null, "گوشی موبایل و تبلت", null },
                    { 5, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(181), null, null, false, null, "لپ تاپ و کامپیوتر", null },
                    { 6, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(184), null, null, false, null, "لوازم خانگی", null },
                    { 7, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(186), null, null, false, null, "زیبایی و سلامت", null },
                    { 8, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(190), null, null, false, null, "ورزش و سرگرمی", null },
                    { 9, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(191), null, null, false, null, "خودرو و لوازم", null },
                    { 10, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(194), null, null, false, null, "فرهنگ و هنر", null },
                    { 11, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(196), null, null, false, null, "ابزار", null },
                    { 12, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(198), null, null, false, null, "ساختمان و فضای عمومی", null },
                    { 13, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(200), null, null, false, null, "مادر و کودک", null },
                    { 14, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(273), null, null, false, null, "مد و پوشاک", null },
                    { 15, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(275), null, null, false, null, "خوراکی ها", null },
                    { 16, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(278), null, null, false, null, "پت شاپ", null }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 80, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 80, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 26, 21, 1, 6, 80, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 17, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(280), null, null, false, null, "گوشی موبایل", 4 },
                    { 18, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(282), null, null, false, null, "تبلت", 4 },
                    { 19, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(283), null, null, false, null, "هدست و هدفون", 4 },
                    { 20, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(285), null, null, false, null, "سیم کارت", 4 },
                    { 21, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(289), null, null, false, null, "لپ تاپ", 5 },
                    { 22, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(291), null, null, false, null, "کامپیوتر ", 5 },
                    { 23, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(293), null, null, false, null, "تجهیزات شبکه", 5 },
                    { 24, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(295), null, null, false, null, "تجهیزات اداری", 5 },
                    { 25, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(297), null, null, false, null, "لوازم جانبی لپ تاپ و کامپیوتر", 5 },
                    { 26, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(300), null, null, false, null, "دوربین", 6 },
                    { 27, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(302), null, null, false, null, "تهویه سرمایش و گرمایش", 6 },
                    { 28, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(304), null, null, false, null, "لوازم جانبی لوازم خانگی", 6 },
                    { 29, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(305), null, null, false, null, "صوتی و تصویری", 6 },
                    { 30, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(307), null, null, false, null, "تجهیزات پزشکی", 7 },
                    { 31, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(309), null, null, false, null, "ارایشو زیبایی", 7 },
                    { 32, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(311), null, null, false, null, "لوازم شخصی", 7 },
                    { 33, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(313), null, null, false, null, "عطر و ادکلن", 7 },
                    { 34, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(315), null, null, false, null, "محصولات طبی", 7 },
                    { 35, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(317), null, null, false, null, "وسایل ورزشی", 8 },
                    { 36, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(319), null, null, false, null, "اسباب بازی", 8 },
                    { 37, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(321), null, null, false, null, "تجهیزات سفر", 8 },
                    { 38, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(323), null, null, false, null, "سرگرمی", 8 },
                    { 39, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(325), null, null, false, null, "خودرو", 9 },
                    { 40, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(328), null, null, false, null, "بدنه خودرو", 9 },
                    { 41, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(330), null, null, false, null, "الکترونیک خودرو", 9 },
                    { 42, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(332), null, null, false, null, "موتور سیکلت", 9 },
                    { 43, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(334), null, null, false, null, "لوازم موتور سیکلت", 9 },
                    { 44, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(336), null, null, false, null, "کتاب و مجلات", 10 },
                    { 45, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(338), null, null, false, null, "رسانه های صوتی وتصویری", 10 },
                    { 46, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(340), null, null, false, null, "نرم افزار", 10 },
                    { 47, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(341), null, null, false, null, "ادوات موسیقی", 10 },
                    { 48, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(344), null, null, false, null, "اشیا قدیمی وکلکسیونی", 10 },
                    { 49, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(345), null, null, false, null, "ابزار دستی", 11 },
                    { 50, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(347), null, null, false, null, "ابزار و تجهیزات باغبانی", 11 },
                    { 51, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(349), null, null, false, null, "ابزار برقی", 11 },
                    { 52, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(351), null, null, false, null, "ابزار لوله کشی", 11 },
                    { 53, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(353), null, null, false, null, "ابزار نجاری", 11 },
                    { 54, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(354), null, null, false, null, "ابزار خراطی", 11 },
                    { 55, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(357), null, null, false, null, "تجهیزات ازمایشگاهی", 11 },
                    { 56, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(359), null, null, false, null, "تجهیزات الکترونیک", 11 },
                    { 57, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(361), null, null, false, null, "شیرالات ساختمانی", 12 },
                    { 58, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(409), null, null, false, null, "تجهیزات اشپز خانه", 12 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 59, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(412), null, null, false, null, "دکوراسیون فضای عمومی", 12 },
                    { 60, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(414), null, null, false, null, "منابع و مخازن", 12 },
                    { 61, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(416), null, null, false, null, "لوازم گردش و سفر نوزاد", 13 },
                    { 62, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(418), null, null, false, null, "بهداشت و حمام نوزاد", 13 },
                    { 63, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(420), null, null, false, null, "وسایل خواب نوزاد", 13 },
                    { 64, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(422), null, null, false, null, "لباس کودک و نوزاد", 13 },
                    { 65, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(424), null, null, false, null, "سرگرمی و اموزش کودک", 13 },
                    { 66, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(426), null, null, false, null, "پوشاک مردانه", 14 },
                    { 67, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(427), null, null, false, null, "پوشاک زنانه", 14 },
                    { 68, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(429), null, null, false, null, "زیورالات", 14 },
                    { 69, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(431), null, null, false, null, "کیف و کفش", 14 },
                    { 70, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(434), null, null, false, null, "ست هدیه", 14 },
                    { 71, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(436), null, null, false, null, "کمربند و بند شلوار", 14 },
                    { 72, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(439), null, null, false, null, "میوه و سبزیجات", 15 },
                    { 73, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(441), null, null, false, null, "اجیلو خشکبار", 15 },
                    { 74, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(443), null, null, false, null, "غلات و حبوبات", 15 },
                    { 75, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(444), null, null, false, null, "قنادی", 15 },
                    { 76, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(446), null, null, false, null, "سوپر مارکت", 15 },
                    { 77, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(448), null, null, false, null, "گیاهان دارویی", 15 },
                    { 78, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(450), null, null, false, null, "درمان و سلامت حیوانات", 16 },
                    { 79, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(451), null, null, false, null, "پوشاک حیوانات", 16 },
                    { 80, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(454), null, null, false, null, "لوازم بهداشتی حیوانات", 16 },
                    { 81, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(456), null, null, false, null, "لوازم نگهداری و بازی حیوانات", 16 },
                    { 82, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(457), null, null, false, null, "غذای حیوانات", 16 },
                    { 83, new DateTime(2023, 6, 26, 21, 1, 6, 79, DateTimeKind.Local).AddTicks(459), null, null, false, null, "وسایل اموزشی حیوانات", 16 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImgUrl", "IsDeleted", "LastModifiedAt", "name", "ParentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 18, 16, 30, 24, 890, DateTimeKind.Local).AddTicks(9575), null, null, false, null, "Category Name", null },
                    { 2, new DateTime(2023, 6, 18, 16, 30, 24, 890, DateTimeKind.Local).AddTicks(9593), null, null, false, null, "Category Name2", null },
                    { 3, new DateTime(2023, 6, 18, 16, 30, 24, 890, DateTimeKind.Local).AddTicks(9595), null, null, false, null, "Category Name3", null }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 891, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 891, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 891, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 891, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 891, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 891, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 892, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 892, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 18, 16, 30, 24, 892, DateTimeKind.Local).AddTicks(4123));
        }
    }
}
