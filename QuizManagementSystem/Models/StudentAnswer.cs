namespace QuizManagementSystem.Models
{
    /// <summary>StudentAnswer entity mirroring the StudentAnswers table.</summary>
    public class StudentAnswer
    {
        public int  AnswerId          { get; set; }
        public int  ResultId          { get; set; }
        public int  QuestionId        { get; set; }
        public char StudentAnswerChar { get; set; }
        public bool IsCorrect         { get; set; }

        // For display (joined fields)
        public string QuestionText  { get; set; }
        public char   CorrectAnswer { get; set; }
    }
}
