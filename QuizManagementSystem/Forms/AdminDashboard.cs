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
    /// Admin Dashboard — manage Students, Questions, Exams, and view all Results.
    /// </summary>
    public partial class AdminDashboard : Form
    {
        private readonly StudentRepository  _studentRepo  = new StudentRepository();
        private readonly QuestionRepository _questionRepo = new QuestionRepository();
        private readonly ExamRepository     _examRepo     = new ExamRepository();
        private readonly ResultRepository   _resultRepo   = new ResultRepository();

        public AdminDashboard()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {AppSession.CurrentStudentName}  |  Role: Administrator";
            LoadAllTabs();
        }

        private void LoadAllTabs()
        {
            LoadStudents();
            LoadQuestions();
            LoadExams();
            LoadResults();
        }

        // ── Students Tab ──────────────────────────────

        private void LoadStudents()
        {
            try
            {
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = _studentRepo.GetAll();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var form = new StudentEditForm();
            if (form.ShowDialog() == DialogResult.OK) LoadStudents();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            var s = dgvStudents.CurrentRow.DataBoundItem as Student;
            if (s == null) return;
            var form = new StudentEditForm(s);
            if (form.ShowDialog() == DialogResult.OK) LoadStudents();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            var s = dgvStudents.CurrentRow.DataBoundItem as Student;
            if (s == null) return;
            if (s.IsAdmin) { ShowError("Cannot delete the admin account."); return; }
            if (MessageBox.Show($"Delete student '{s.Name}'?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try { _studentRepo.Delete(s.StudentId); LoadStudents(); }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        // ── Questions Tab ─────────────────────────────

        private void LoadQuestions()
        {
            try
            {
                dgvQuestions.DataSource = null;
                dgvQuestions.DataSource = _questionRepo.GetAll();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnManageQuestions_Click(object sender, EventArgs e)
        {
            var form = new ManageQuestionsForm();
            form.ShowDialog();
            LoadQuestions();
        }

        // ── Exams Tab ─────────────────────────────────

        private void LoadExams()
        {
            try
            {
                dgvExams.DataSource = null;
                dgvExams.DataSource = _examRepo.GetAll();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            var form = new ExamEditForm();
            if (form.ShowDialog() == DialogResult.OK) LoadExams();
        }

        private void btnEditExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null) return;
            var exam = dgvExams.CurrentRow.DataBoundItem as Exam;
            if (exam == null) return;
            var form = new ExamEditForm(exam);
            if (form.ShowDialog() == DialogResult.OK) LoadExams();
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow == null) return;
            var exam = dgvExams.CurrentRow.DataBoundItem as Exam;
            if (exam == null) return;
            if (MessageBox.Show($"Delete exam '{exam.ExamName}'?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try { _examRepo.Delete(exam.ExamId); LoadExams(); }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        // ── Results Tab ───────────────────────────────

        private void LoadResults()
        {
            try
            {
                dgvResults.DataSource = null;
                dgvResults.DataSource = _resultRepo.GetAllResults();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow == null) return;
            var result = dgvResults.CurrentRow.DataBoundItem as Result;
            if (result == null) return;
            new ViewResultsForm(result.ResultId).ShowDialog();
        }

        // ── Refresh / Logout ──────────────────────────

        private void btnRefresh_Click(object sender, EventArgs e) => LoadAllTabs();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.Clear();
            this.Close();
        }

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // ── Inline helper dialogs ─────────────────────────────────────────────────

    /// <summary>Simple dialog to Add/Edit a Student.</summary>
    internal class StudentEditForm : Form
    {
        private readonly Student _student;
        private readonly StudentRepository _repo = new StudentRepository();

        private TextBox txtName, txtEmail, txtPassword, txtReg;
        private Button btnSave, btnCancel;

        public StudentEditForm(Student student = null)
        {
            _student = student ?? new Student();
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text          = _student.StudentId == 0 ? "Add Student" : "Edit Student";
            this.Size          = new Size(380, 310);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 15;
            AddLabel("Name:",               10, y); txtName     = AddTextBox(120, y, _student.Name);               y += 40;
            AddLabel("Email:",              10, y); txtEmail    = AddTextBox(120, y, _student.Email);              y += 40;
            AddLabel("Password:",           10, y); txtPassword = AddTextBox(120, y, _student.Password);           y += 40;
            AddLabel("Registration No.:",   10, y); txtReg      = AddTextBox(120, y, _student.RegistrationNumber); y += 50;

            btnSave   = new Button { Text = "Save",   Location = new Point(100, y), Size = new Size(80, 30), DialogResult = DialogResult.None };
            btnCancel = new Button { Text = "Cancel", Location = new Point(195, y), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };
            btnSave.Click += SaveClicked;
            this.Controls.AddRange(new Control[] { btnSave, btnCancel });
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void AddLabel(string text, int x, int y)
        {
            this.Controls.Add(new Label { Text = text, Location = new Point(x, y + 3), Size = new Size(110, 20) });
        }

        private TextBox AddTextBox(int x, int y, string value)
        {
            var tb = new TextBox { Location = new Point(x, y), Size = new Size(230, 23), Text = value ?? "" };
            this.Controls.Add(tb);
            return tb;
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtReg.Text))
            {
                MessageBox.Show("All fields are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _student.Name               = txtName.Text.Trim();
                _student.Email              = txtEmail.Text.Trim();
                _student.Password           = txtPassword.Text.Trim();
                _student.RegistrationNumber = txtReg.Text.Trim();

                bool ok = _student.StudentId == 0 ? _repo.Add(_student) : _repo.Update(_student);
                if (ok) this.DialogResult = DialogResult.OK;
                else MessageBox.Show("Save failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>Simple dialog to Add/Edit an Exam.</summary>
    internal class ExamEditForm : Form
    {
        private readonly Exam _exam;
        private readonly ExamRepository _repo = new ExamRepository();

        private TextBox txtName, txtSubject, txtMarks, txtDuration;
        private Button btnSave, btnCancel;

        public ExamEditForm(Exam exam = null)
        {
            _exam = exam ?? new Exam();
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text          = _exam.ExamId == 0 ? "Add Exam" : "Edit Exam";
            this.Size          = new Size(380, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 15;
            AddLabel("Exam Name:", 10, y); txtName     = AddTextBox(130, y, _exam.ExamName); y += 40;
            AddLabel("Subject:",   10, y); txtSubject  = AddTextBox(130, y, _exam.Subject);  y += 40;
            AddLabel("Total Marks:",10, y);txtMarks    = AddTextBox(130, y, _exam.TotalMarks.ToString()); y += 40;
            AddLabel("Duration (min):", 10, y); txtDuration = AddTextBox(130, y, _exam.DurationMinutes.ToString()); y += 50;

            btnSave   = new Button { Text = "Save",   Location = new Point(90,  y), Size = new Size(80, 30), DialogResult = DialogResult.None };
            btnCancel = new Button { Text = "Cancel", Location = new Point(185, y), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };
            btnSave.Click += SaveClicked;
            this.Controls.AddRange(new Control[] { btnSave, btnCancel });
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void AddLabel(string text, int x, int y) =>
            this.Controls.Add(new Label { Text = text, Location = new Point(x, y + 3), Size = new Size(120, 20) });

        private TextBox AddTextBox(int x, int y, string value)
        {
            var tb = new TextBox { Location = new Point(x, y), Size = new Size(220, 23), Text = value ?? "" };
            this.Controls.Add(tb);
            return tb;
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMarks.Text, out int marks) || !int.TryParse(txtDuration.Text, out int dur))
            {
                MessageBox.Show("Marks and Duration must be numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _exam.ExamName        = txtName.Text.Trim();
                _exam.Subject         = txtSubject.Text.Trim();
                _exam.TotalMarks      = marks;
                _exam.DurationMinutes = dur;
                bool ok = _exam.ExamId == 0 ? _repo.Add(_exam) : _repo.Update(_exam);
                if (ok) this.DialogResult = DialogResult.OK;
                else MessageBox.Show("Save failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
