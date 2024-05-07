namespace CustomerProject.GUI
{
    partial class FormCustomer
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonListDB = new System.Windows.Forms.Button();
            this.dataGridViewDS = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxEmployee = new System.Windows.Forms.GroupBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.buttonUpdateDB = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCreditLimit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxContactName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPostalCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxProvince = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxContactEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxStreetName = new System.Windows.Forms.TextBox();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCustomerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonListDS = new System.Windows.Forms.Button();
            this.buttonToLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDS)).BeginInit();
            this.groupBoxEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonExit.Location = new System.Drawing.Point(1161, 242);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 46);
            this.buttonExit.TabIndex = 73;
            this.buttonExit.Tag = "";
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonListDB
            // 
            this.buttonListDB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListDB.Location = new System.Drawing.Point(977, 342);
            this.buttonListDB.Name = "buttonListDB";
            this.buttonListDB.Size = new System.Drawing.Size(186, 36);
            this.buttonListDB.TabIndex = 72;
            this.buttonListDB.Tag = "";
            this.buttonListDB.Text = "&List Customer From DB";
            this.buttonListDB.UseVisualStyleBackColor = false;
            this.buttonListDB.Click += new System.EventHandler(this.buttonListDB_Click);
            // 
            // dataGridViewDS
            // 
            this.dataGridViewDS.AllowUserToAddRows = false;
            this.dataGridViewDS.AllowUserToDeleteRows = false;
            this.dataGridViewDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDS.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewDS.Location = new System.Drawing.Point(41, 395);
            this.dataGridViewDS.Name = "dataGridViewDS";
            this.dataGridViewDS.RowHeadersWidth = 51;
            this.dataGridViewDS.RowTemplate.Height = 24;
            this.dataGridViewDS.Size = new System.Drawing.Size(1233, 283);
            this.dataGridViewDS.TabIndex = 70;
            this.dataGridViewDS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDS_CellContentClick);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Location = new System.Drawing.Point(827, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 28);
            this.label8.TabIndex = 69;
            this.label8.Text = "Please Select First";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearch.Location = new System.Drawing.Point(702, 174);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(163, 40);
            this.buttonSearch.TabIndex = 65;
            this.buttonSearch.Tag = "";
            this.buttonSearch.Text = "Search Customer";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelDisplay
            // 
            this.labelDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelDisplay.Location = new System.Drawing.Point(1005, 95);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(194, 28);
            this.labelDisplay.TabIndex = 67;
            this.labelDisplay.Text = "Message";
            this.labelDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearch.Location = new System.Drawing.Point(1035, 130);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(138, 22);
            this.textBoxSearch.TabIndex = 64;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Customer ID",
            "Customer Name"});
            this.comboBoxSearch.Location = new System.Drawing.Point(830, 126);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(149, 24);
            this.comboBoxSearch.TabIndex = 63;
            this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(702, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 30);
            this.label6.TabIndex = 68;
            this.label6.Text = "Search By";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxEmployee
            // 
            this.groupBoxEmployee.Controls.Add(this.comboBoxStatus);
            this.groupBoxEmployee.Controls.Add(this.buttonUpdateDB);
            this.groupBoxEmployee.Controls.Add(this.label14);
            this.groupBoxEmployee.Controls.Add(this.textBoxCreditLimit);
            this.groupBoxEmployee.Controls.Add(this.label13);
            this.groupBoxEmployee.Controls.Add(this.textBoxContactName);
            this.groupBoxEmployee.Controls.Add(this.label12);
            this.groupBoxEmployee.Controls.Add(this.textBoxPostalCode);
            this.groupBoxEmployee.Controls.Add(this.label11);
            this.groupBoxEmployee.Controls.Add(this.textBoxCity);
            this.groupBoxEmployee.Controls.Add(this.label10);
            this.groupBoxEmployee.Controls.Add(this.textBoxProvince);
            this.groupBoxEmployee.Controls.Add(this.label5);
            this.groupBoxEmployee.Controls.Add(this.buttonClear);
            this.groupBoxEmployee.Controls.Add(this.textBoxContactEmail);
            this.groupBoxEmployee.Controls.Add(this.label9);
            this.groupBoxEmployee.Controls.Add(this.textBoxPhoneNumber);
            this.groupBoxEmployee.Controls.Add(this.label7);
            this.groupBoxEmployee.Controls.Add(this.buttonDelete);
            this.groupBoxEmployee.Controls.Add(this.buttonUpdate);
            this.groupBoxEmployee.Controls.Add(this.buttonSave);
            this.groupBoxEmployee.Controls.Add(this.textBoxStreetName);
            this.groupBoxEmployee.Controls.Add(this.textBoxCustomerName);
            this.groupBoxEmployee.Controls.Add(this.label4);
            this.groupBoxEmployee.Controls.Add(this.label3);
            this.groupBoxEmployee.Controls.Add(this.label2);
            this.groupBoxEmployee.Controls.Add(this.textBoxCustomerID);
            this.groupBoxEmployee.Controls.Add(this.label1);
            this.groupBoxEmployee.Location = new System.Drawing.Point(132, 0);
            this.groupBoxEmployee.Name = "groupBoxEmployee";
            this.groupBoxEmployee.Size = new System.Drawing.Size(525, 381);
            this.groupBoxEmployee.TabIndex = 66;
            this.groupBoxEmployee.TabStop = false;
            this.groupBoxEmployee.Text = "Customer Information";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.comboBoxStatus.Location = new System.Drawing.Point(164, 354);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(138, 24);
            this.comboBoxStatus.TabIndex = 26;
            // 
            // buttonUpdateDB
            // 
            this.buttonUpdateDB.BackColor = System.Drawing.Color.Aqua;
            this.buttonUpdateDB.Location = new System.Drawing.Point(335, 318);
            this.buttonUpdateDB.Name = "buttonUpdateDB";
            this.buttonUpdateDB.Size = new System.Drawing.Size(150, 36);
            this.buttonUpdateDB.TabIndex = 25;
            this.buttonUpdateDB.Tag = "";
            this.buttonUpdateDB.Text = "&Update DB";
            this.buttonUpdateDB.UseVisualStyleBackColor = false;
            this.buttonUpdateDB.Click += new System.EventHandler(this.buttonUpdateDB_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(25, 356);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 22);
            this.label14.TabIndex = 24;
            this.label14.Text = "Status";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCreditLimit
            // 
            this.textBoxCreditLimit.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxCreditLimit.Location = new System.Drawing.Point(164, 325);
            this.textBoxCreditLimit.Name = "textBoxCreditLimit";
            this.textBoxCreditLimit.Size = new System.Drawing.Size(138, 22);
            this.textBoxCreditLimit.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(25, 266);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 22);
            this.label13.TabIndex = 22;
            this.label13.Text = "Contact Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxContactName
            // 
            this.textBoxContactName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxContactName.Location = new System.Drawing.Point(164, 266);
            this.textBoxContactName.Name = "textBoxContactName";
            this.textBoxContactName.Size = new System.Drawing.Size(138, 22);
            this.textBoxContactName.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(25, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 22);
            this.label12.TabIndex = 20;
            this.label12.Text = "Credit Limit";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPostalCode.Location = new System.Drawing.Point(164, 206);
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(138, 22);
            this.textBoxPostalCode.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(25, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Postal Code";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCity
            // 
            this.textBoxCity.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxCity.Location = new System.Drawing.Point(164, 174);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(138, 22);
            this.textBoxCity.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(25, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 22);
            this.label10.TabIndex = 16;
            this.label10.Text = "City";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProvince
            // 
            this.textBoxProvince.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxProvince.Location = new System.Drawing.Point(164, 145);
            this.textBoxProvince.Name = "textBoxProvince";
            this.textBoxProvince.Size = new System.Drawing.Size(138, 22);
            this.textBoxProvince.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Province";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Tan;
            this.buttonClear.Location = new System.Drawing.Point(335, 259);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(150, 36);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Tag = "";
            this.buttonClear.Text = "&Clear All";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxContactEmail
            // 
            this.textBoxContactEmail.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxContactEmail.Location = new System.Drawing.Point(164, 294);
            this.textBoxContactEmail.Name = "textBoxContactEmail";
            this.textBoxContactEmail.Size = new System.Drawing.Size(138, 22);
            this.textBoxContactEmail.TabIndex = 5;
            this.textBoxContactEmail.Text = "abc@abc.com";
            this.textBoxContactEmail.Enter += new System.EventHandler(this.textBoxContactEmail_Enter);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 22);
            this.label9.TabIndex = 12;
            this.label9.Text = "Contact Email";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(164, 235);
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
            this.label7.Location = new System.Drawing.Point(25, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Phone Number";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDelete.Location = new System.Drawing.Point(335, 199);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(150, 36);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Tag = "";
            this.buttonDelete.Text = "&Delete Customer";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdate.Location = new System.Drawing.Point(335, 130);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(150, 38);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Tag = "";
            this.buttonUpdate.Text = "&Update Customer";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSave.Location = new System.Drawing.Point(335, 69);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 36);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Tag = "";
            this.buttonSave.Text = "&Save Customer";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxStreetName
            // 
            this.textBoxStreetName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxStreetName.Location = new System.Drawing.Point(164, 113);
            this.textBoxStreetName.Name = "textBoxStreetName";
            this.textBoxStreetName.Size = new System.Drawing.Size(138, 22);
            this.textBoxStreetName.TabIndex = 3;
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxCustomerName.Location = new System.Drawing.Point(164, 83);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(138, 22);
            this.textBoxCustomerName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Street Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Customer Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(170, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "(6 digit number)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCustomerID
            // 
            this.textBoxCustomerID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxCustomerID.Location = new System.Drawing.Point(164, 29);
            this.textBoxCustomerID.Name = "textBoxCustomerID";
            this.textBoxCustomerID.Size = new System.Drawing.Size(138, 22);
            this.textBoxCustomerID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonListDS
            // 
            this.buttonListDS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListDS.Location = new System.Drawing.Point(717, 342);
            this.buttonListDS.Name = "buttonListDS";
            this.buttonListDS.Size = new System.Drawing.Size(186, 36);
            this.buttonListDS.TabIndex = 62;
            this.buttonListDS.Tag = "";
            this.buttonListDS.Text = "&List Customer From DS";
            this.buttonListDS.UseVisualStyleBackColor = false;
            this.buttonListDS.Click += new System.EventHandler(this.buttonListDS_Click);
            // 
            // buttonToLogin
            // 
            this.buttonToLogin.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonToLogin.Location = new System.Drawing.Point(1008, 242);
            this.buttonToLogin.Name = "buttonToLogin";
            this.buttonToLogin.Size = new System.Drawing.Size(128, 46);
            this.buttonToLogin.TabIndex = 76;
            this.buttonToLogin.Tag = "";
            this.buttonToLogin.Text = "Back To Login";
            this.buttonToLogin.UseVisualStyleBackColor = false;
            this.buttonToLogin.Click += new System.EventHandler(this.buttonToLogin_Click);
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 690);
            this.Controls.Add(this.buttonToLogin);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonListDB);
            this.Controls.Add(this.dataGridViewDS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBoxEmployee);
            this.Controls.Add(this.buttonListDS);
            this.Name = "FormCustomer";
            this.Text = "FormCustomer";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDS)).EndInit();
            this.groupBoxEmployee.ResumeLayout(false);
            this.groupBoxEmployee.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonListDB;
        private System.Windows.Forms.DataGridView dataGridViewDS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxEmployee;
        private System.Windows.Forms.Button buttonUpdateDB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCreditLimit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxContactName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPostalCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxProvince;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxContactEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxStreetName;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCustomerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonListDS;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Button buttonToLogin;
    }
}