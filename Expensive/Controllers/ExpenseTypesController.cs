using Expensive.Entities;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseTypeDto>>> GetExpenseTypes()
        {
            var userExpenseTypes = await _userExpenseRepository.GetExpenseTypesAsync();

            var results = new List<ExpenseTypeDto>();
            foreach (var expenseType in userExpenseTypes)
            {
                results.Add(new ExpenseTypeDto
                {
                    Id = expenseType.Id,
                    ExpenseTypeName = expenseType.ExpenseTypeName,
                    ExpenseTypeDescription = expenseType.ExpenseTypeDescription
                });
            }
            return Ok(results);
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

        [HttpPost]
        public async Task<IActionResult> AddExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            var expenseTypeToAdd = new ExpenseType();
            expenseTypeToAdd.Id = expenseTypeDto.Id;
            expenseTypeToAdd.ExpenseTypeName = expenseTypeDto.ExpenseTypeName;
            expenseTypeToAdd.ExpenseTypeDescription = expenseTypeDto.ExpenseTypeDescription;
 
            _userExpenseRepository.AddExpenseTypeAsync(expenseTypeToAdd);

            await _userExpenseRepository.SaveChangesAsync();

            return Ok(expenseTypeToAdd);
        }
    }
}
