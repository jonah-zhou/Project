namespace Employee_and_User.GUI
{
    partial class FormEmployeeUser
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
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSearchUser = new System.Windows.Forms.Button();
            this.labelDisplayUser = new System.Windows.Forms.Label();
            this.textBoxSearchUser = new System.Windows.Forms.TextBox();
            this.comboBoxSearchUser = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBoxUserInformation = new System.Windows.Forms.GroupBox();
            this.buttonShowOrHide2 = new System.Windows.Forms.Button();
            this.textBoxReenterPassword = new System.Windows.Forms.TextBox();
            this.labelPasswordConfirm = new System.Windows.Forms.Label();
            this.buttonShowOrHide = new System.Windows.Forms.Button();
            this.buttonClearUser = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonListUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonUpdateUser = new System.Windows.Forms.Button();
            this.buttonSaveUser = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewEmployees = new System.Windows.Forms.ListView();
            this.columnHeaderEmployeeID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderJobId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxEmployee = new System.Windows.Forms.GroupBox();
            this.comboBoxJobTitle = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmployeeID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonToLogin = new System.Windows.Forms.Button();
            this.groupBoxUserInformation.SuspendLayout();
            this.groupBoxEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.BackColor = System.Drawing.SystemColors.Info;
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(735, 434);
            this.listViewUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(672, 175);
            this.listViewUsers.TabIndex = 74;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.SelectedIndexChanged += new System.EventHandler(this.listViewUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User ID";
            this.columnHeader1.Width = 202;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Password";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Employee ID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 236;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label15.Location = new System.Drawing.Point(860, 362);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 28);
            this.label15.TabIndex = 73;
            this.label15.Text = "Please Select First";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSearchUser
            // 
            this.buttonSearchUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearchUser.Location = new System.Drawing.Point(1230, 379);
            this.buttonSearchUser.Name = "buttonSearchUser";
            this.buttonSearchUser.Size = new System.Drawing.Size(163, 40);
            this.buttonSearchUser.TabIndex = 70;
            this.buttonSearchUser.Tag = "";
            this.buttonSearchUser.Text = "Search Employee";
            this.buttonSearchUser.UseVisualStyleBackColor = false;
            this.buttonSearchUser.Click += new System.EventHandler(this.buttonSearchUser_Click);
            // 
            // labelDisplayUser
            // 
            this.labelDisplayUser.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelDisplayUser.Location = new System.Drawing.Point(1020, 362);
            this.labelDisplayUser.Name = "labelDisplayUser";
            this.labelDisplayUser.Size = new System.Drawing.Size(194, 28);
            this.labelDisplayUser.TabIndex = 71;
            this.labelDisplayUser.Text = "Message";
            this.labelDisplayUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearchUser.Location = new System.Drawing.Point(1050, 395);
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.Size = new System.Drawing.Size(138, 22);
            this.textBoxSearchUser.TabIndex = 69;
            // 
            // comboBoxSearchUser
            // 
            this.comboBoxSearchUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearchUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchUser.FormattingEnabled = true;
            this.comboBoxSearchUser.Items.AddRange(new object[] {
            "User ID"});
            this.comboBoxSearchUser.Location = new System.Drawing.Point(863, 393);
            this.comboBoxSearchUser.Name = "comboBoxSearchUser";
            this.comboBoxSearchUser.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSearchUser.TabIndex = 68;
            this.comboBoxSearchUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchUser_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(746, 389);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(108, 30);
            this.label18.TabIndex = 72;
            this.label18.Text = "Search By";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxUserInformation
            // 
            this.groupBoxUserInformation.Controls.Add(this.buttonShowOrHide2);
            this.groupBoxUserInformation.Controls.Add(this.textBoxReenterPassword);
            this.groupBoxUserInformation.Controls.Add(this.labelPasswordConfirm);
            this.groupBoxUserInformation.Controls.Add(this.buttonShowOrHide);
            this.groupBoxUserInformation.Controls.Add(this.buttonClearUser);
            this.groupBoxUserInformation.Controls.Add(this.textBoxPassword);
            this.groupBoxUserInformation.Controls.Add(this.label13);
            this.groupBoxUserInformation.Controls.Add(this.buttonListUser);
            this.groupBoxUserInformation.Controls.Add(this.buttonDeleteUser);
            this.groupBoxUserInformation.Controls.Add(this.buttonUpdateUser);
            this.groupBoxUserInformation.Controls.Add(this.buttonSaveUser);
            this.groupBoxUserInformation.Controls.Add(this.label17);
            this.groupBoxUserInformation.Controls.Add(this.textBoxUserID);
            this.groupBoxUserInformation.Controls.Add(this.labelUserId);
            this.groupBoxUserInformation.Location = new System.Drawing.Point(794, 54);
            this.groupBoxUserInformation.Name = "groupBoxUserInformation";
            this.groupBoxUserInformation.Size = new System.Drawing.Size(525, 305);
            this.groupBoxUserInformation.TabIndex = 62;
            this.groupBoxUserInformation.TabStop = false;
            this.groupBoxUserInformation.Text = "User Information";
            // 
            // buttonShowOrHide2
            // 
            this.buttonShowOrHide2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonShowOrHide2.Location = new System.Drawing.Point(234, 246);
            this.buttonShowOrHide2.Name = "buttonShowOrHide2";
            this.buttonShowOrHide2.Size = new System.Drawing.Size(58, 34);
            this.buttonShowOrHide2.TabIndex = 24;
            this.buttonShowOrHide2.Tag = "";
            this.buttonShowOrHide2.Text = "Show";
            this.buttonShowOrHide2.UseVisualStyleBackColor = false;
            this.buttonShowOrHide2.Click += new System.EventHandler(this.buttonShowOrHide2_Click);
            // 
            // textBoxReenterPassword
            // 
            this.textBoxReenterPassword.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxReenterPassword.Enabled = false;
            this.textBoxReenterPassword.Location = new System.Drawing.Point(159, 218);
            this.textBoxReenterPassword.Name = "textBoxReenterPassword";
            this.textBoxReenterPassword.PasswordChar = '*';
            this.textBoxReenterPassword.Size = new System.Drawing.Size(133, 22);
            this.textBoxReenterPassword.TabIndex = 23;
            // 
            // labelPasswordConfirm
            // 
            this.labelPasswordConfirm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPasswordConfirm.Location = new System.Drawing.Point(25, 216);
            this.labelPasswordConfirm.Name = "labelPasswordConfirm";
            this.labelPasswordConfirm.Size = new System.Drawing.Size(112, 40);
            this.labelPasswordConfirm.TabIndex = 22;
            this.labelPasswordConfirm.Text = "Re-enter Password";
            this.labelPasswordConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonShowOrHide
            // 
            this.buttonShowOrHide.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonShowOrHide.Location = new System.Drawing.Point(234, 156);
            this.buttonShowOrHide.Name = "buttonShowOrHide";
            this.buttonShowOrHide.Size = new System.Drawing.Size(58, 34);
            this.buttonShowOrHide.TabIndex = 20;
            this.buttonShowOrHide.Tag = "";
            this.buttonShowOrHide.Text = "Show";
            this.buttonShowOrHide.UseVisualStyleBackColor = false;
            this.buttonShowOrHide.Click += new System.EventHandler(this.buttonShowOrHide_Click);
            // 
            // buttonClearUser
            // 
            this.buttonClearUser.BackColor = System.Drawing.Color.Tan;
            this.buttonClearUser.Location = new System.Drawing.Point(335, 244);
            this.buttonClearUser.Name = "buttonClearUser";
            this.buttonClearUser.Size = new System.Drawing.Size(150, 36);
            this.buttonClearUser.TabIndex = 11;
            this.buttonClearUser.Tag = "";
            this.buttonClearUser.Text = "Clear All";
            this.buttonClearUser.UseVisualStyleBackColor = false;
            this.buttonClearUser.Click += new System.EventHandler(this.buttonClearUser_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(154, 127);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(138, 22);
            this.textBoxPassword.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(25, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 22);
            this.label13.TabIndex = 10;
            this.label13.Text = "Password";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonListUser
            // 
            this.buttonListUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListUser.Location = new System.Drawing.Point(335, 192);
            this.buttonListUser.Name = "buttonListUser";
            this.buttonListUser.Size = new System.Drawing.Size(150, 36);
            this.buttonListUser.TabIndex = 10;
            this.buttonListUser.Tag = "";
            this.buttonListUser.Text = "List Users";
            this.buttonListUser.UseVisualStyleBackColor = false;
            this.buttonListUser.Click += new System.EventHandler(this.buttonListUser_Click);
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDeleteUser.Enabled = false;
            this.buttonDeleteUser.Location = new System.Drawing.Point(335, 138);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(150, 36);
            this.buttonDeleteUser.TabIndex = 9;
            this.buttonDeleteUser.Tag = "";
            this.buttonDeleteUser.Text = "Delete User";
            this.buttonDeleteUser.UseVisualStyleBackColor = false;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateUser.Enabled = false;
            this.buttonUpdateUser.Location = new System.Drawing.Point(335, 83);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(150, 38);
            this.buttonUpdateUser.TabIndex = 8;
            this.buttonUpdateUser.Tag = "";
            this.buttonUpdateUser.Text = "Update User";
            this.buttonUpdateUser.UseVisualStyleBackColor = false;
            this.buttonUpdateUser.Click += new System.EventHandler(this.buttonUpdateUser_Click);
            // 
            // buttonSaveUser
            // 
            this.buttonSaveUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSaveUser.Enabled = false;
            this.buttonSaveUser.Location = new System.Drawing.Point(335, 29);
            this.buttonSaveUser.Name = "buttonSaveUser";
            this.buttonSaveUser.Size = new System.Drawing.Size(150, 36);
            this.buttonSaveUser.TabIndex = 7;
            this.buttonSaveUser.Tag = "";
            this.buttonSaveUser.Text = "Save User";
            this.buttonSaveUser.UseVisualStyleBackColor = false;
            this.buttonSaveUser.Click += new System.EventHandler(this.buttonSaveUser_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label17.Location = new System.Drawing.Point(156, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 31);
            this.label17.TabIndex = 2;
            this.label17.Text = "(4 digit number)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxUserID.Enabled = false;
            this.textBoxUserID.Location = new System.Drawing.Point(154, 43);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(138, 22);
            this.textBoxUserID.TabIndex = 1;
            // 
            // labelUserId
            // 
            this.labelUserId.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelUserId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUserId.Location = new System.Drawing.Point(25, 43);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(112, 22);
            this.labelUserId.TabIndex = 0;
            this.labelUserId.Text = "User ID";
            this.labelUserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Location = new System.Drawing.Point(185, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 28);
            this.label8.TabIndex = 67;
            this.label8.Text = "Please Select First";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewEmployees
            // 
            this.listViewEmployees.BackColor = System.Drawing.SystemColors.Info;
            this.listViewEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEmployeeID,
            this.columnHeaderLastName,
            this.columnHeaderFirstName,
            this.columnHeaderPhoneNumber,
            this.columnHeaderEmail,
            this.columnHeaderJobId});
            this.listViewEmployees.FullRowSelect = true;
            this.listViewEmployees.GridLines = true;
            this.listViewEmployees.HideSelection = false;
            this.listViewEmployees.Location = new System.Drawing.Point(19, 434);
            this.listViewEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewEmployees.Name = "listViewEmployees";
            this.listViewEmployees.Size = new System.Drawing.Size(709, 175);
            this.listViewEmployees.TabIndex = 66;
            this.listViewEmployees.UseCompatibleStateImageBehavior = false;
            this.listViewEmployees.View = System.Windows.Forms.View.Details;
            this.listViewEmployees.SelectedIndexChanged += new System.EventHandler(this.listViewEmployees_SelectedIndexChanged);
            // 
            // columnHeaderEmployeeID
            // 
            this.columnHeaderEmployeeID.Text = "Employee ID";
            this.columnHeaderEmployeeID.Width = 169;
            // 
            // columnHeaderLastName
            // 
            this.columnHeaderLastName.Text = "Last Name";
            this.columnHeaderLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderLastName.Width = 91;
            // 
            // columnHeaderFirstName
            // 
            this.columnHeaderFirstName.Text = "First Name";
            this.columnHeaderFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderFirstName.Width = 121;
            // 
            // columnHeaderPhoneNumber
            // 
            this.columnHeaderPhoneNumber.Text = "Phone Number";
            this.columnHeaderPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderPhoneNumber.Width = 138;
            // 
            // columnHeaderEmail
            // 
            this.columnHeaderEmail.Text = "Email";
            this.columnHeaderEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderEmail.Width = 83;
            // 
            // columnHeaderJobId
            // 
            this.columnHeaderJobId.Text = "Job ID";
            this.columnHeaderJobId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderJobId.Width = 160;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonExit.Location = new System.Drawing.Point(1281, 665);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 46);
            this.buttonExit.TabIndex = 63;
            this.buttonExit.Tag = "";
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearch.Location = new System.Drawing.Point(555, 379);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(163, 40);
            this.buttonSearch.TabIndex = 60;
            this.buttonSearch.Tag = "";
            this.buttonSearch.Text = "Search Employee";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelDisplay
            // 
            this.labelDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelDisplay.Location = new System.Drawing.Point(345, 362);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(194, 28);
            this.labelDisplay.TabIndex = 64;
            this.labelDisplay.Text = "Message";
            this.labelDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearch.Location = new System.Drawing.Point(375, 395);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(138, 22);
            this.textBoxSearch.TabIndex = 59;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Employee ID",
            "Last Name",
            "First Name",
            "Job ID"});
            this.comboBoxSearch.Location = new System.Drawing.Point(188, 393);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSearch.TabIndex = 58;
            this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(60, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 30);
            this.label6.TabIndex = 65;
            this.label6.Text = "Search By";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxEmployee
            // 
            this.groupBoxEmployee.Controls.Add(this.comboBoxJobTitle);
            this.groupBoxEmployee.Controls.Add(this.buttonClear);
            this.groupBoxEmployee.Controls.Add(this.textBoxEmail);
            this.groupBoxEmployee.Controls.Add(this.label9);
            this.groupBoxEmployee.Controls.Add(this.textBoxPhoneNumber);
            this.groupBoxEmployee.Controls.Add(this.label7);
            this.groupBoxEmployee.Controls.Add(this.buttonList);
            this.groupBoxEmployee.Controls.Add(this.buttonDelete);
            this.groupBoxEmployee.Controls.Add(this.buttonUpdate);
            this.groupBoxEmployee.Controls.Add(this.buttonSave);
            this.groupBoxEmployee.Controls.Add(this.textBoxFirstName);
            this.groupBoxEmployee.Controls.Add(this.textBoxLastName);
            this.groupBoxEmployee.Controls.Add(this.label5);
            this.groupBoxEmployee.Controls.Add(this.label4);
            this.groupBoxEmployee.Controls.Add(this.label3);
            this.groupBoxEmployee.Controls.Add(this.label2);
            this.groupBoxEmployee.Controls.Add(this.textBoxEmployeeID);
            this.groupBoxEmployee.Controls.Add(this.label1);
            this.groupBoxEmployee.Location = new System.Drawing.Point(81, 54);
            this.groupBoxEmployee.Name = "groupBoxEmployee";
            this.groupBoxEmployee.Size = new System.Drawing.Size(525, 305);
            this.groupBoxEmployee.TabIndex = 61;
            this.groupBoxEmployee.TabStop = false;
            this.groupBoxEmployee.Text = "Employee Information";
            // 
            // comboBoxJobTitle
            // 
            this.comboBoxJobTitle.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxJobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJobTitle.FormattingEnabled = true;
            this.comboBoxJobTitle.Items.AddRange(new object[] {
            "MIS Manager",
            "Sales Manager",
            "Inventory Controller",
            "Order Clerks",
            "Accountant"});
            this.comboBoxJobTitle.Location = new System.Drawing.Point(143, 234);
            this.comboBoxJobTitle.Name = "comboBoxJobTitle";
            this.comboBoxJobTitle.Size = new System.Drawing.Size(138, 24);
            this.comboBoxJobTitle.TabIndex = 13;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Tan;
            this.buttonClear.Location = new System.Drawing.Point(335, 244);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(150, 36);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Tag = "";
            this.buttonClear.Text = "&Clear All";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxEmail.Location = new System.Drawing.Point(143, 199);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(138, 22);
            this.textBoxEmail.TabIndex = 5;
            this.textBoxEmail.Text = "abc@abc.com";
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 22);
            this.label9.TabIndex = 12;
            this.label9.Text = "Email";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(143, 162);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(138, 22);
            this.textBoxPhoneNumber.TabIndex = 4;
            this.textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            this.textBoxPhoneNumber.Enter += new System.EventHandler(this.textBoxPhoneNumber_Enter);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(25, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Phone Number";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonList.Location = new System.Drawing.Point(335, 192);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(150, 36);
            this.buttonList.TabIndex = 10;
            this.buttonList.Tag = "";
            this.buttonList.Text = "&List Employees";
            this.buttonList.UseVisualStyleBackColor = false;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDelete.Location = new System.Drawing.Point(335, 138);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(150, 36);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Tag = "";
            this.buttonDelete.Text = "&Delete Employee";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdate.Location = new System.Drawing.Point(335, 83);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(150, 38);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Tag = "";
            this.buttonUpdate.Text = "&Update Employee";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSave.Location = new System.Drawing.Point(335, 29);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 36);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Tag = "";
            this.buttonSave.Text = "&Save Employee";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxFirstName.Location = new System.Drawing.Point(143, 127);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(138, 22);
            this.textBoxFirstName.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxLastName.Location = new System.Drawing.Point(143, 91);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(138, 22);
            this.textBoxLastName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Job Title";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "First Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(140, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "(4 digit number)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmployeeID
            // 
            this.textBoxEmployeeID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxEmployeeID.Location = new System.Drawing.Point(143, 29);
            this.textBoxEmployeeID.Name = "textBoxEmployeeID";
            this.textBoxEmployeeID.Size = new System.Drawing.Size(138, 22);
            this.textBoxEmployeeID.TabIndex = 1;
            this.textBoxEmployeeID.TextChanged += new System.EventHandler(this.textBoxEmployeeID_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonToLogin
            // 
            this.buttonToLogin.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonToLogin.Location = new System.Drawing.Point(1102, 665);
            this.buttonToLogin.Name = "buttonToLogin";
            this.buttonToLogin.Size = new System.Drawing.Size(128, 46);
            this.buttonToLogin.TabIndex = 75;
            this.buttonToLogin.Tag = "";
            this.buttonToLogin.Text = "Back To Login";
            this.buttonToLogin.UseVisualStyleBackColor = false;
            this.buttonToLogin.Click += new System.EventHandler(this.buttonToLogin_Click);
            // 
            // FormEmployeeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 765);
            this.Controls.Add(this.buttonToLogin);
            this.Controls.Add(this.listViewUsers);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonSearchUser);
            this.Controls.Add(this.labelDisplayUser);
            this.Controls.Add(this.textBoxSearchUser);
            this.Controls.Add(this.comboBoxSearchUser);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBoxUserInformation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listViewEmployees);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBoxEmployee);
            this.Name = "FormEmployeeUser";
            this.Text = "Employee User Management";
            this.groupBoxUserInformation.ResumeLayout(false);
            this.groupBoxUserInformation.PerformLayout();
            this.groupBoxEmployee.ResumeLayout(false);
            this.groupBoxEmployee.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonSearchUser;
        private System.Windows.Forms.Label labelDisplayUser;
        private System.Windows.Forms.TextBox textBoxSearchUser;
        private System.Windows.Forms.ComboBox comboBoxSearchUser;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBoxUserInformation;
        private System.Windows.Forms.Button buttonShowOrHide2;
        private System.Windows.Forms.TextBox textBoxReenterPassword;
        private System.Windows.Forms.Label labelPasswordConfirm;
        private System.Windows.Forms.Button buttonShowOrHide;
        private System.Windows.Forms.Button buttonClearUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonListUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.Button buttonUpdateUser;
        private System.Windows.Forms.Button buttonSaveUser;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listViewEmployees;
        private System.Windows.Forms.ColumnHeader columnHeaderEmployeeID;
        private System.Windows.Forms.ColumnHeader columnHeaderLastName;
        private System.Windows.Forms.ColumnHeader columnHeaderFirstName;
        private System.Windows.Forms.ColumnHeader columnHeaderPhoneNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderEmail;
        private System.Windows.Forms.ColumnHeader columnHeaderJobId;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxEmployee;
        private System.Windows.Forms.ComboBox comboBoxJobTitle;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmployeeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonToLogin;
    }
}