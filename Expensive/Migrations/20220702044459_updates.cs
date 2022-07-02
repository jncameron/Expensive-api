using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expensive.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseType_ExpenseTypeId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecord_Expense_ExpenseId",
                table: "ExpenseRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseType",
                table: "ExpenseType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseRecord",
                table: "ExpenseRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "ExpenseType",
                newName: "ExpenseTypes");

            migrationBuilder.RenameTable(
                name: "ExpenseRecord",
                newName: "ExpenseRecords");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseRecord_ExpenseId",
                table: "ExpenseRecords",
                newName: "IX_ExpenseRecords_ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ExpenseTypeId",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseRecords",
                table: "ExpenseRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecords_Expenses_ExpenseId",
                table: "ExpenseRecords",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecords_Expenses_ExpenseId",
                table: "ExpenseRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseRecords",
                table: "ExpenseRecords");

            migrationBuilder.RenameTable(
                name: "ExpenseTypes",
                newName: "ExpenseType");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "ExpenseRecords",
                newName: "ExpenseRecord");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expense",
                newName: "IX_Expense_ExpenseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseRecords_ExpenseId",
                table: "ExpenseRecord",
                newName: "IX_ExpenseRecord_ExpenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseType",
                table: "ExpenseType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseRecord",
                table: "ExpenseRecord",
                column: "Id");

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
    }
}
