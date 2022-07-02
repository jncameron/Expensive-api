using Expensive.Entities;

namespace Expensive.Services
{
    public interface IUserExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense?> GetExpenseAsync(int expenseId);
        void AddExpenseAsync(Expense expense);

        Task<ExpenseType?> GetExpenseTypeAsync(int expenseTypeId);
        Task<bool> SaveChangesAsync();
    }
}
