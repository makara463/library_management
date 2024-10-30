using System.ComponentModel.DataAnnotations;

namespace library_management_system.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]

        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }
        public int BranchID { get; set; }

        public virtual Branch? branches { get; set; }

        public ICollection<Issue> Issues { get; set; }

        public ICollection<Penalty> penalties { get; set; }
    }
}
