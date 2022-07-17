using Expensive.Entities;

namespace Expensive.Services
{
    public interface IUserExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Expense?> GetExpenseAsync(int expenseId);
        void AddExpenseAsync(Expense expense);

        Task<IEnumerable<ExpenseType>> GetExpenseTypesAsync();
        Task<ExpenseType?> GetExpenseTypeAsync(int expenseTypeId);
        void AddExpenseTypeAsync(ExpenseType expenseType);

        Task<IEnumerable<ExpenseRecord>> GetExpenseRecordsAsync();
        Task<ExpenseRecord?> GetExpenseRecordAsync(int expenseRecordId);
        void AddExpenseRecordAsync(ExpenseRecord expenseRecord);

        Task<bool> SaveChangesAsync();
    }
}
