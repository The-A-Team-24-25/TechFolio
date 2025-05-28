using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TechFolio.Server.Data; 
namespace TechFolio.Server.Controllers
{
    public class CreditUploadRequest : Controller
    {
        [Required]
        public CreditCategory Category { get; set; }

        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string EvidenceUrl { get; set; } 
    }
}
