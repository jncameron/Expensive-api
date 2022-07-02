using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expensive.Entities
{
    public class ExpenseRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Comment { get; set; }

        [ForeignKey("ExpenseId")]
        public Expense? Expense { get; set; }
        public int ExpenseId { get; set; }

        //[ForeignKey("ExpenseTypeId")]
        //public ExpenseType? ExpenseType { get; set; }
        //public int ExpenseTypeId { get; set; }

    }
}
