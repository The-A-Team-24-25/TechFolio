namespace TechFolio.Server.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;  // Added property for grouping by class

        public ICollection<Sanction> Sanctions { get; set; } = new List<Sanction>();
    }

}
