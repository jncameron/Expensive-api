using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expensive.Entities
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExpenseName { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? ExpenseDescription { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public ExpenseType? ExpenseType { get; set; }
        public int ExpenseTypeId { get; set; }
    }
}
