
using Expensive.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expensive.DbContexts
{
    public class UserExpensesContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<ExpenseRecord> ExpenseRecords { get; set; } = null!;
        public DbSet<ExpenseType> ExpenseTypes { get; set; } = null!;

        public UserExpensesContext(DbContextOptions<UserExpensesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ExpenseType>().HasData(
                new ExpenseType()
                {
                    Id = 1,
                    ExpenseTypeName = "Utilities",
                    ExpenseTypeDescription = "Ongoing household expenses"
                });
            modelBuilder.Entity<Expense>().HasData(

                new Expense()
                {
                    Id = 1,
                    ExpenseName = "Electricity",
                    ExpenseDescription = "Origin Energy Monthly Electricity Bill",
                    ExpenseTypeId = 1
                });

            modelBuilder.Entity<ExpenseRecord>().HasData(new ExpenseRecord()
                {
                    Id = 1,
                    Comment = "Origin Energy Monthly Electricity Bill",
                    ExpenseId = 1
                });
        }

    }
}
