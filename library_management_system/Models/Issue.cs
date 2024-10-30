using System.ComponentModel.DataAnnotations;

namespace library_management_system.Models
{
    public class Issue
    {
        [Key]
        public int IssueID { get; set; }
        [Required]
        public DateOnly IssueDate { get; set; }
        [Required]
        public DateOnly ReturnDate { get; set; }
        [Required]
        public required string Status { get; set; }
        public int StudentID { get; set; }
        public int BookID { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Book? Book { get; set; }
    }
}
