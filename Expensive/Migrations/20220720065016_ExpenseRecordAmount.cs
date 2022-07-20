using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expensive.Migrations
{
    public partial class ExpenseRecordAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ExpenseRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "ExpenseRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 10m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ExpenseRecords");
        }
    }
}
