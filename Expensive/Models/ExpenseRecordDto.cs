namespace Expensive.Models
{
    public class ExpenseRecordDto
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Expense { get; set; }
        public decimal Amount { get; set; }
    }
}
