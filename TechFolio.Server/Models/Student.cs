namespace TechFolio.Server.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }

        public int StudentTypeId { get; set; }
        public StudentType StudentType { get; set; }

        public List<Sanction> Sanctions { get; set; } = new List<Sanction>();
    }

}
