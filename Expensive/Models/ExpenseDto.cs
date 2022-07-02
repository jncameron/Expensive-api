namespace Expensive.Models
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public string? ExpenseDescription { get; set; }
        public int ExpenseType { get; set; }

    }
}
