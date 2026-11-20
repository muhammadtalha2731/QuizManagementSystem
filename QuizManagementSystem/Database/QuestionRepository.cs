using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Database
{
    /// <summary>CRUD operations for the Questions table.</summary>
    public class QuestionRepository
    {
        private const string SelectCols =
            "question_id, question_text, option_a, option_b, option_c, option_d, correct_answer, subject, marks";

        public List<Question> GetAll()
        {
            var list = new List<Question>();
            var dt   = DatabaseConnection.ExecuteQuery($"SELECT {SelectCols} FROM Questions");
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public List<Question> GetBySubject(string subject)
        {
            var list = new List<Question>();
            var dt   = DatabaseConnection.ExecuteQuery(
                $"SELECT {SelectCols} FROM Questions WHERE subject = @S",
                new[] { new SqlParameter("@S", subject) });
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public Question GetById(int id)
        {
            var dt = DatabaseConnection.ExecuteQuery(
                $"SELECT {SelectCols} FROM Questions WHERE question_id = @Id",
                new[] { new SqlParameter("@Id", id) });
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public bool Add(Question q)
        {
            return DatabaseConnection.ExecuteNonQuery(
                @"INSERT INTO Questions
                  (question_text, option_a, option_b, option_c, option_d, correct_answer, subject, marks)
                  VALUES (@T, @A, @B, @C, @D, @Ans, @S, @M)",
                new[]
                {
                    new SqlParameter("@T",   q.QuestionText),
                    new SqlParameter("@A",   q.OptionA),
                    new SqlParameter("@B",   q.OptionB),
                    new SqlParameter("@C",   q.OptionC),
                    new SqlParameter("@D",   q.OptionD),
                    new SqlParameter("@Ans", q.CorrectAnswer.ToString()),
                    new SqlParameter("@S",   q.Subject),
                    new SqlParameter("@M",   q.Marks)
                }) > 0;
        }

        public bool Update(Question q)
        {
            return DatabaseConnection.ExecuteNonQuery(
                @"UPDATE Questions SET question_text = @T, option_a = @A, option_b = @B,
                  option_c = @C, option_d = @D, correct_answer = @Ans, subject = @S,
                  marks = @M WHERE question_id = @Id",
                new[]
                {
                    new SqlParameter("@T",   q.QuestionText),
                    new SqlParameter("@A",   q.OptionA),
                    new SqlParameter("@B",   q.OptionB),
                    new SqlParameter("@C",   q.OptionC),
                    new SqlParameter("@D",   q.OptionD),
                    new SqlParameter("@Ans", q.CorrectAnswer.ToString()),
                    new SqlParameter("@S",   q.Subject),
                    new SqlParameter("@M",   q.Marks),
                    new SqlParameter("@Id",  q.QuestionId)
                }) > 0;
        }

        public bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "DELETE FROM Questions WHERE question_id = @Id",
                new[] { new SqlParameter("@Id", id) }) > 0;
        }

        private Question Map(DataRow r) => new Question
        {
            QuestionId    = Convert.ToInt32(r["question_id"]),
            QuestionText  = r["question_text"].ToString(),
            OptionA       = r["option_a"].ToString(),
            OptionB       = r["option_b"].ToString(),
            OptionC       = r["option_c"].ToString(),
            OptionD       = r["option_d"].ToString(),
            CorrectAnswer = r["correct_answer"].ToString()[0],
            Subject       = r["subject"].ToString(),
            Marks         = Convert.ToInt32(r["marks"])
        };
    }
}
