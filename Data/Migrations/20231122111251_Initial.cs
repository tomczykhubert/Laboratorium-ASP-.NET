using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "51a41179-85dd-48e3-a66f-bc873bdc0cf5", "118d8d78-67e6-484b-b510-589dd4d7af95" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51a41179-85dd-48e3-a66f-bc873bdc0cf5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "118d8d78-67e6-484b-b510-589dd4d7af95");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51a41179-85dd-48e3-a66f-bc873bdc0cf5", "51a41179-85dd-48e3-a66f-bc873bdc0cf5", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "118d8d78-67e6-484b-b510-589dd4d7af95", 0, "a7425200-b8d9-436e-95d9-f1c1ad7895a2", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAECP6uYsGtZiszMb0YHh0FBExML1EL+KtLzFBaQ/q1Xy5ua9dtVOcw/Nj/uac2Bis7A==", null, false, "03a3cfd8-d9d1-4ac7-b670-32fe6d54d6dc", false, "adam" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "51a41179-85dd-48e3-a66f-bc873bdc0cf5", "118d8d78-67e6-484b-b510-589dd4d7af95" });
        }
    }
}
