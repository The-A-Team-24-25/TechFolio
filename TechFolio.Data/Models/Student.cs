using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFolio.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; } // Store URL or base64
        public string Grade { get; set; }
        public string Specialty { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

    }
}
