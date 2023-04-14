using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infra.Data.Migrations
{
    public partial class AddPermissionOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 30, null, "سفارش" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 31, 30, "افزودن سفارش" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 32, 30, "ویرایش سفارش " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 33, 30, "حذف سفارش" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 30);
        }
    }
}
