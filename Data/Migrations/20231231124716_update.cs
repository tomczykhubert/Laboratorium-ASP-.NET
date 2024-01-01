using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "ce379968-20f0-4743-add9-a65c533eb99b", "ce379968-20f0-4743-add9-a65c533eb99b", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "71945819-8677-440c-97c4-974c710e01aa", 0, "1b823dc6-3d2b-4c01-bb27-c6eac56c619c", "hubert@wsei.edu.pl", true, false, null, "HUBERT@WSEI.EDU.PL", "HUBERT", "AQAAAAEAACcQAAAAEDrLbsUqKCQH0S+7PoHdhOIgjGBIemzrKJbrQDhT5ePJbtHeSZukWXJqFLcDtgJihg==", null, false, "9814cbdd-820b-4bf7-af20-18346c4a553c", false, "Hubert" },
                    { "fb7ebbf9-220b-4230-b5a9-7ad0220a4f7a", 0, "47258aa4-4a69-4022-8126-551529c709a9", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEPII+EPBbdzSLsU6nkU4N+9QEU+NMuU23UJCrQV1gYuA6FRcAWJ3S/91PHwhb0hSdw==", null, false, "e29ee958-a055-4305-84a7-5d28fdade594", false, "adam" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "PublicationDate",
                value: new DateTime(2023, 12, 31, 13, 47, 15, 907, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce379968-20f0-4743-add9-a65c533eb99b", "fb7ebbf9-220b-4230-b5a9-7ad0220a4f7a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce379968-20f0-4743-add9-a65c533eb99b", "fb7ebbf9-220b-4230-b5a9-7ad0220a4f7a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71945819-8677-440c-97c4-974c710e01aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce379968-20f0-4743-add9-a65c533eb99b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb7ebbf9-220b-4230-b5a9-7ad0220a4f7a");

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
    }
}
