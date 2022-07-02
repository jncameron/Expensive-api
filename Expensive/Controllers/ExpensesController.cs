using Expensive.Entities;
using Expensive.Models;
using Expensive.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IUserExpenseRepository _userExpenseRepository;

        public ExpensesController(IUserExpenseRepository userExpenseRepository)
        {
            _userExpenseRepository = userExpenseRepository ??
                throw new ArgumentNullException(nameof(userExpenseRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
        {
            var userExpenses = await _userExpenseRepository.GetExpensesAsync();

            var results = new List<ExpenseDto>();
            foreach (var expense in userExpenses)
            {
                results.Add(new ExpenseDto
                {
                    Id = expense.Id,
                    ExpenseName = expense.ExpenseName,
                    ExpenseDescription = expense.ExpenseDescription,
                    ExpenseType = expense.ExpenseTypeId
                });
                ;
            }
            return Ok(results);
        }

        [HttpGet("{expenseId}")]
        public async Task<IActionResult> GetExpense(int expenseId)
        {
            var expense = await _userExpenseRepository.GetExpenseAsync(expenseId);
            if (expense == null)
            {
                return NotFound();
            }

            var result = new ExpenseDto();
            result.Id = expense.Id;
            result.ExpenseName = expense.ExpenseName;
            result.ExpenseDescription = expense.ExpenseDescription;
            result.ExpenseType = expense.ExpenseTypeId;

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseDto expenseDto) 
        {
            var expenseToAdd = new Expense();
            expenseToAdd.Id = expenseDto.Id;
            expenseToAdd.ExpenseName = expenseDto.ExpenseName;
            expenseToAdd.ExpenseDescription = expenseDto.ExpenseDescription;
            expenseToAdd.ExpenseTypeId = expenseDto.ExpenseType;


            _userExpenseRepository.AddExpenseAsync(expenseToAdd);

            await _userExpenseRepository.SaveChangesAsync();

            return Ok(expenseToAdd);
        }
    }
}
