using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPProd.Migrations
{
    public partial class InitReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0db6f82d-dc37-4534-a432-8257392581ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "803e09e6-e0ea-4a18-ba0b-867ebe264fb8", "9ead46e9-85d8-488e-9f66-7030cc3ba07d", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "803e09e6-e0ea-4a18-ba0b-867ebe264fb8");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0db6f82d-dc37-4534-a432-8257392581ad", "155bbdef-a051-4684-868f-01088ca097c9", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "980a931c-9c4f-4f27-8faa-5f395904ca25", "admin@mail.ru", false, false, null, null, null, "123", null, null, false, "a9657382-09b5-4acb-92fc-949c129260a0", false, "test@yandex.ru" });
        }
    }
}
