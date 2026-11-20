using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizManagementSystem.Database;
using QuizManagementSystem.Helpers;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Forms
{
    /// <summary>
    /// Student Dashboard — shows available exams, student's past results,
    /// and launches TakeQuizForm / ViewResultsForm.
    /// </summary>
    public partial class StudentDashboard : Form
    {
        private readonly ExamRepository   _examRepo   = new ExamRepository();
        private readonly ResultRepository _resultRepo = new ResultRepository();

        private List<Exam>   _exams   = new List<Exam>();
        private List<Result> _results = new List<Result>();

        public StudentDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {AppSession.CurrentStudentName}!";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Exams
                _exams = _examRepo.GetAll();
                lstExams.Items.Clear();
                foreach (var exam in _exams)
                    lstExams.Items.Add($"{exam.ExamName}  |  {exam.Subject}  |  {exam.TotalMarks} marks  |  {exam.DurationMinutes} min");

                // My Results
                _results = _resultRepo.GetResultsByStudent(AppSession.CurrentStudentId);
                dgvMyResults.DataSource = null;
                dgvMyResults.DataSource = _results;
                if (dgvMyResults.Columns.Count > 0)
                {
                    dgvMyResults.Columns["StudentName"].Visible = false;
                    dgvMyResults.Columns["StudentId"].Visible   = false;
                    dgvMyResults.Columns["ExamId"].Visible      = false;
                    dgvMyResults.Columns["ResultId"].Visible     = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTakeQuiz_Click(object sender, EventArgs e)
        {
            if (lstExams.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an exam from the list.", "No Exam Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Exam selectedExam = _exams[lstExams.SelectedIndex];
            var quizForm = new TakeQuizForm(selectedExam);
            quizForm.ShowDialog();
            LoadData(); // Refresh results after quiz
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvMyResults.CurrentRow == null) return;
            var result = dgvMyResults.CurrentRow.DataBoundItem as Result;
            if (result == null) return;
            new ViewResultsForm(result.ResultId).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Clear();
            this.Close();
        }
    }
}
