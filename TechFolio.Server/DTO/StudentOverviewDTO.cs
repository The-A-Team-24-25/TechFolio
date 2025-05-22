namespace TechFolio.Server.DTO
{
    public class StudentOverviewDTO
    {
        
            public int StudentId { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public string ProfilePictureUrl { get; set; }
            public int TotalCredits { get; set; }
            public int TotalAchievements { get; set; }
            public int TotalSanctions { get; set; }
        

    }
}
