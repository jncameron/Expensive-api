using Expensive.Entities;
using Expensive.Models;
using Expensive.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expensive.Controllers
{
    [Route("api/expenserecords")]
    [ApiController]
    public class ExpenseRecordsController : ControllerBase
    {
        private readonly IUserExpenseRepository _userExpenseRepository;

        public ExpenseRecordsController(IUserExpenseRepository userExpenseRepository)
        {
            _userExpenseRepository = userExpenseRepository ??
                throw new ArgumentNullException(nameof(userExpenseRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseRecordDto>>> GetExpenseRecords()
        {
            var userExpenseRecords = await _userExpenseRepository.GetExpenseRecordsAsync();

            var results = new List<ExpenseRecordDto>();
            foreach (var expense in userExpenseRecords)
            {
                results.Add(new ExpenseRecordDto
                {
                    Id = expense.Id,
                    Expense = expense.ExpenseId,
                    Comment = expense.Comment
                });
                ;
            }
            return Ok(results);
        }
        [HttpGet("{expenseRecordId}")]
        public async Task<IActionResult> GetExpenseRecord(int expenseRecordId)
        {
            var expenseRecord = await _userExpenseRepository.GetExpenseRecordAsync(expenseRecordId);
            if (expenseRecord == null)
            {
                return NotFound();
            }

            var result = new ExpenseRecordDto();
            result.Id = expenseRecord.Id;
            result.Expense = expenseRecord.ExpenseId;
            result.Comment = expenseRecord.Comment;

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenseRecord(ExpenseRecordDto expenseRecordDto)
        {
            var expenseRecordToAdd = new ExpenseRecord();
            expenseRecordToAdd.Id = expenseRecordDto.Id;
            expenseRecordToAdd.ExpenseId = expenseRecordDto.Expense;
            expenseRecordToAdd.Comment = expenseRecordDto.Comment;

            _userExpenseRepository.AddExpenseRecordAsync(expenseRecordToAdd);

            await _userExpenseRepository.SaveChangesAsync();

            return Ok(expenseRecordToAdd);
        }
    }
}
