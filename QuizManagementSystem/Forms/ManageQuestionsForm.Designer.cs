namespace QuizManagementSystem.Forms
{
    partial class ManageQuestionsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop         = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblNav         = new System.Windows.Forms.Label();
            this.btnPrev        = new System.Windows.Forms.Button();
            this.btnNext        = new System.Windows.Forms.Button();
            this.lblQId         = new System.Windows.Forms.Label();
            this.txtQuestionId  = new System.Windows.Forms.TextBox();
            this.lblQText       = new System.Windows.Forms.Label();
            this.txtQuestionText= new System.Windows.Forms.TextBox();
            this.lblA           = new System.Windows.Forms.Label();
            this.txtOptionA     = new System.Windows.Forms.TextBox();
            this.lblB           = new System.Windows.Forms.Label();
            this.txtOptionB     = new System.Windows.Forms.TextBox();
            this.lblC           = new System.Windows.Forms.Label();
            this.txtOptionC     = new System.Windows.Forms.TextBox();
            this.lblD           = new System.Windows.Forms.Label();
            this.txtOptionD     = new System.Windows.Forms.TextBox();
            this.lblCorrect     = new System.Windows.Forms.Label();
            this.cmbCorrect     = new System.Windows.Forms.ComboBox();
            this.lblSubject     = new System.Windows.Forms.Label();
            this.txtSubject     = new System.Windows.Forms.TextBox();
            this.lblMarks       = new System.Windows.Forms.Label();
            this.txtMarks       = new System.Windows.Forms.TextBox();
            this.pnlButtons     = new System.Windows.Forms.Panel();
            this.btnNew         = new System.Windows.Forms.Button();
            this.btnAdd         = new System.Windows.Forms.Button();
            this.btnUpdate      = new System.Windows.Forms.Button();
            this.btnDelete      = new System.Windows.Forms.Button();
            this.btnClose       = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblNav, this.btnPrev, this.btnNext });
            this.pnlTop.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 80;

            this.lblTitle.Text      = "📋 Manage Questions  (Doubly Linked List Editor)";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(10, 8);
            this.lblTitle.Size      = new System.Drawing.Size(580, 28);

            this.lblNav.Text      = "Question ? of ?";
            this.lblNav.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNav.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblNav.Location  = new System.Drawing.Point(10, 45);
            this.lblNav.Size      = new System.Drawing.Size(250, 23);

            this.btnPrev.Text      = "◀ Previous";
            this.btnPrev.Location  = new System.Drawing.Point(560, 20);
            this.btnPrev.Size      = new System.Drawing.Size(100, 32);
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Click    += new System.EventHandler(this.btnPrev_Click);

            this.btnNext.Text      = "Next ▶";
            this.btnNext.Location  = new System.Drawing.Point(670, 20);
            this.btnNext.Size      = new System.Drawing.Size(100, 32);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Click    += new System.EventHandler(this.btnNext_Click);

            // Fields — two-column layout
            int col1 = 20,  col2 = 410;
            int lblW = 110, txtW = 260;

            // Question ID (read-only)
            this.lblQId.Text     = "Question ID:";
            this.lblQId.Location = new System.Drawing.Point(col1, 100);
            this.lblQId.Size     = new System.Drawing.Size(lblW, 20);

            this.txtQuestionId.Location  = new System.Drawing.Point(col1 + lblW, 97);
            this.txtQuestionId.Size      = new System.Drawing.Size(80, 23);
            this.txtQuestionId.ReadOnly  = true;
            this.txtQuestionId.BackColor = System.Drawing.Color.GhostWhite;

            // Question Text
            this.lblQText.Text     = "Question Text:";
            this.lblQText.Location = new System.Drawing.Point(col1, 135);
            this.lblQText.Size     = new System.Drawing.Size(lblW, 20);

            this.txtQuestionText.Location   = new System.Drawing.Point(col1 + lblW, 132);
            this.txtQuestionText.Size       = new System.Drawing.Size(550, 60);
            this.txtQuestionText.Multiline  = true;
            this.txtQuestionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // Option A
            this.lblA.Text     = "Option A:";
            this.lblA.Location = new System.Drawing.Point(col1, 210);
            this.lblA.Size     = new System.Drawing.Size(lblW, 20);

            this.txtOptionA.Location = new System.Drawing.Point(col1 + lblW, 207);
            this.txtOptionA.Size     = new System.Drawing.Size(txtW, 23);

            // Option B
            this.lblB.Text     = "Option B:";
            this.lblB.Location = new System.Drawing.Point(col2, 210);
            this.lblB.Size     = new System.Drawing.Size(70, 20);

            this.txtOptionB.Location = new System.Drawing.Point(col2 + 75, 207);
            this.txtOptionB.Size     = new System.Drawing.Size(txtW, 23);

            // Option C
            this.lblC.Text     = "Option C:";
            this.lblC.Location = new System.Drawing.Point(col1, 248);
            this.lblC.Size     = new System.Drawing.Size(lblW, 20);

            this.txtOptionC.Location = new System.Drawing.Point(col1 + lblW, 245);
            this.txtOptionC.Size     = new System.Drawing.Size(txtW, 23);

            // Option D
            this.lblD.Text     = "Option D:";
            this.lblD.Location = new System.Drawing.Point(col2, 248);
            this.lblD.Size     = new System.Drawing.Size(70, 20);

            this.txtOptionD.Location = new System.Drawing.Point(col2 + 75, 245);
            this.txtOptionD.Size     = new System.Drawing.Size(txtW, 23);

            // Correct Answer
            this.lblCorrect.Text     = "Correct Ans:";
            this.lblCorrect.Location = new System.Drawing.Point(col1, 286);
            this.lblCorrect.Size     = new System.Drawing.Size(lblW, 20);

            this.cmbCorrect.Location      = new System.Drawing.Point(col1 + lblW, 283);
            this.cmbCorrect.Size          = new System.Drawing.Size(80, 23);
            this.cmbCorrect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCorrect.Items.AddRange(new object[] { "A", "B", "C", "D" });

            // Subject
            this.lblSubject.Text     = "Subject:";
            this.lblSubject.Location = new System.Drawing.Point(col2, 286);
            this.lblSubject.Size     = new System.Drawing.Size(70, 20);

            this.txtSubject.Location = new System.Drawing.Point(col2 + 75, 283);
            this.txtSubject.Size     = new System.Drawing.Size(180, 23);

            // Marks
            this.lblMarks.Text     = "Marks:";
            this.lblMarks.Location = new System.Drawing.Point(col2 + 265, 286);
            this.lblMarks.Size     = new System.Drawing.Size(50, 20);

            this.txtMarks.Location = new System.Drawing.Point(col2 + 320, 283);
            this.txtMarks.Size     = new System.Drawing.Size(60, 23);

            // pnlButtons
            this.pnlButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height    = 55;
            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnNew, this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClose });

            MkBtn(this.btnNew,    "🆕 New",    10,  System.Drawing.Color.Gray);
            MkBtn(this.btnAdd,    "➕ Add",    115, System.Drawing.Color.FromArgb(0, 128, 0));
            MkBtn(this.btnUpdate, "✏️ Update", 220, System.Drawing.Color.FromArgb(0, 100, 200));
            MkBtn(this.btnDelete, "🗑️ Delete", 325, System.Drawing.Color.FromArgb(180, 0, 0));
            MkBtn(this.btnClose,  "✖ Close",   600, System.Drawing.Color.FromArgb(80, 80, 80));

            this.btnNew.Click    += new System.EventHandler(this.btnNew_Click);
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClose.Click  += new System.EventHandler(this.btnClose_Click);

            // ManageQuestionsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(800, 420);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlTop, this.lblQId, this.txtQuestionId,
                this.lblQText, this.txtQuestionText,
                this.lblA, this.txtOptionA, this.lblB, this.txtOptionB,
                this.lblC, this.txtOptionC, this.lblD, this.txtOptionD,
                this.lblCorrect, this.cmbCorrect,
                this.lblSubject, this.txtSubject,
                this.lblMarks, this.txtMarks,
                this.pnlButtons });
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "ManageQuestionsForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Manage Questions";

            this.pnlTop.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void MkBtn(System.Windows.Forms.Button btn, string text, int x, System.Drawing.Color color)
        {
            btn.Text      = text;
            btn.Location  = new System.Drawing.Point(x, 10);
            btn.Size      = new System.Drawing.Size(100, 34);
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        }

        private System.Windows.Forms.Panel    pnlTop, pnlButtons;
        private System.Windows.Forms.Label    lblTitle, lblNav;
        private System.Windows.Forms.Button   btnPrev, btnNext;
        private System.Windows.Forms.Label    lblQId, lblQText, lblA, lblB, lblC, lblD, lblCorrect, lblSubject, lblMarks;
        private System.Windows.Forms.TextBox  txtQuestionId, txtQuestionText, txtOptionA, txtOptionB;
        private System.Windows.Forms.TextBox  txtOptionC, txtOptionD, txtSubject, txtMarks;
        private System.Windows.Forms.ComboBox cmbCorrect;
        private System.Windows.Forms.Button   btnNew, btnAdd, btnUpdate, btnDelete, btnClose;
    }
}
