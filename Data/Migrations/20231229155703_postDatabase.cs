using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class postDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10bf1a2b-8d41-43e9-98e4-2d81982b89fa", "eac79764-4f8e-4e47-86f4-287e661bd023" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10bf1a2b-8d41-43e9-98e4-2d81982b89fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac79764-4f8e-4e47-86f4-287e661bd023");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b01748ff-c1f0-437a-a0c5-4b3eaa521908", 0, "2bd780e2-ade4-4860-9cf2-52962dc64be4", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEJSSWfsXq8sH0AndN5ha5qV8azcbpkO4nTN5kVtwxb4wGeXfCdOLyHuscyxb5MCS4w==", null, false, "28f8d69e-d3a8-458a-bad6-60eafc016fe5", false, "adam" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[,]
                {
                    { 1, "Polityka" },
                    { 2, "Sport" },
                    { 3, "Nauka" },
                    { 4, "Motoryzacja" },
                    { 5, "Gry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "441c4ab7-b51c-4b95-90f5-c1aa0006da32", "b01748ff-c1f0-437a-a0c5-4b3eaa521908" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Content", "PublicationDate", "TagId" },
                values: new object[,]
                {
                    { 1, "Janek", "W 2025 wybory na prezydenta!", new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5681), 1 },
                    { 2, "Grzegorz", "Real Madryt odpadł z ligi mistrzów.", new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5683), 2 },
                    { 3, "Ania", "Wiatr słoneczny zniekształcił atmosfere marsa!", new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5685), 3 },
                    { 4, "Kasia", "Toyota Supra vs Nissan Skyline R34?", new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5686), 4 },
                    { 5, "Alex", "Nie mogę się doczekać premiery GTA VI!", new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5688), 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "PostId", "PublicationDate" },
                values: new object[,]
                {
                    { 1, "Karolina", "Już nie mogę się doczekać!", 1, new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5608) },
                    { 2, "Milena", "Słabo im szło w tym sezonie.", 2, new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5640) },
                    { 3, "Andrzej", "Tak, doszło do trzykrotnego zwiększenia jej wielkości.", 3, new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5641) },
                    { 4, "Karol", "Oczywiście, że Toyota!", 4, new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5643) },
                    { 5, "Sam", "Najgorsze jest to, że na premierę na PC poczekamy pewnie do 2027.", 5, new DateTime(2023, 12, 29, 16, 57, 3, 807, DateTimeKind.Local).AddTicks(5644) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagId",
                table: "Posts",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

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
                values: new object[] { "10bf1a2b-8d41-43e9-98e4-2d81982b89fa", "10bf1a2b-8d41-43e9-98e4-2d81982b89fa", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eac79764-4f8e-4e47-86f4-287e661bd023", 0, "c3ff1d38-7dba-4cf8-af54-f14624da3bd3", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAECO6PuAyotXwGe22IP3+1MPtCP0+260FB4Uhn3CDI9RrLGnZ8Vw5aP/22kbUkcCJiw==", null, false, "73e5032e-1733-4f04-92aa-6d71d430a33d", false, "adam" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "10bf1a2b-8d41-43e9-98e4-2d81982b89fa", "eac79764-4f8e-4e47-86f4-287e661bd023" });
        }
    }
}
