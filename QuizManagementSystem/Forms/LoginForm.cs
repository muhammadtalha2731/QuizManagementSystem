using System;
using System.Drawing;
using System.Windows.Forms;
using QuizManagementSystem.Database;
using QuizManagementSystem.Helpers;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Forms
{
    /// <summary>
    /// Login form — authenticates both admins and students.
    /// Redirects to AdminDashboard or StudentDashboard based on role.
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly StudentRepository _repo = new StudentRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError("Please enter both email and password.");
                return;
            }

            try
            {
                Student student = _repo.Authenticate(email, password);

                if (student == null)
                {
                    ShowError("Invalid email or password. Please try again.");
                    txtPassword.Clear();
                    return;
                }

                // Store session
                AppSession.CurrentStudentId   = student.StudentId;
                AppSession.CurrentStudentName = student.Name;
                AppSession.CurrentEmail       = student.Email;
                AppSession.IsAdmin            = student.IsAdmin;

                this.Hide();

                if (student.IsAdmin)
                {
                    var dashboard = new AdminDashboard();
                    dashboard.FormClosed += (s, args) => { AppSession.Clear(); this.Show(); };
                    dashboard.Show();
                }
                else
                {
                    var dashboard = new StudentDashboard();
                    dashboard.FormClosed += (s, args) => { AppSession.Clear(); this.Show(); };
                    dashboard.Show();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Connection error: {ex.Message}");
            }
        }

        private void ShowError(string message)
        {
            lblError.Text      = message;
            lblError.ForeColor = Color.Red;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
}
