using System.ComponentModel.DataAnnotations;

namespace library_management_system.Models
{
    public class Penalty
    {
        [Key]
        public int PenaltyID { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public required string Reason { get; set; }
        [Required]
        public DateOnly Date { get; set; }

        public int StudentID { get; set; }

        public virtual Student? Student { get; set; }
    }
}
