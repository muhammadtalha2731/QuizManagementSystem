namespace QuizManagementSystem.Helpers
{
    /// <summary>
    /// Stores current logged-in user information for the session.
    /// </summary>
    public static class AppSession
    {
        public static int    CurrentStudentId   { get; set; }
        public static string CurrentStudentName { get; set; }
        public static string CurrentEmail       { get; set; }
        public static bool   IsAdmin            { get; set; }

        public static void Clear()
        {
            CurrentStudentId   = 0;
            CurrentStudentName = string.Empty;
            CurrentEmail       = string.Empty;
            IsAdmin            = false;
        }
    }
}
