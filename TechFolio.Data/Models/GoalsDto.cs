using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFolio.Data.Models
{
    public class GoalsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GoalType Type { get; set; }
        public bool IsApproved { get; set; }
    }
}
