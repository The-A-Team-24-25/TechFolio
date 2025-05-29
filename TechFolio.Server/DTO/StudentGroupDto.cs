namespace TechFolio.Server.DTO
{
    public class StudentGroupDto
    {
        public string ClassName { get; set; } = string.Empty;
        public List<StudentDto> Students { get; set; } = new(); 
    }
}
