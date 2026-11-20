namespace QuizManagementSystem.Forms
{
    partial class StudentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop        = new System.Windows.Forms.Panel();
            this.lblWelcome    = new System.Windows.Forms.Label();
            this.btnRefresh    = new System.Windows.Forms.Button();
            this.btnLogout     = new System.Windows.Forms.Button();
            this.splitMain     = new System.Windows.Forms.SplitContainer();
            this.lblExams      = new System.Windows.Forms.Label();
            this.lstExams      = new System.Windows.Forms.ListBox();
            this.btnTakeQuiz   = new System.Windows.Forms.Button();
            this.lblResults    = new System.Windows.Forms.Label();
            this.dgvMyResults  = new System.Windows.Forms.DataGridView();
            this.btnViewDetail = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitMain).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvMyResults).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblWelcome, this.btnRefresh, this.btnLogout });
            this.pnlTop.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 50;

            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location  = new System.Drawing.Point(10, 13);
            this.lblWelcome.Size      = new System.Drawing.Size(500, 25);

            this.btnRefresh.Text      = "🔄 Refresh";
            this.btnRefresh.Location  = new System.Drawing.Point(630, 10);
            this.btnRefresh.Size      = new System.Drawing.Size(90, 30);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            this.btnLogout.Text      = "Logout";
            this.btnLogout.Location  = new System.Drawing.Point(730, 10);
            this.btnLogout.Size      = new System.Drawing.Size(70, 30);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click    += new System.EventHandler(this.btnLogout_Click);

            // splitMain
            this.splitMain.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitMain.SplitterDistance = 280;

            // Panel1 — Available Exams
            this.splitMain.Panel1.Controls.Add(this.btnTakeQuiz);
            this.splitMain.Panel1.Controls.Add(this.lstExams);
            this.splitMain.Panel1.Controls.Add(this.lblExams);

            this.lblExams.Text     = "📋 Available Exams — select one and click Take Quiz";
            this.lblExams.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExams.Location = new System.Drawing.Point(5, 5);
            this.lblExams.Size     = new System.Drawing.Size(790, 20);

            this.lstExams.Location  = new System.Drawing.Point(5, 30);
            this.lstExams.Size      = new System.Drawing.Size(790, 200);
            this.lstExams.Font      = new System.Drawing.Font("Segoe UI", 10F);

            this.btnTakeQuiz.Text      = "▶  Take Selected Quiz";
            this.btnTakeQuiz.Location  = new System.Drawing.Point(5, 238);
            this.btnTakeQuiz.Size      = new System.Drawing.Size(200, 35);
            this.btnTakeQuiz.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTakeQuiz.BackColor = System.Drawing.Color.FromArgb(0, 150, 80);
            this.btnTakeQuiz.ForeColor = System.Drawing.Color.White;
            this.btnTakeQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeQuiz.FlatAppearance.BorderSize = 0;
            this.btnTakeQuiz.Click    += new System.EventHandler(this.btnTakeQuiz_Click);

            // Panel2 — My Results
            this.splitMain.Panel2.Controls.Add(this.dgvMyResults);
            this.splitMain.Panel2.Controls.Add(this.btnViewDetail);
            this.splitMain.Panel2.Controls.Add(this.lblResults);

            this.lblResults.Text     = "📊 My Results";
            this.lblResults.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResults.Location = new System.Drawing.Point(5, 5);
            this.lblResults.Size     = new System.Drawing.Size(200, 20);

            this.dgvMyResults.Location            = new System.Drawing.Point(5, 30);
            this.dgvMyResults.Size                = new System.Drawing.Size(790, 155);
            this.dgvMyResults.ReadOnly            = true;
            this.dgvMyResults.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyResults.AllowUserToAddRows  = false;

            this.btnViewDetail.Text      = "🔍 View Detailed Result";
            this.btnViewDetail.Location  = new System.Drawing.Point(5, 193);
            this.btnViewDetail.Size      = new System.Drawing.Size(200, 32);
            this.btnViewDetail.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewDetail.Click    += new System.EventHandler(this.btnViewDetail_Click);

            // StudentDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(820, 580);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Quiz Management System - Student Dashboard";
            this.Name          = "StudentDashboard";

            this.pnlTop.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvMyResults).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlTop;
        private System.Windows.Forms.Label          lblWelcome;
        private System.Windows.Forms.Button         btnRefresh, btnLogout;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Label          lblExams, lblResults;
        private System.Windows.Forms.ListBox        lstExams;
        private System.Windows.Forms.Button         btnTakeQuiz, btnViewDetail;
        private System.Windows.Forms.DataGridView   dgvMyResults;
    }
}
