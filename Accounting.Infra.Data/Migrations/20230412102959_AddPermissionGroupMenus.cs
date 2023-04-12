using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infra.Data.Migrations
{
    public partial class AddPermissionGroupMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 17,
                column: "Title",
                value: "منو");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 18,
                column: "Title",
                value: "گروه منو");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 19,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 18, "افزودن گروه منو" });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 20,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 18, "ویرایش گروه منو " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "Title" },
                values: new object[] { 21, 18, "حذف گروه منو" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 17,
                column: "Title",
                value: "گروه منو");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 18,
                column: "Title",
                value: "افزودن گروه منو");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 19,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 17, "ویرایش گروه منو " });

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 20,
                columns: new[] { "ParentId", "Title" },
                values: new object[] { 17, "حذف گروه منو" });
        }
    }
}
