using Microsoft.AspNetCore.Mvc;
using TechFolio.Server.Data; 
namespace TechFolio.Server.Controllers
{
    public class CreditDto : Controller
    {
       
        public CreditCategory Category { get; set; }
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsUsed { get; set; } 
    }
}
