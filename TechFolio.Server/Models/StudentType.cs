namespace TechFolio.Server.Models
{
    public class StudentType
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
