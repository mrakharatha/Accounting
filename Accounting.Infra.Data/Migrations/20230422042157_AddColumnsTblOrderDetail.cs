using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infra.Data.Migrations
{
    public partial class AddColumnsTblOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupMenuId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GroupMenuId",
                table: "OrderDetails",
                column: "GroupMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_GroupMenus_GroupMenuId",
                table: "OrderDetails",
                column: "GroupMenuId",
                principalTable: "GroupMenus",
                principalColumn: "GroupMenuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_GroupMenus_GroupMenuId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_GroupMenuId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "GroupMenuId",
                table: "OrderDetails");
        }
    }
}
