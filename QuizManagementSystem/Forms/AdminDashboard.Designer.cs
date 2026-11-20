namespace QuizManagementSystem.Forms
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlStudentBtns = new System.Windows.Forms.Panel();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.tabQuestions = new System.Windows.Forms.TabPage();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.btnManageQuestions = new System.Windows.Forms.Button();
            this.tabExams = new System.Windows.Forms.TabPage();
            this.dgvExams = new System.Windows.Forms.DataGridView();
            this.pnlExamBtns = new System.Windows.Forms.Panel();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnEditExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlStudentBtns.SuspendLayout();
            this.tabQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.tabExams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.pnlExamBtns.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1410, 77);
            this.pnlTop.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(15, 22);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(900, 35);
            this.lblWelcome.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1095, 15);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 46);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1245, 15);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 46);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabStudents);
            this.tabControl.Controls.Add(this.tabQuestions);
            this.tabControl.Controls.Add(this.tabExams);
            this.tabControl.Controls.Add(this.tabResults);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 77);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1410, 877);
            this.tabControl.TabIndex = 0;
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.dgvStudents);
            this.tabStudents.Controls.Add(this.pnlStudentBtns);
            this.tabStudents.Location = new System.Drawing.Point(4, 37);
            this.tabStudents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.tabStudents.Size = new System.Drawing.Size(1402, 836);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "  👥 Students  ";
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeight = 34;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.Location = new System.Drawing.Point(8, 8);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersWidth = 62;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(1386, 751);
            this.dgvStudents.TabIndex = 0;
            // 
            // pnlStudentBtns
            // 
            this.pnlStudentBtns.Controls.Add(this.btnAddStudent);
            this.pnlStudentBtns.Controls.Add(this.btnEditStudent);
            this.pnlStudentBtns.Controls.Add(this.btnDeleteStudent);
            this.pnlStudentBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStudentBtns.Location = new System.Drawing.Point(8, 759);
            this.pnlStudentBtns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlStudentBtns.Name = "pnlStudentBtns";
            this.pnlStudentBtns.Size = new System.Drawing.Size(1386, 69);
            this.pnlStudentBtns.TabIndex = 1;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(8, 12);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(135, 46);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "➕ Add";
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnEditStudent
            // 
            this.btnEditStudent.Location = new System.Drawing.Point(158, 12);
            this.btnEditStudent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.Size = new System.Drawing.Size(135, 46);
            this.btnEditStudent.TabIndex = 1;
            this.btnEditStudent.Text = "✏️ Edit";
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(308, 12);
            this.btnDeleteStudent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(135, 46);
            this.btnDeleteStudent.TabIndex = 2;
            this.btnDeleteStudent.Text = "🗑️ Delete";
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // tabQuestions
            // 
            this.tabQuestions.Controls.Add(this.dgvQuestions);
            this.tabQuestions.Controls.Add(this.btnManageQuestions);
            this.tabQuestions.Location = new System.Drawing.Point(4, 37);
            this.tabQuestions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabQuestions.Name = "tabQuestions";
            this.tabQuestions.Size = new System.Drawing.Size(1402, 836);
            this.tabQuestions.TabIndex = 1;
            this.tabQuestions.Text = "  ❓ Questions  ";
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestions.ColumnHeadersHeight = 34;
            this.dgvQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestions.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            this.dgvQuestions.RowHeadersWidth = 62;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(1402, 774);
            this.dgvQuestions.TabIndex = 0;
            // 
            // btnManageQuestions
            // 
            this.btnManageQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnManageQuestions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnManageQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageQuestions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageQuestions.ForeColor = System.Drawing.Color.White;
            this.btnManageQuestions.Location = new System.Drawing.Point(0, 774);
            this.btnManageQuestions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnManageQuestions.Name = "btnManageQuestions";
            this.btnManageQuestions.Size = new System.Drawing.Size(1402, 62);
            this.btnManageQuestions.TabIndex = 1;
            this.btnManageQuestions.Text = "📋 Manage Questions (LinkedList Editor)";
            this.btnManageQuestions.UseVisualStyleBackColor = false;
            this.btnManageQuestions.Click += new System.EventHandler(this.btnManageQuestions_Click);
            // 
            // tabExams
            // 
            this.tabExams.Controls.Add(this.dgvExams);
            this.tabExams.Controls.Add(this.pnlExamBtns);
            this.tabExams.Location = new System.Drawing.Point(4, 37);
            this.tabExams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabExams.Name = "tabExams";
            this.tabExams.Size = new System.Drawing.Size(1402, 836);
            this.tabExams.TabIndex = 2;
            this.tabExams.Text = "  📋 Exams  ";
            // 
            // dgvExams
            // 
            this.dgvExams.AllowUserToAddRows = false;
            this.dgvExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExams.ColumnHeadersHeight = 34;
            this.dgvExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExams.Location = new System.Drawing.Point(0, 0);
            this.dgvExams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.ReadOnly = true;
            this.dgvExams.RowHeadersWidth = 62;
            this.dgvExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExams.Size = new System.Drawing.Size(1402, 767);
            this.dgvExams.TabIndex = 0;
            // 
            // pnlExamBtns
            // 
            this.pnlExamBtns.Controls.Add(this.btnAddExam);
            this.pnlExamBtns.Controls.Add(this.btnEditExam);
            this.pnlExamBtns.Controls.Add(this.btnDeleteExam);
            this.pnlExamBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExamBtns.Location = new System.Drawing.Point(0, 767);
            this.pnlExamBtns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlExamBtns.Name = "pnlExamBtns";
            this.pnlExamBtns.Size = new System.Drawing.Size(1402, 69);
            this.pnlExamBtns.TabIndex = 1;
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(8, 12);
            this.btnAddExam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(135, 46);
            this.btnAddExam.TabIndex = 0;
            this.btnAddExam.Text = "➕ Add";
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // btnEditExam
            // 
            this.btnEditExam.Location = new System.Drawing.Point(158, 12);
            this.btnEditExam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditExam.Name = "btnEditExam";
            this.btnEditExam.Size = new System.Drawing.Size(135, 46);
            this.btnEditExam.TabIndex = 1;
            this.btnEditExam.Text = "✏️ Edit";
            this.btnEditExam.Click += new System.EventHandler(this.btnEditExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(308, 12);
            this.btnDeleteExam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(135, 46);
            this.btnDeleteExam.TabIndex = 2;
            this.btnDeleteExam.Text = "🗑️ Delete";
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.dgvResults);
            this.tabResults.Controls.Add(this.btnViewDetail);
            this.tabResults.Location = new System.Drawing.Point(4, 37);
            this.tabResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabResults.Name = "tabResults";
            this.tabResults.Size = new System.Drawing.Size(1402, 836);
            this.tabResults.TabIndex = 3;
            this.tabResults.Text = "  📊 Results  ";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeight = 34;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidth = 62;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1402, 774);
            this.dgvResults.TabIndex = 0;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnViewDetail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewDetail.Location = new System.Drawing.Point(0, 774);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(1402, 62);
            this.btnViewDetail.TabIndex = 1;
            this.btnViewDetail.Text = "🔍 View Detailed Result";
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 954);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz Management System - Admin Dashboard";
            this.pnlTop.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlStudentBtns.ResumeLayout(false);
            this.tabQuestions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.tabExams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.pnlExamBtns.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel          pnlTop;
        private System.Windows.Forms.Label          lblWelcome;
        private System.Windows.Forms.Button         btnRefresh, btnLogout;
        private System.Windows.Forms.TabControl     tabControl;
        private System.Windows.Forms.TabPage        tabStudents, tabQuestions, tabExams, tabResults;
        private System.Windows.Forms.DataGridView   dgvStudents, dgvQuestions, dgvExams, dgvResults;
        private System.Windows.Forms.Panel          pnlStudentBtns, pnlExamBtns;
        private System.Windows.Forms.Button         btnAddStudent, btnEditStudent, btnDeleteStudent;
        private System.Windows.Forms.Button         btnManageQuestions;
        private System.Windows.Forms.Button         btnAddExam, btnEditExam, btnDeleteExam;
        private System.Windows.Forms.Button         btnViewDetail;
    }
}
