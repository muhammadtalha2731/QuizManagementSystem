using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizManagementSystem.Database;
using QuizManagementSystem.DataStructures;
using QuizManagementSystem.Helpers;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Forms
{
    /// <summary>
    /// Take Quiz Form — loads exam questions into a Doubly LinkedList,
    /// allows Prev/Next navigation, records answers, and submits for grading.
    /// </summary>
    public partial class TakeQuizForm : Form
    {
        private readonly Exam               _exam;
        private readonly QuestionLinkedList _list        = new QuestionLinkedList();
        private readonly Dictionary<int, char> _answers  = new Dictionary<int, char>();

        private readonly QuestionRepository _qRepo  = new QuestionRepository();
        private readonly ResultRepository   _rRepo  = new ResultRepository();

        private int _secondsLeft;
        private Timer _timer;

        public TakeQuizForm(Exam exam)
        {
            _exam = exam;
            InitializeComponent();
            LoadQuestions();
            SetupTimer();
        }

        // ── Initialisation ────────────────────────────

        private void LoadQuestions()
        {
            try
            {
                List<Question> questions = _qRepo.GetBySubject(_exam.Subject);
                if (questions.Count == 0)
                {
                    MessageBox.Show(
                        $"No questions found for subject '{_exam.Subject}'.\nPlease add questions first.",
                        "No Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                _list.LoadFromList(questions);
                lblExamTitle.Text = $"📝  {_exam.ExamName}  |  {_exam.Subject}";
                DisplayCurrentQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load questions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void SetupTimer()
        {
            _secondsLeft = _exam.DurationMinutes * 60;
            UpdateTimerLabel();
            _timer          = new Timer();
            _timer.Interval = 1000;
            _timer.Tick    += TimerTick;
            _timer.Start();
        }

        // ── Question Display ──────────────────────────

        private void DisplayCurrentQuestion()
        {
            QuestionNode node = _list.CurrentNode;
            if (node == null) return;

            // Update question text
            lblProgress.Text  = $"Question  {_list.GetCurrentIndex()}  of  {_list.Count}";
            lblQuestion.Text  = node.QuestionText;
            lblMarksInfo.Text = $"Marks: {node.Marks}";

            // Set options
            rbA.Text = $"A.  {node.OptionA}";
            rbB.Text = $"B.  {node.OptionB}";
            rbC.Text = $"C.  {node.OptionC}";
            rbD.Text = $"D.  {node.OptionD}";

            // Restore previously selected answer for this question
            ClearRadioButtons();
            if (_answers.TryGetValue(node.QuestionId, out char selected))
            {
                switch (selected)
                {
                    case 'A': rbA.Checked = true; break;
                    case 'B': rbB.Checked = true; break;
                    case 'C': rbC.Checked = true; break;
                    case 'D': rbD.Checked = true; break;
                }
            }

            // Navigation buttons
            btnPrev.Enabled = _list.HasPrevious;
            btnNext.Enabled = _list.HasNext;
        }

        private void ClearRadioButtons()
        {
            rbA.Checked = rbB.Checked = rbC.Checked = rbD.Checked = false;
        }

        // ── Answer Recording ──────────────────────────

        private void SaveCurrentAnswer()
        {
            QuestionNode node = _list.CurrentNode;
            if (node == null) return;

            char? answer = null;
            if (rbA.Checked) answer = 'A';
            else if (rbB.Checked) answer = 'B';
            else if (rbC.Checked) answer = 'C';
            else if (rbD.Checked) answer = 'D';

            if (answer.HasValue)
                _answers[node.QuestionId] = answer.Value;
            else
                _answers.Remove(node.QuestionId);
        }

        // ── Navigation ────────────────────────────────

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            _list.GetNext();
            DisplayCurrentQuestion();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            _list.GetPrevious();
            DisplayCurrentQuestion();
        }

        // ── Timer ─────────────────────────────────────

        private void TimerTick(object sender, EventArgs e)
        {
            _secondsLeft--;
            UpdateTimerLabel();

            if (_secondsLeft <= 0)
            {
                _timer.Stop();
                MessageBox.Show("Time's up! Your quiz will be submitted automatically.", "Time Up",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubmitQuiz();
            }
            else if (_secondsLeft == 60)
            {
                lblTimer.ForeColor = Color.Red;
            }
        }

        private void UpdateTimerLabel()
        {
            int m = _secondsLeft / 60;
            int s = _secondsLeft % 60;
            lblTimer.Text = $"⏱  {m:D2}:{s:D2}";
        }

        // ── Submission ────────────────────────────────

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();

            int answered  = _answers.Count;
            int total     = _list.Count;
            int remaining = total - answered;

            string msg = remaining > 0
                ? $"You have {remaining} unanswered question(s).\nSubmit anyway?"
                : $"Submit quiz? You answered all {total} questions.";

            if (MessageBox.Show(msg, "Confirm Submit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            SubmitQuiz();
        }

        private void SubmitQuiz()
        {
            _timer?.Stop();

            try
            {
                // Grade the quiz using the linked list
                int obtained  = 0;
                int totalMrks = 0;
                var allNodes  = _list.GetAllQuestions();
                var saList    = new List<StudentAnswer>();

                foreach (var node in allNodes)
                {
                    totalMrks += node.Marks;
                    bool answered = _answers.TryGetValue(node.QuestionId, out char ans);
                    bool correct  = answered && ans == node.CorrectAnswer;
                    if (correct) obtained += node.Marks;

                    saList.Add(new StudentAnswer
                    {
                        QuestionId        = node.QuestionId,
                        StudentAnswerChar = answered ? ans : ' ',
                        IsCorrect         = correct
                    });
                }

                double pct = totalMrks > 0 ? Math.Round((double)obtained / totalMrks * 100, 2) : 0;

                // Persist result
                var result = new Result
                {
                    StudentId     = AppSession.CurrentStudentId,
                    ExamId        = _exam.ExamId,
                    ObtainedMarks = obtained,
                    TotalMarks    = totalMrks,
                    Percentage    = pct
                };
                int resultId = _rRepo.SaveResult(result);

                // Persist per-question answers
                foreach (var sa in saList) sa.ResultId = resultId;
                _rRepo.SaveStudentAnswers(saList);

                // Show results immediately
                this.Hide();
                new ViewResultsForm(resultId).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving result: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timer?.Stop();
            base.OnFormClosing(e);
        }
    }
}
