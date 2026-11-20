namespace QuizManagementSystem.DataStructures
{
    /// <summary>
    /// Represents a single node in the doubly linked list containing quiz question data.
    /// </summary>
    public class QuestionNode
    {
        // ── Question Data ─────────────────────────────
        public int    QuestionId    { get; set; }
        public string QuestionText  { get; set; }
        public string OptionA       { get; set; }
        public string OptionB       { get; set; }
        public string OptionC       { get; set; }
        public string OptionD       { get; set; }
        public char   CorrectAnswer { get; set; }
        public string Subject       { get; set; }
        public int    Marks         { get; set; }

        // ── Doubly Linked List Pointers ───────────────
        public QuestionNode Next     { get; set; }
        public QuestionNode Previous { get; set; }

        /// <summary>Default constructor.</summary>
        public QuestionNode()
        {
            Next     = null;
            Previous = null;
        }

        /// <summary>Parameterised constructor to create a fully-initialised node.</summary>
        public QuestionNode(int id, string text,
            string a, string b, string c, string d,
            char correct, string subject, int marks)
        {
            QuestionId    = id;
            QuestionText  = text;
            OptionA       = a;
            OptionB       = b;
            OptionC       = c;
            OptionD       = d;
            CorrectAnswer = correct;
            Subject       = subject;
            Marks         = marks;
            Next          = null;
            Previous      = null;
        }
    }
}
