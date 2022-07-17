using Expensive.DbContexts;
using Expensive.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expensive.Services
{
    public class UserExpenseRepository : IUserExpenseRepository
    {
        private readonly UserExpensesContext _context;
        public UserExpenseRepository (UserExpensesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async void AddExpenseAsync(Expense expense)
        {
            var expenseType = await GetExpenseTypeAsync(expense.ExpenseTypeId);
            if (expenseType != null)
            {
                expense.ExpenseType = expenseType;
            }
            _context.Expenses.Add(expense);
        }

        public void AddExpenseTypeAsync(ExpenseType expenseType)
        {
            _context.ExpenseTypes.Add(expenseType);
        }

        public async Task<Expense?> GetExpenseAsync(int expenseId)
        {
            return await _context.Expenses.Where(x => x.Id == expenseId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _context.Expenses.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<ExpenseType?> GetExpenseTypeAsync(int expenseTypeId)
        {
            return await _context.ExpenseTypes.Where(x => x.Id == expenseTypeId).FirstOrDefaultAsync();
        }



        public async Task<IEnumerable<ExpenseType>> GetExpenseTypesAsync()
        {
            return await _context.ExpenseTypes.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<ExpenseRecord>> GetExpenseRecordsAsync()
        {
            return await _context.ExpenseRecords.OrderBy(e => e.Id).ToListAsync();

        }

        public async Task<ExpenseRecord?> GetExpenseRecordAsync(int expenseRecordId)
        {
            return await _context.ExpenseRecords.Where(x => x.Id == expenseRecordId).FirstOrDefaultAsync();
        }

        public void AddExpenseRecordAsync(ExpenseRecord expenseRecord)
        {
            _context.ExpenseRecords.Add(expenseRecord);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
