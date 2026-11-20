namespace QuizManagementSystem.Models
{
    /// <summary>Question entity mirroring the Questions table.</summary>
    public class Question
    {
        public int    QuestionId   { get; set; }
        public string QuestionText { get; set; }
        public string OptionA      { get; set; }
        public string OptionB      { get; set; }
        public string OptionC      { get; set; }
        public string OptionD      { get; set; }
        public char   CorrectAnswer{ get; set; }
        public string Subject      { get; set; }
        public int    Marks        { get; set; }
    }
}
