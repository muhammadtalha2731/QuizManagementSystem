using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizManagementSystem.Database;
using QuizManagementSystem.DataStructures;
using QuizManagementSystem.Models;

namespace QuizManagementSystem.Forms
{
    /// <summary>
    /// Manage Questions Form — uses the custom Doubly LinkedList for in-memory CRUD
    /// and synchronises changes back to SQL Server via QuestionRepository.
    /// </summary>
    public partial class ManageQuestionsForm : Form
    {
        private readonly QuestionRepository  _repo = new QuestionRepository();
        private readonly QuestionLinkedList  _list = new QuestionLinkedList();

        public ManageQuestionsForm()
        {
            InitializeComponent();
            LoadIntoLinkedList();
            DisplayCurrent();
        }

        // ── Data Loading ──────────────────────────────

        private void LoadIntoLinkedList()
        {
            try
            {
                List<Question> questions = _repo.GetAll();
                _list.LoadFromList(questions);
                UpdateNavLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading questions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Display ───────────────────────────────────

        private void DisplayCurrent()
        {
            QuestionNode node = _list.CurrentNode;
            if (node == null)
            {
                ClearFields();
                UpdateNavLabel();
                return;
            }

            txtQuestionId.Text   = node.QuestionId.ToString();
            txtQuestionText.Text = node.QuestionText;
            txtOptionA.Text      = node.OptionA;
            txtOptionB.Text      = node.OptionB;
            txtOptionC.Text      = node.OptionC;
            txtOptionD.Text      = node.OptionD;
            cmbCorrect.Text      = node.CorrectAnswer.ToString();
            txtSubject.Text      = node.Subject;
            txtMarks.Text        = node.Marks.ToString();
            UpdateNavLabel();
        }

        private void ClearFields()
        {
            txtQuestionId.Text = txtQuestionText.Text = txtOptionA.Text =
            txtOptionB.Text    = txtOptionC.Text      = txtOptionD.Text =
            txtSubject.Text    = txtMarks.Text        = string.Empty;
            cmbCorrect.SelectedIndex = -1;
        }

        private void UpdateNavLabel()
        {
            int index = _list.GetCurrentIndex();
            lblNav.Text = _list.Count == 0
                ? "No questions loaded"
                : $"Question  {index}  of  {_list.Count}";

            btnPrev.Enabled = _list.HasPrevious;
            btnNext.Enabled = _list.HasNext;
        }

        // ── Navigation ────────────────────────────────

        private void btnNext_Click(object sender, EventArgs e)
        {
            _list.GetNext();
            DisplayCurrent();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _list.GetPrevious();
            DisplayCurrent();
        }

        // ── CRUD ──────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out Question q)) return;
            q.QuestionId = 0; // Let DB assign identity

            try
            {
                bool ok = _repo.Add(q);
                if (ok)
                {
                    MessageBox.Show("Question added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIntoLinkedList(); // Reload to get new DB ID
                    // Navigate to the tail (newly added)
                    while (_list.HasNext) _list.GetNext();
                    DisplayCurrent();
                }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuestionId.Text, out int id) || id == 0)
            {
                ShowError("Select a question to update (navigate to it first).");
                return;
            }
            if (!ValidateFields(out Question q)) return;
            q.QuestionId = id;

            try
            {
                // Update both in-memory list and database
                _list.UpdateQuestion(new QuestionNode(
                    q.QuestionId, q.QuestionText,
                    q.OptionA, q.OptionB, q.OptionC, q.OptionD,
                    q.CorrectAnswer, q.Subject, q.Marks));

                bool ok = _repo.Update(q);
                if (ok)
                    MessageBox.Show("Question updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    ShowError("Update failed in database.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuestionId.Text, out int id) || id == 0)
            {
                ShowError("Navigate to a question first.");
                return;
            }

            if (MessageBox.Show("Delete this question?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _list.DeleteQuestion(id);   // Remove from linked list
                _repo.Delete(id);           // Remove from database
                MessageBox.Show("Question deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayCurrent();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtQuestionText.Focus();
        }

        // ── Validation ────────────────────────────────

        private bool ValidateFields(out Question q)
        {
            q = null;
            if (string.IsNullOrWhiteSpace(txtQuestionText.Text) ||
                string.IsNullOrWhiteSpace(txtOptionA.Text)      ||
                string.IsNullOrWhiteSpace(txtOptionB.Text)      ||
                string.IsNullOrWhiteSpace(txtOptionC.Text)      ||
                string.IsNullOrWhiteSpace(txtOptionD.Text)      ||
                string.IsNullOrWhiteSpace(txtSubject.Text)      ||
                cmbCorrect.SelectedIndex < 0)
            {
                ShowError("All fields (including Correct Answer) are required.");
                return false;
            }

            if (!int.TryParse(txtMarks.Text, out int marks) || marks <= 0)
            {
                ShowError("Marks must be a positive number.");
                return false;
            }

            q = new Question
            {
                QuestionText  = txtQuestionText.Text.Trim(),
                OptionA       = txtOptionA.Text.Trim(),
                OptionB       = txtOptionB.Text.Trim(),
                OptionC       = txtOptionC.Text.Trim(),
                OptionD       = txtOptionD.Text.Trim(),
                CorrectAnswer = cmbCorrect.Text[0],
                Subject       = txtSubject.Text.Trim(),
                Marks         = marks
            };
            return true;
        }

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
