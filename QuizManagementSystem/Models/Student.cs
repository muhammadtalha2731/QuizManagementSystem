namespace QuizManagementSystem.Models
{
    /// <summary>Student entity mirroring the Students table.</summary>
    public class Student
    {
        public int    StudentId          { get; set; }
        public string Name               { get; set; }
        public string Email              { get; set; }
        public string Password           { get; set; }
        public string RegistrationNumber { get; set; }
        public bool   IsAdmin            { get; set; }
    }
}
