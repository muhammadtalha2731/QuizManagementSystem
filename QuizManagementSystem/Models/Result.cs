using System;

namespace QuizManagementSystem.Models
{
    /// <summary>Result entity mirroring the Results table.</summary>
    public class Result
    {
        public int      ResultId      { get; set; }
        public int      StudentId     { get; set; }
        public int      ExamId        { get; set; }
        public int      ObtainedMarks { get; set; }
        public int      TotalMarks    { get; set; }
        public double   Percentage    { get; set; }
        public DateTime AttemptDate   { get; set; }

        // For display (joined fields)
        public string StudentName { get; set; }
        public string ExamName   { get; set; }
    }
}
