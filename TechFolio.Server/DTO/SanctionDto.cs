using System.ComponentModel.DataAnnotations;
using TechFolio.Server.Models;

namespace TechFolio.Server.DTO
{
    public class SanctionDto
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [EnumDataType(typeof(SanctionType))]
        public SanctionType Type { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(250)]
        public string Comment { get; set; }
    }

}
