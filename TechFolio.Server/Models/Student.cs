namespace TechFolio.Server.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; } // или друго поле за клас
        public string ProfilePictureUrl { get; set; } // профилна снимка, ако е необходимо

        // Ако имаш допълнителни свойства за учениците, добави ги тук
        public List<Sanction> Sanctions { get; set; } = new List<Sanction>(); // връзка към санкциите
    }

}
