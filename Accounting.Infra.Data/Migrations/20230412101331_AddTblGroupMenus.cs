using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infra.Data.Migrations
{
    public partial class AddTblGroupMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMenu_Users_UserId",
                table: "GroupMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMenu",
                table: "GroupMenu");

            migrationBuilder.RenameTable(
                name: "GroupMenu",
                newName: "GroupMenus");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMenu_UserId",
                table: "GroupMenus",
                newName: "IX_GroupMenus_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMenus",
                table: "GroupMenus",
                column: "GroupMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMenus_Users_UserId",
                table: "GroupMenus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMenus_Users_UserId",
                table: "GroupMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMenus",
                table: "GroupMenus");

            migrationBuilder.RenameTable(
                name: "GroupMenus",
                newName: "GroupMenu");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMenus_UserId",
                table: "GroupMenu",
                newName: "IX_GroupMenu_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMenu",
                table: "GroupMenu",
                column: "GroupMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMenu_Users_UserId",
                table: "GroupMenu",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
