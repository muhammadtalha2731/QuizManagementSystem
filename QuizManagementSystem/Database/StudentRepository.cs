using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Database
{
    /// <summary>CRUD operations for the Students table.</summary>
    public class StudentRepository
    {
        private const string SelectCols =
            "student_id, name, email, password, registration_number, is_admin";

        public List<Student> GetAll()
        {
            var list = new List<Student>();
            var dt   = DatabaseConnection.ExecuteQuery($"SELECT {SelectCols} FROM Students");
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public Student GetById(int id)
        {
            var dt = DatabaseConnection.ExecuteQuery(
                $"SELECT {SelectCols} FROM Students WHERE student_id = @Id",
                new[] { new SqlParameter("@Id", id) });
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        /// <summary>Authenticates by email + password. Returns null on failure.</summary>
        public Student Authenticate(string email, string password)
        {
            var dt = DatabaseConnection.ExecuteQuery(
                $"SELECT {SelectCols} FROM Students WHERE email = @E AND password = @P",
                new[]
                {
                    new SqlParameter("@E", email),
                    new SqlParameter("@P", password)
                });
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public bool Add(Student s)
        {
            return DatabaseConnection.ExecuteNonQuery(
                @"INSERT INTO Students (name, email, password, registration_number, is_admin)
                  VALUES (@N, @E, @P, @R, @A)",
                new[]
                {
                    new SqlParameter("@N", s.Name),
                    new SqlParameter("@E", s.Email),
                    new SqlParameter("@P", s.Password),
                    new SqlParameter("@R", s.RegistrationNumber),
                    new SqlParameter("@A", s.IsAdmin ? 1 : 0)
                }) > 0;
        }

        public bool Update(Student s)
        {
            return DatabaseConnection.ExecuteNonQuery(
                @"UPDATE Students SET name = @N, email = @E, password = @P,
                  registration_number = @R WHERE student_id = @Id",
                new[]
                {
                    new SqlParameter("@N",  s.Name),
                    new SqlParameter("@E",  s.Email),
                    new SqlParameter("@P",  s.Password),
                    new SqlParameter("@R",  s.RegistrationNumber),
                    new SqlParameter("@Id", s.StudentId)
                }) > 0;
        }

        public bool Delete(int id)
        {
            return DatabaseConnection.ExecuteNonQuery(
                "DELETE FROM Students WHERE student_id = @Id",
                new[] { new SqlParameter("@Id", id) }) > 0;
        }

        private Student Map(DataRow r) => new Student
        {
            StudentId          = Convert.ToInt32(r["student_id"]),
            Name               = r["name"].ToString(),
            Email              = r["email"].ToString(),
            Password           = r["password"].ToString(),
            RegistrationNumber = r["registration_number"].ToString(),
            IsAdmin            = Convert.ToBoolean(r["is_admin"])
        };
    }
}
