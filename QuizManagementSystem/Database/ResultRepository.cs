using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Database
{
    /// <summary>Operations for Results and StudentAnswers tables.</summary>
    public class ResultRepository
    {
        /// <summary>Inserts a Result row and returns the generated result_id.</summary>
        public int SaveResult(Result r)
        {
            object scalar = DatabaseConnection.ExecuteScalar(
                @"INSERT INTO Results (student_id, exam_id, obtained_marks, total_marks, percentage, attempt_date)
                  VALUES (@Si, @Ei, @Om, @Tm, @Pct, @Date);
                  SELECT SCOPE_IDENTITY();",
                new[]
                {
                    new SqlParameter("@Si",   r.StudentId),
                    new SqlParameter("@Ei",   r.ExamId),
                    new SqlParameter("@Om",   r.ObtainedMarks),
                    new SqlParameter("@Tm",   r.TotalMarks),
                    new SqlParameter("@Pct",  r.Percentage),
                    new SqlParameter("@Date", DateTime.Now)
                });
            return Convert.ToInt32(scalar);
        }

        /// <summary>Bulk-inserts student answers for a completed attempt.</summary>
        public void SaveStudentAnswers(List<StudentAnswer> answers)
        {
            const string sql =
                @"INSERT INTO StudentAnswers (result_id, question_id, student_answer, is_correct)
                  VALUES (@Ri, @Qi, @Ans, @Ic)";

            foreach (var a in answers)
                DatabaseConnection.ExecuteNonQuery(sql, new[]
                {
                    new SqlParameter("@Ri",  a.ResultId),
                    new SqlParameter("@Qi",  a.QuestionId),
                    new SqlParameter("@Ans", a.StudentAnswerChar.ToString()),
                    new SqlParameter("@Ic",  a.IsCorrect)
                });
        }

        /// <summary>Returns all results for a specific student (newest first).</summary>
        public List<Result> GetResultsByStudent(int studentId)
        {
            var dt = DatabaseConnection.ExecuteQuery(
                @"SELECT r.result_id, r.student_id, r.exam_id, r.obtained_marks, r.total_marks,
                         r.percentage, r.attempt_date, s.name AS student_name, e.exam_name
                  FROM Results r
                  JOIN Students s ON r.student_id = s.student_id
                  JOIN Exams   e ON r.exam_id    = e.exam_id
                  WHERE r.student_id = @Id
                  ORDER BY r.attempt_date DESC",
                new[] { new SqlParameter("@Id", studentId) });
            return MapResults(dt);
        }

        /// <summary>Returns all results for the admin view.</summary>
        public List<Result> GetAllResults()
        {
            var dt = DatabaseConnection.ExecuteQuery(
                @"SELECT r.result_id, r.student_id, r.exam_id, r.obtained_marks, r.total_marks,
                         r.percentage, r.attempt_date, s.name AS student_name, e.exam_name
                  FROM Results r
                  JOIN Students s ON r.student_id = s.student_id
                  JOIN Exams   e ON r.exam_id    = e.exam_id
                  ORDER BY r.attempt_date DESC");
            return MapResults(dt);
        }

        /// <summary>Returns per-question answer detail for a specific result.</summary>
        public List<StudentAnswer> GetDetailedResult(int resultId)
        {
            var answers = new List<StudentAnswer>();
            var dt = DatabaseConnection.ExecuteQuery(
                @"SELECT sa.answer_id, sa.result_id, sa.question_id, sa.student_answer,
                         sa.is_correct, q.question_text, q.correct_answer
                  FROM StudentAnswers sa
                  JOIN Questions q ON sa.question_id = q.question_id
                  WHERE sa.result_id = @Id",
                new[] { new SqlParameter("@Id", resultId) });

            foreach (DataRow row in dt.Rows)
                answers.Add(new StudentAnswer
                {
                    AnswerId          = Convert.ToInt32(row["answer_id"]),
                    ResultId          = Convert.ToInt32(row["result_id"]),
                    QuestionId        = Convert.ToInt32(row["question_id"]),
                    StudentAnswerChar = row["student_answer"].ToString()[0],
                    IsCorrect         = Convert.ToBoolean(row["is_correct"]),
                    QuestionText      = row["question_text"].ToString(),
                    CorrectAnswer     = row["correct_answer"].ToString()[0]
                });
            return answers;
        }

        private List<Result> MapResults(DataTable dt)
        {
            var list = new List<Result>();
            foreach (DataRow row in dt.Rows)
                list.Add(new Result
                {
                    ResultId      = Convert.ToInt32(row["result_id"]),
                    StudentId     = Convert.ToInt32(row["student_id"]),
                    ExamId        = Convert.ToInt32(row["exam_id"]),
                    ObtainedMarks = Convert.ToInt32(row["obtained_marks"]),
                    TotalMarks    = Convert.ToInt32(row["total_marks"]),
                    Percentage    = Convert.ToDouble(row["percentage"]),
                    AttemptDate   = Convert.ToDateTime(row["attempt_date"]),
                    StudentName   = row["student_name"].ToString(),
                    ExamName      = row["exam_name"].ToString()
                });
            return list;
        }
    }
}
