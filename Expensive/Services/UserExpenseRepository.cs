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

        public async Task<Expense?> GetExpenseAsync(int expenseId)
        {
            return await _context.Expenses.Where(x => x.Id == expenseId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _context.Expenses.OrderBy(e => e.ExpenseName).ToListAsync();
        }

        public async Task<ExpenseType?> GetExpenseTypeAsync(int expenseTypeId)
        {
            return await _context.ExpenseTypes.Where(x => x.Id == expenseTypeId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
