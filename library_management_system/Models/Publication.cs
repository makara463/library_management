using System.ComponentModel.DataAnnotations;

namespace library_management_system.Models
{
    public class Publication
    {
        [Key]
        public int PublicationID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(50)]
        public required string Author { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public required string ISBN { get; set; }

        public required ICollection<Book> books { get; set; }
    }
}
