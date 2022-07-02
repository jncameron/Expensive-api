using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expensive.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseType_ExpenseTypeId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecord_Expense_ExpenseId",
                table: "ExpenseRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecord_ExpenseType_ExpenseTypeId",
                table: "ExpenseRecord");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseRecord_ExpenseTypeId",
                table: "ExpenseRecord");

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "ExpenseRecord");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "ExpenseRecord",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expense",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ExpenseType",
                columns: new[] { "Id", "ExpenseTypeDescription", "ExpenseTypeName" },
                values: new object[] { 1, "Ongoing household expenses", "Utilities" });

            migrationBuilder.InsertData(
                table: "Expense",
                columns: new[] { "Id", "ExpenseDescription", "ExpenseName", "ExpenseTypeId" },
                values: new object[] { 1, "Origin Energy Monthly Electricity Bill", "Electricity", 1 });

            migrationBuilder.InsertData(
                table: "ExpenseRecord",
                columns: new[] { "Id", "Comment", "ExpenseId" },
                values: new object[] { 1, "Origin Energy Monthly Electricity Bill", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseType_ExpenseTypeId",
                table: "Expense",
                column: "ExpenseTypeId",
                principalTable: "ExpenseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecord_Expense_ExpenseId",
                table: "ExpenseRecord",
                column: "ExpenseId",
                principalTable: "Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseType_ExpenseTypeId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecord_Expense_ExpenseId",
                table: "ExpenseRecord");

            migrationBuilder.DeleteData(
                table: "ExpenseRecord",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "ExpenseRecord",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseTypeId",
                table: "ExpenseRecord",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expense",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRecord_ExpenseTypeId",
                table: "ExpenseRecord",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseType_ExpenseTypeId",
                table: "Expense",
                column: "ExpenseTypeId",
                principalTable: "ExpenseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecord_Expense_ExpenseId",
                table: "ExpenseRecord",
                column: "ExpenseId",
                principalTable: "Expense",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecord_ExpenseType_ExpenseTypeId",
                table: "ExpenseRecord",
                column: "ExpenseTypeId",
                principalTable: "ExpenseType",
                principalColumn: "Id");
        }
    }
}
