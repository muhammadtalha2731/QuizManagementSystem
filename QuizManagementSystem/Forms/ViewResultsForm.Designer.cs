namespace QuizManagementSystem.Forms
{
    partial class ViewResultsForm
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
            this.lblPageTitle  = new System.Windows.Forms.Label();
            this.pnlSummary    = new System.Windows.Forms.Panel();
            this.lblStudentName= new System.Windows.Forms.Label();
            this.lblExamName   = new System.Windows.Forms.Label();
            this.lblMarks      = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblStatus     = new System.Windows.Forms.Label();
            this.lblDate       = new System.Windows.Forms.Label();
            this.lblBreakdown  = new System.Windows.Forms.Label();
            this.dgvAnswers    = new System.Windows.Forms.DataGridView();
            this.pnlBottom     = new System.Windows.Forms.Panel();
            this.btnPrint      = new System.Windows.Forms.Button();
            this.btnClose      = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvAnswers).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(20, 60, 40);
            this.pnlTop.Controls.Add(this.lblPageTitle);
            this.pnlTop.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;

            this.lblPageTitle.Text      = "📊 Quiz Result — Detailed View";
            this.lblPageTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location  = new System.Drawing.Point(10, 12);
            this.lblPageTitle.Size      = new System.Drawing.Size(680, 30);

            // pnlSummary
            this.pnlSummary.BackColor  = System.Drawing.Color.FromArgb(245, 250, 245);
            this.pnlSummary.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Height     = 150;
            this.pnlSummary.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStudentName, this.lblExamName, this.lblMarks,
                this.lblPercentage, this.lblDate, this.lblStatus });

            System.Windows.Forms.Label[] summaryLabels = {
                this.lblStudentName, this.lblExamName,
                this.lblMarks, this.lblPercentage, this.lblDate };

            int sy = 12;
            foreach (var lbl in summaryLabels)
            {
                lbl.Font     = new System.Drawing.Font("Segoe UI", 10F);
                lbl.Location = new System.Drawing.Point(20, sy);
                lbl.Size     = new System.Drawing.Size(430, 22);
                sy += 26;
            }

            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location  = new System.Drawing.Point(500, 40);
            this.lblStatus.Size      = new System.Drawing.Size(180, 60);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Breakdown label
            this.lblBreakdown.Text     = "Per-Question Breakdown:";
            this.lblBreakdown.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBreakdown.Location = new System.Drawing.Point(5, 213);
            this.lblBreakdown.Size     = new System.Drawing.Size(250, 22);

            // dgvAnswers
            this.dgvAnswers.Location            = new System.Drawing.Point(5, 238);
            this.dgvAnswers.Size                = new System.Drawing.Size(680, 260);
            this.dgvAnswers.ReadOnly            = true;
            this.dgvAnswers.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnswers.AllowUserToAddRows  = false;
            this.dgvAnswers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnswers.RowHeadersVisible   = false;

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height    = 50;
            this.pnlBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnPrint, this.btnClose });

            this.btnPrint.Text      = "📋 Copy to Clipboard";
            this.btnPrint.Location  = new System.Drawing.Point(10, 8);
            this.btnPrint.Size      = new System.Drawing.Size(170, 33);
            this.btnPrint.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrint.Click    += new System.EventHandler(this.btnPrint_Click);

            this.btnClose.Text      = "✖  Close";
            this.btnClose.Location  = new System.Drawing.Point(570, 8);
            this.btnClose.Size      = new System.Drawing.Size(110, 33);
            this.btnClose.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Click    += new System.EventHandler(this.btnClose_Click);

            // ViewResultsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(700, 570);
            this.Controls.Add(this.lblBreakdown);
            this.Controls.Add(this.dgvAnswers);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "ViewResultsForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "View Result";

            this.pnlTop.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvAnswers).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel        pnlTop, pnlSummary, pnlBottom;
        private System.Windows.Forms.Label        lblPageTitle;
        private System.Windows.Forms.Label        lblStudentName, lblExamName, lblMarks, lblPercentage, lblStatus, lblDate;
        private System.Windows.Forms.Label        lblBreakdown;
        private System.Windows.Forms.DataGridView dgvAnswers;
        private System.Windows.Forms.Button       btnPrint, btnClose;
    }
}
