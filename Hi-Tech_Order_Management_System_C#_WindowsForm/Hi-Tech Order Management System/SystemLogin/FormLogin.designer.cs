namespace SystemLogin
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserID = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelTitleLogin = new System.Windows.Forms.Label();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonShowOrHide = new System.Windows.Forms.Button();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUserID
            // 
            this.labelUserID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelUserID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUserID.Location = new System.Drawing.Point(48, 129);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(112, 22);
            this.labelUserID.TabIndex = 1;
            this.labelUserID.Text = "User ID";
            this.labelUserID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonLogin.Location = new System.Drawing.Point(135, 303);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(114, 36);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Tag = "";
            this.buttonLogin.Text = "&Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxUserID.Location = new System.Drawing.Point(201, 129);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(133, 22);
            this.textBoxUserID.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPassword.Location = new System.Drawing.Point(48, 217);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(112, 22);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPassword.Location = new System.Drawing.Point(201, 217);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(133, 22);
            this.textBoxPassword.TabIndex = 10;
            // 
            // labelTitleLogin
            // 
            this.labelTitleLogin.BackColor = System.Drawing.Color.LightGray;
            this.labelTitleLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitleLogin.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelTitleLogin.Location = new System.Drawing.Point(48, 18);
            this.labelTitleLogin.Name = "labelTitleLogin";
            this.labelTitleLogin.Size = new System.Drawing.Size(316, 87);
            this.labelTitleLogin.TabIndex = 11;
            this.labelTitleLogin.Text = "Hi-Tech Order Management System";
            this.labelTitleLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.label17);
            this.groupBoxLogin.Controls.Add(this.buttonShowOrHide);
            this.groupBoxLogin.Controls.Add(this.labelTitleLogin);
            this.groupBoxLogin.Controls.Add(this.labelUserID);
            this.groupBoxLogin.Controls.Add(this.buttonLogin);
            this.groupBoxLogin.Controls.Add(this.textBoxPassword);
            this.groupBoxLogin.Controls.Add(this.textBoxUserID);
            this.groupBoxLogin.Controls.Add(this.labelPassword);
            this.groupBoxLogin.Location = new System.Drawing.Point(24, 21);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(404, 404);
            this.groupBoxLogin.TabIndex = 13;
            this.groupBoxLogin.TabStop = false;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label17.Location = new System.Drawing.Point(198, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 31);
            this.label17.TabIndex = 14;
            this.label17.Text = "(4 digit number)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonShowOrHide
            // 
            this.buttonShowOrHide.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonShowOrHide.Location = new System.Drawing.Point(340, 211);
            this.buttonShowOrHide.Name = "buttonShowOrHide";
            this.buttonShowOrHide.Size = new System.Drawing.Size(58, 34);
            this.buttonShowOrHide.TabIndex = 19;
            this.buttonShowOrHide.Tag = "";
            this.buttonShowOrHide.Text = "Show";
            this.buttonShowOrHide.UseVisualStyleBackColor = false;
            this.buttonShowOrHide.Click += new System.EventHandler(this.buttonShowOrHide_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 440);
            this.Controls.Add(this.groupBoxLogin);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelTitleLogin;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button buttonShowOrHide;
        private System.Windows.Forms.Label label17;
    }
}