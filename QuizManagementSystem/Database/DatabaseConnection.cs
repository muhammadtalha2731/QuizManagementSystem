using System.Data;
using System.Data.SqlClient;

namespace QuizManagementSystem.Database
{
    /// <summary>
    /// Central ADO.NET database connection and helper class.
    /// All queries use parameterised commands to prevent SQL injection.
    /// </summary>
    public static class DatabaseConnection
    {
        private const string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuizManagementDB;Integrated Security=True;TrustServerCertificate=True";

        /// <summary>Opens and returns a new SqlConnection.</summary>
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>Executes INSERT / UPDATE / DELETE. Returns rows affected.</summary>
        public static int ExecuteNonQuery(string sql, SqlParameter[] prms = null)
        {
            using (var conn = GetConnection())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Executes a scalar query (e.g. SCOPE_IDENTITY). Returns first column of first row.</summary>
        public static object ExecuteScalar(string sql, SqlParameter[] prms = null)
        {
            using (var conn = GetConnection())
            using (var cmd  = new SqlCommand(sql, conn))
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Executes a SELECT and fills a DataTable.</summary>
        public static DataTable ExecuteQuery(string sql, SqlParameter[] prms = null)
        {
            using (var conn    = GetConnection())
            using (var cmd     = new SqlCommand(sql, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                if (prms != null) cmd.Parameters.AddRange(prms);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>Tests connectivity — returns true if the connection can be opened.</summary>
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                    return conn.State == ConnectionState.Open;
            }
            catch { return false; }
        }
    }
}
