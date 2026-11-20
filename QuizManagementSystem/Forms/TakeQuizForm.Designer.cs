namespace QuizManagementSystem.Forms
{
    partial class TakeQuizForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop      = new System.Windows.Forms.Panel();
            this.lblExamTitle= new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblTimer    = new System.Windows.Forms.Label();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblMarksInfo= new System.Windows.Forms.Label();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbD = new System.Windows.Forms.RadioButton();
            this.pnlNav      = new System.Windows.Forms.Panel();
            this.btnPrev     = new System.Windows.Forms.Button();
            this.btnNext     = new System.Windows.Forms.Button();
            this.btnSubmit   = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(20, 40, 80);
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblExamTitle, this.lblProgress, this.lblTimer });
            this.pnlTop.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 75;

            this.lblExamTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblExamTitle.ForeColor = System.Drawing.Color.White;
            this.lblExamTitle.Location  = new System.Drawing.Point(10, 8);
            this.lblExamTitle.Size      = new System.Drawing.Size(530, 28);

            this.lblProgress.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProgress.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblProgress.Location  = new System.Drawing.Point(10, 45);
            this.lblProgress.Size      = new System.Drawing.Size(250, 20);

            this.lblTimer.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTimer.Location  = new System.Drawing.Point(530, 20);
            this.lblTimer.Size      = new System.Drawing.Size(150, 32);
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlQuestion
            this.pnlQuestion.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestion.Padding   = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlQuestion.BackColor = System.Drawing.Color.White;
            this.pnlQuestion.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMarksInfo, this.lblQuestion, this.rbA, this.rbB, this.rbC, this.rbD });

            this.lblQuestion.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location  = new System.Drawing.Point(20, 15);
            this.lblQuestion.Size      = new System.Drawing.Size(660, 80);
            this.lblQuestion.AutoSize  = false;

            this.lblMarksInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblMarksInfo.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblMarksInfo.Location  = new System.Drawing.Point(560, 15);
            this.lblMarksInfo.Size      = new System.Drawing.Size(120, 20);
            this.lblMarksInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.rbA.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.rbA.Location = new System.Drawing.Point(20, 110);
            this.rbA.Size     = new System.Drawing.Size(660, 30);

            this.rbB.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.rbB.Location = new System.Drawing.Point(20, 150);
            this.rbB.Size     = new System.Drawing.Size(660, 30);

            this.rbC.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.rbC.Location = new System.Drawing.Point(20, 190);
            this.rbC.Size     = new System.Drawing.Size(660, 30);

            this.rbD.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.rbD.Location = new System.Drawing.Point(20, 230);
            this.rbD.Size     = new System.Drawing.Size(660, 30);

            // pnlNav
            this.pnlNav.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNav.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNav.Height    = 55;
            this.pnlNav.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnPrev, this.btnNext, this.btnSubmit });

            MkBtn(this.btnPrev,   "◀ Previous", 10,  System.Drawing.Color.FromArgb(60, 90, 130));
            MkBtn(this.btnNext,   "Next ▶",     130, System.Drawing.Color.FromArgb(60, 90, 130));
            MkBtn(this.btnSubmit, "✔ Submit Quiz", 500, System.Drawing.Color.FromArgb(0, 150, 80));
            this.btnSubmit.Size = new System.Drawing.Size(160, 36);

            this.btnPrev.Click   += new System.EventHandler(this.btnPrev_Click);
            this.btnNext.Click   += new System.EventHandler(this.btnNext_Click);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // TakeQuizForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "TakeQuizForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Take Quiz";

            this.pnlTop.ResumeLayout(false);
            this.pnlQuestion.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MkBtn(System.Windows.Forms.Button btn, string text, int x, System.Drawing.Color color)
        {
            btn.Text      = text;
            btn.Location  = new System.Drawing.Point(x, 10);
            btn.Size      = new System.Drawing.Size(110, 36);
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        private System.Windows.Forms.Panel       pnlTop, pnlQuestion, pnlNav;
        private System.Windows.Forms.Label       lblExamTitle, lblProgress, lblTimer, lblQuestion, lblMarksInfo;
        private System.Windows.Forms.RadioButton rbA, rbB, rbC, rbD;
        private System.Windows.Forms.Button      btnPrev, btnNext, btnSubmit;
    }
}
