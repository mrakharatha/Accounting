using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infra.Data.Migrations
{
    public partial class AddSeederUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 11,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 2, "ویرایش پروفایل" });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 12, null, "تعاریف" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 11,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { null, "تعاریف" });
        }
    }
}
