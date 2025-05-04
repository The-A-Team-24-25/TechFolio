namespace TechFolio.Server.Models
{
    public class Sanction
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public SanctionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
