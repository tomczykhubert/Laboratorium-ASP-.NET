using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "b01748ff-c1f0-437a-a0c5-4b3eaa521908" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441c4ab7-b51c-4b95-90f5-c1aa0006da32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01748ff-c1f0-437a-a0c5-4b3eaa521908");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3db9f325-4efa-4a73-b983-5ca4cfea6010", "3db9f325-4efa-4a73-b983-5ca4cfea6010", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "15bd235a-47e6-4581-8ed5-eda87cf350e5", 0, "5fc8cfc8-7597-45b3-a832-5307c8c02859", "hubert@wsei.edu.pl", true, false, null, "HUBERT@WSEI.EDU.PL", "HUBERT", "AQAAAAEAACcQAAAAEOtXM2dyXd4AAgnH55ZB9Zshg9bjgnc6sp+oiYfsLbPhPl7Q5wLMU9dciepDlsja1Q==", null, false, "3ce0e559-7fe2-4049-b352-06c87c9d7a7f", false, "Hubert" },
                    { "3ef29327-691e-4399-84e4-a02d0ef14c85", 0, "850dc636-f13e-4f9c-8847-30435c37beed", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEPUO1lXPommlqnte1tEHGulCclY7hmf9Y4ygHQ9M2DMGJrOyjqAycN7/yFXoIi6m1g==", null, false, "83494dad-b1e8-4244-ae5e-add918dc3568", false, "adam" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 30, 10, 45, 49, 347, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3db9f325-4efa-4a73-b983-5ca4cfea6010", "3ef29327-691e-4399-84e4-a02d0ef14c85" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3db9f325-4efa-4a73-b983-5ca4cfea6010", "3ef29327-691e-4399-84e4-a02d0ef14c85" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15bd235a-47e6-4581-8ed5-eda87cf350e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3db9f325-4efa-4a73-b983-5ca4cfea6010");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ef29327-691e-4399-84e4-a02d0ef14c85");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b01748ff-c1f0-437a-a0c5-4b3eaa521908", 0, "2bd780e2-ade4-4860-9cf2-52962dc64be4", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEJSSWfsXq8sH0AndN5ha5qV8azcbpkO4nTN5kVtwxb4wGeXfCdOLyHuscyxb5MCS4w==", null, false, "28f8d69e-d3a8-458a-bad6-60eafc016fe5", false, "adam" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5688));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "b01748ff-c1f0-437a-a0c5-4b3eaa521908" });
        }
    }
}
