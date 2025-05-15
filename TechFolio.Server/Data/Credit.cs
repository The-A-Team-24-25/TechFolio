namespace TechFolio.Server.Data
{
    public class Credit
    {
        public int Id { get; set; }
        public string StudentId { get; set; } // Foreign key към Student
        public CreditCategory Category { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsUsed { get; set; }
    }
}