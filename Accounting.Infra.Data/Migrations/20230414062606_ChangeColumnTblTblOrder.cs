using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Infra.Data.Migrations
{
    public partial class ChangeColumnTblTblOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderPrice",
                table: "Orders",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
