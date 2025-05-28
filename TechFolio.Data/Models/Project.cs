using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechFolio.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Technologies { get; set; }

        public string FileUrl { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students Student { get; set; }
    }
}
