using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Database
{
    /// <summary>CRUD operations for the Exams table.</summary>
    public class ExamRepository
    {
        private const string SelectCols =
            "exam_id, exam_name, subject, total_marks, duration_minutes";

        public List<Exam> GetAll()
        {
            var list = new List<Exam>();
            var dt   = DatabaseConnection.ExecuteQuery($"SELECT {SelectCols} FROM Exams");
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public Exam GetById(int id)
        {
            var dt = DatabaseConnection.ExecuteQuery(
                $"SELECT {SelectCols} FROM Exams WHERE exam_id = @Id",
                new[] { new SqlParameter("@Id", id) });
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public bool Add(Exam e)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "INSERT INTO Exams (exam_name, subject, total_marks, duration_minutes) VALUES (@N, @S, @T, @D)",
                new[]
                {
                    new SqlParameter("@N", e.ExamName),
                    new SqlParameter("@S", e.Subject),
                    new SqlParameter("@T", e.TotalMarks),
                    new SqlParameter("@D", e.DurationMinutes)
                }) > 0;
        }

        public bool Update(Exam e)
        {
            return DatabaseConnection.ExecuteNonQuery(
                @"UPDATE Exams SET exam_name = @N, subject = @S,
                  total_marks = @T, duration_minutes = @D WHERE exam_id = @Id",
                new[]
                {
                    new SqlParameter("@N",  e.ExamName),
                    new SqlParameter("@S",  e.Subject),
                    new SqlParameter("@T",  e.TotalMarks),
                    new SqlParameter("@D",  e.DurationMinutes),
                    new SqlParameter("@Id", e.ExamId)
                }) > 0;
        }

        public bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "DELETE FROM Exams WHERE exam_id = @Id",
                new[] { new SqlParameter("@Id", id) }) > 0;
        }

        private Exam Map(DataRow r) => new Exam
        {
            ExamId          = Convert.ToInt32(r["exam_id"]),
            ExamName        = r["exam_name"].ToString(),
            Subject         = r["subject"].ToString(),
            TotalMarks      = Convert.ToInt32(r["total_marks"]),
            DurationMinutes = Convert.ToInt32(r["duration_minutes"])
        };
    }
}
