namespace QuizManagementSystem.Models
{
    /// <summary>Exam entity mirroring the Exams table.</summary>
    public class Exam
    {
        public int    ExamId          { get; set; }
        public string ExamName        { get; set; }
        public string Subject         { get; set; }
        public int    TotalMarks      { get; set; }
        public int    DurationMinutes { get; set; }
    }
}
