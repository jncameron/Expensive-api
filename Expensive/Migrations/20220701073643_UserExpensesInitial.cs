using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expensive.Migrations
{
    public partial class UserExpensesInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpenseTypeName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ExpenseTypeDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpenseName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ExpenseDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_ExpenseType_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpenseRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ExpenseId = table.Column<int>(type: "INTEGER", nullable: true),
                    ExpenseTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseRecord_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseRecord_ExpenseType_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseTypeId",
                table: "Expense",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRecord_ExpenseId",
                table: "ExpenseRecord",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRecord_ExpenseTypeId",
                table: "ExpenseRecord",
                column: "ExpenseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseRecord");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "ExpenseType");
        }
    }
}
