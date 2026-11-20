namespace QuizManagementSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblEmail    = new System.Windows.Forms.Label();
            this.txtEmail    = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.lblError    = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size     = new System.Drawing.Size(420, 100);

            // lblTitle
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(15, 15);
            this.lblTitle.Size      = new System.Drawing.Size(390, 40);
            this.lblTitle.Text      = "📝 Quiz Management System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.Location  = new System.Drawing.Point(15, 58);
            this.lblSubtitle.Size      = new System.Drawing.Size(390, 25);
            this.lblSubtitle.Text      = "Sign in as Admin or Student";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblEmail
            this.lblEmail.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(50, 130);
            this.lblEmail.Size     = new System.Drawing.Size(100, 23);
            this.lblEmail.Text     = "Email:";

            // txtEmail
            this.txtEmail.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(50, 155);
            this.txtEmail.Size     = new System.Drawing.Size(320, 26);
            this.txtEmail.Name     = "txtEmail";

            // lblPassword
            this.lblPassword.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(50, 200);
            this.lblPassword.Size     = new System.Drawing.Size(100, 23);
            this.lblPassword.Text     = "Password:";

            // txtPassword
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location     = new System.Drawing.Point(50, 225);
            this.txtPassword.Size         = new System.Drawing.Size(320, 26);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location  = new System.Drawing.Point(50, 275);
            this.btnLogin.Size      = new System.Drawing.Size(320, 40);
            this.btnLogin.Text      = "Login";
            this.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // lblError
            this.lblError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location  = new System.Drawing.Point(50, 325);
            this.lblError.Size      = new System.Drawing.Size(320, 40);
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(420, 380);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "LoginForm";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Quiz Management System - Login";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Controls
        private System.Windows.Forms.Panel    pnlHeader;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblSubtitle;
        private System.Windows.Forms.Label    lblEmail;
        private System.Windows.Forms.TextBox  txtEmail;
        private System.Windows.Forms.Label    lblPassword;
        private System.Windows.Forms.TextBox  txtPassword;
        private System.Windows.Forms.Button   btnLogin;
        private System.Windows.Forms.Label    lblError;
    }
}
