using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizManagementSystem.Database;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Forms
{
    /// <summary>
    /// View Results Form — displays a detailed summary of one quiz attempt,
    /// including marks, percentage, pass/fail status, and per-question breakdown.
    /// </summary>
    public partial class ViewResultsForm : Form
    {
        private readonly int              _resultId;
        private readonly ResultRepository _repo = new ResultRepository();

        public ViewResultsForm(int resultId)
        {
            _resultId = resultId;
            InitializeComponent();
            LoadResult();
        }

        private void LoadResult()
        {
            try
            {
                // Load summary
                var allResults = _repo.GetAllResults();
                Result result  = allResults.Find(r => r.ResultId == _resultId);

                if (result == null)
                {
                    MessageBox.Show("Result not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Summary panel
                lblStudentName.Text = $"Student:       {result.StudentName}";
                lblExamName.Text    = $"Exam:          {result.ExamName}";
                lblMarks.Text       = $"Marks:         {result.ObtainedMarks} / {result.TotalMarks}";
                lblPercentage.Text  = $"Percentage:    {result.Percentage:F2}%";
                lblDate.Text        = $"Date:          {result.AttemptDate:dd-MMM-yyyy  HH:mm}";

                bool passed        = result.Percentage >= 50;
                lblStatus.Text     = passed ? "✔  PASS" : "✖  FAIL";
                lblStatus.ForeColor= passed ? Color.Green : Color.Red;
                lblStatus.Font     = new Font("Segoe UI", 16F, FontStyle.Bold);

                // Per-question breakdown
                List<StudentAnswer> answers = _repo.GetDetailedResult(_resultId);
                var display = new System.Collections.Generic.List<object>();

                int qNum = 1;
                foreach (var a in answers)
                {
                    display.Add(new
                    {
                        No            = qNum++,
                        Question      = a.QuestionText.Length > 60
                                        ? a.QuestionText.Substring(0, 60) + "…"
                                        : a.QuestionText,
                        YourAnswer    = a.StudentAnswerChar == ' ' ? "—" : a.StudentAnswerChar.ToString(),
                        CorrectAnswer = a.CorrectAnswer.ToString(),
                        Result        = a.IsCorrect ? "✔ Correct" : "✖ Wrong"
                    });
                }

                dgvAnswers.DataSource = display;
                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading result: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            if (dgvAnswers.Rows.Count == 0) return;
            dgvAnswers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in dgvAnswers.Rows)
            {
                var resultCell = row.Cells["Result"];
                if (resultCell?.Value?.ToString()?.StartsWith("✔") == true)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Simple text summary to clipboard
            string summary =
                $"=== Quiz Result ==={Environment.NewLine}" +
                $"{lblStudentName.Text}{Environment.NewLine}" +
                $"{lblExamName.Text}{Environment.NewLine}" +
                $"{lblMarks.Text}{Environment.NewLine}" +
                $"{lblPercentage.Text}{Environment.NewLine}" +
                $"{lblStatus.Text}{Environment.NewLine}" +
                $"{lblDate.Text}";
            Clipboard.SetText(summary);
            MessageBox.Show("Result summary copied to clipboard!", "Copied",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
