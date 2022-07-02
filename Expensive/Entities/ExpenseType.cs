using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expensive.Entities
{
    public class ExpenseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExpenseTypeName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string ExpenseTypeDescription{ get; set; } = string.Empty;

    }
}
