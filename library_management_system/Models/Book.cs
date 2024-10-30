using System.ComponentModel.DataAnnotations;

namespace library_management_system.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(100)]
        public required string Author { get; set; }

        [Required]
        public required string Status { get; set; }

        public int PublicationID { get; set; }

        public int BranchID { get; set; }

        public virtual Publication? Publication { get; set; }
        public virtual Branch? Branch { get; set; }

        public required ICollection<Issue> Issues { get; set; }
    }
}
