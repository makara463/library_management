using System.ComponentModel.DataAnnotations;

namespace library_management_system.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }

        [Required]
        public required string BranchName { get; set; }

        [Required]
        public required string Location { get; set; }
        public ICollection<Student> students { get; set; }
        public virtual required ICollection<Book> books { get; set; }
    }
}
