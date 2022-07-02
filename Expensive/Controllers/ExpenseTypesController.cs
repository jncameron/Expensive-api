using Expensive.Models;
using Expensive.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Controllers
{
    [ApiController]
    [Route("api/expensetypes")]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly IUserExpenseRepository _userExpenseRepository;
        public ExpenseTypesController(IUserExpenseRepository userExpenseRepository)
        {
            _userExpenseRepository = userExpenseRepository ??
                throw new ArgumentNullException(nameof(userExpenseRepository));
        }
        [HttpGet("{expenseTypeId}")]
        public async Task<IActionResult> GetExpense(int expenseTypeId)
        {
            var expenseType = await _userExpenseRepository.GetExpenseTypeAsync(expenseTypeId);
            if (expenseType == null)
            {
                return NotFound();
            }

            var result = new ExpenseTypeDto();
            result.Id = expenseType.Id;
            result.ExpenseTypeName = expenseType.ExpenseTypeName;
            result.ExpenseTypeDescription = expenseType.ExpenseTypeDescription;

            return Ok(result);
        }
    }
}
