namespace ProjectBook.GUI
{
    partial class FormBook
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
            this.buttonUpdateDBBook = new System.Windows.Forms.Button();
            this.buttonClearBook = new System.Windows.Forms.Button();
            this.buttonSaveBook = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxSearchBook = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxPublisher = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonListDSBook = new System.Windows.Forms.Button();
            this.buttonSearchBook = new System.Windows.Forms.Button();
            this.textBoxSearchBook = new System.Windows.Forms.TextBox();
            this.textBoxQOH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonDeleteBook = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonUpdateBook = new System.Windows.Forms.Button();
            this.textBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.textBoxBookTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxAuthorId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewDSBook = new System.Windows.Forms.DataGridView();
            this.groupBoxAuthor = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxSearchAuthor = new System.Windows.Forms.ComboBox();
            this.buttonSearchAuthor = new System.Windows.Forms.Button();
            this.textBoxSearchAuthor = new System.Windows.Forms.TextBox();
            this.buttonListDSAuthor = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonClearAuthor = new System.Windows.Forms.Button();
            this.buttonDeleteAuthor = new System.Windows.Forms.Button();
            this.buttonUpdateAuthor = new System.Windows.Forms.Button();
            this.buttonSaveAuthor = new System.Windows.Forms.Button();
            this.dataGridViewDSAuthor = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSBook)).BeginInit();
            this.groupBoxAuthor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSAuthor)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUpdateDBBook
            // 
            this.buttonUpdateDBBook.BackColor = System.Drawing.Color.Aqua;
            this.buttonUpdateDBBook.Location = new System.Drawing.Point(724, 281);
            this.buttonUpdateDBBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateDBBook.Name = "buttonUpdateDBBook";
            this.buttonUpdateDBBook.Size = new System.Drawing.Size(149, 36);
            this.buttonUpdateDBBook.TabIndex = 25;
            this.buttonUpdateDBBook.Tag = "";
            this.buttonUpdateDBBook.Text = "&Update DB";
            this.buttonUpdateDBBook.UseVisualStyleBackColor = false;
            this.buttonUpdateDBBook.Click += new System.EventHandler(this.buttonUpdateDBBook_Click);
            // 
            // buttonClearBook
            // 
            this.buttonClearBook.BackColor = System.Drawing.Color.Tan;
            this.buttonClearBook.Location = new System.Drawing.Point(356, 208);
            this.buttonClearBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClearBook.Name = "buttonClearBook";
            this.buttonClearBook.Size = new System.Drawing.Size(149, 36);
            this.buttonClearBook.TabIndex = 11;
            this.buttonClearBook.Tag = "";
            this.buttonClearBook.Text = "&Clear All";
            this.buttonClearBook.UseVisualStyleBackColor = false;
            this.buttonClearBook.Click += new System.EventHandler(this.buttonClearBook_Click);
            // 
            // buttonSaveBook
            // 
            this.buttonSaveBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSaveBook.Location = new System.Drawing.Point(356, 31);
            this.buttonSaveBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveBook.Name = "buttonSaveBook";
            this.buttonSaveBook.Size = new System.Drawing.Size(149, 36);
            this.buttonSaveBook.TabIndex = 7;
            this.buttonSaveBook.Tag = "";
            this.buttonSaveBook.Text = "&Save Book";
            this.buttonSaveBook.UseVisualStyleBackColor = false;
            this.buttonSaveBook.Click += new System.EventHandler(this.buttonSaveBook_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(131, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Max 15 characters)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxISBN.Location = new System.Drawing.Point(173, 30);
            this.textBoxISBN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(137, 22);
            this.textBoxISBN.TabIndex = 1;
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
            this.label1.Text = "ISBN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.Controls.Add(this.label8);
            this.groupBoxBook.Controls.Add(this.comboBoxSearchBook);
            this.groupBoxBook.Controls.Add(this.comboBoxCategory);
            this.groupBoxBook.Controls.Add(this.comboBoxPublisher);
            this.groupBoxBook.Controls.Add(this.comboBoxStatus);
            this.groupBoxBook.Controls.Add(this.label15);
            this.groupBoxBook.Controls.Add(this.label12);
            this.groupBoxBook.Controls.Add(this.buttonListDSBook);
            this.groupBoxBook.Controls.Add(this.buttonSearchBook);
            this.groupBoxBook.Controls.Add(this.textBoxSearchBook);
            this.groupBoxBook.Controls.Add(this.textBoxQOH);
            this.groupBoxBook.Controls.Add(this.label5);
            this.groupBoxBook.Controls.Add(this.buttonClearBook);
            this.groupBoxBook.Controls.Add(this.label9);
            this.groupBoxBook.Controls.Add(this.buttonDeleteBook);
            this.groupBoxBook.Controls.Add(this.label6);
            this.groupBoxBook.Controls.Add(this.buttonUpdateBook);
            this.groupBoxBook.Controls.Add(this.buttonSaveBook);
            this.groupBoxBook.Controls.Add(this.textBoxUnitPrice);
            this.groupBoxBook.Controls.Add(this.textBoxBookTitle);
            this.groupBoxBook.Controls.Add(this.label4);
            this.groupBoxBook.Controls.Add(this.label3);
            this.groupBoxBook.Controls.Add(this.label2);
            this.groupBoxBook.Controls.Add(this.textBoxISBN);
            this.groupBoxBook.Controls.Add(this.label1);
            this.groupBoxBook.Location = new System.Drawing.Point(56, 73);
            this.groupBoxBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxBook.Size = new System.Drawing.Size(626, 539);
            this.groupBoxBook.TabIndex = 67;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "Book Information";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label8.Location = new System.Drawing.Point(162, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 34);
            this.label8.TabIndex = 86;
            this.label8.Text = "Select first";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSearchBook
            // 
            this.comboBoxSearchBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBook.FormattingEnabled = true;
            this.comboBoxSearchBook.Items.AddRange(new object[] {
            "ISBN",
            "Book Title",
            "Unit Price",
            "Quantity On Hand"});
            this.comboBoxSearchBook.Location = new System.Drawing.Point(173, 435);
            this.comboBoxSearchBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSearchBook.Name = "comboBoxSearchBook";
            this.comboBoxSearchBook.Size = new System.Drawing.Size(149, 24);
            this.comboBoxSearchBook.TabIndex = 85;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(173, 293);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(149, 24);
            this.comboBoxCategory.TabIndex = 84;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // comboBoxPublisher
            // 
            this.comboBoxPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPublisher.FormattingEnabled = true;
            this.comboBoxPublisher.Location = new System.Drawing.Point(173, 246);
            this.comboBoxPublisher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPublisher.Name = "comboBoxPublisher";
            this.comboBoxPublisher.Size = new System.Drawing.Size(149, 24);
            this.comboBoxPublisher.TabIndex = 83;
            this.comboBoxPublisher.SelectedIndexChanged += new System.EventHandler(this.comboBoxPublisher_SelectedIndexChanged);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "In Stock",
            "Out of Stock",
            "New Arrival",
            "Bestseller"});
            this.comboBoxStatus.Location = new System.Drawing.Point(173, 344);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(149, 24);
            this.comboBoxStatus.TabIndex = 82;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(25, 346);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 22);
            this.label15.TabIndex = 81;
            this.label15.Text = "Status";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(25, 295);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 22);
            this.label12.TabIndex = 27;
            this.label12.Text = "Category";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonListDSBook
            // 
            this.buttonListDSBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListDSBook.Location = new System.Drawing.Point(356, 281);
            this.buttonListDSBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonListDSBook.Name = "buttonListDSBook";
            this.buttonListDSBook.Size = new System.Drawing.Size(187, 36);
            this.buttonListDSBook.TabIndex = 74;
            this.buttonListDSBook.Tag = "";
            this.buttonListDSBook.Text = "&List Book";
            this.buttonListDSBook.UseVisualStyleBackColor = false;
            this.buttonListDSBook.Click += new System.EventHandler(this.buttonListDSBook_Click);
            // 
            // buttonSearchBook
            // 
            this.buttonSearchBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearchBook.Location = new System.Drawing.Point(380, 486);
            this.buttonSearchBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearchBook.Name = "buttonSearchBook";
            this.buttonSearchBook.Size = new System.Drawing.Size(163, 39);
            this.buttonSearchBook.TabIndex = 77;
            this.buttonSearchBook.Tag = "";
            this.buttonSearchBook.Text = "Search Book";
            this.buttonSearchBook.UseVisualStyleBackColor = false;
            this.buttonSearchBook.Click += new System.EventHandler(this.buttonSearchBook_Click);
            // 
            // textBoxSearchBook
            // 
            this.textBoxSearchBook.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearchBook.Location = new System.Drawing.Point(356, 435);
            this.textBoxSearchBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearchBook.Name = "textBoxSearchBook";
            this.textBoxSearchBook.Size = new System.Drawing.Size(190, 22);
            this.textBoxSearchBook.TabIndex = 76;
            // 
            // textBoxQOH
            // 
            this.textBoxQOH.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxQOH.Location = new System.Drawing.Point(173, 197);
            this.textBoxQOH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxQOH.Name = "textBoxQOH";
            this.textBoxQOH.Size = new System.Drawing.Size(137, 22);
            this.textBoxQOH.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 40);
            this.label5.TabIndex = 14;
            this.label5.Text = "Quantity On Hand";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 22);
            this.label9.TabIndex = 12;
            this.label9.Text = "Publisher";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteBook
            // 
            this.buttonDeleteBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDeleteBook.Location = new System.Drawing.Point(356, 142);
            this.buttonDeleteBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteBook.Name = "buttonDeleteBook";
            this.buttonDeleteBook.Size = new System.Drawing.Size(149, 36);
            this.buttonDeleteBook.TabIndex = 9;
            this.buttonDeleteBook.Tag = "";
            this.buttonDeleteBook.Text = "&Delete Book";
            this.buttonDeleteBook.UseVisualStyleBackColor = false;
            this.buttonDeleteBook.Click += new System.EventHandler(this.buttonDeleteBook_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(25, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 30);
            this.label6.TabIndex = 79;
            this.label6.Text = "Search By";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUpdateBook
            // 
            this.buttonUpdateBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateBook.Location = new System.Drawing.Point(356, 82);
            this.buttonUpdateBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateBook.Name = "buttonUpdateBook";
            this.buttonUpdateBook.Size = new System.Drawing.Size(149, 38);
            this.buttonUpdateBook.TabIndex = 8;
            this.buttonUpdateBook.Tag = "";
            this.buttonUpdateBook.Text = "&Update Book";
            this.buttonUpdateBook.UseVisualStyleBackColor = false;
            this.buttonUpdateBook.Click += new System.EventHandler(this.buttonUpdateBook_Click);
            // 
            // textBoxUnitPrice
            // 
            this.textBoxUnitPrice.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxUnitPrice.Location = new System.Drawing.Point(173, 149);
            this.textBoxUnitPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUnitPrice.Name = "textBoxUnitPrice";
            this.textBoxUnitPrice.Size = new System.Drawing.Size(137, 22);
            this.textBoxUnitPrice.TabIndex = 3;
            // 
            // textBoxBookTitle
            // 
            this.textBoxBookTitle.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxBookTitle.Location = new System.Drawing.Point(173, 113);
            this.textBoxBookTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBookTitle.Name = "textBoxBookTitle";
            this.textBoxBookTitle.Size = new System.Drawing.Size(137, 22);
            this.textBoxBookTitle.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Unit Price";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Book Title";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(29, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 22);
            this.label13.TabIndex = 22;
            this.label13.Text = "Author Email";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxEmail.Location = new System.Drawing.Point(177, 262);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(137, 22);
            this.textBoxEmail.TabIndex = 19;
            this.textBoxEmail.Text = "abc@abc.com";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxFirstName.Location = new System.Drawing.Point(177, 113);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(137, 22);
            this.textBoxFirstName.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(29, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Author First Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAuthorId
            // 
            this.textBoxAuthorId.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxAuthorId.Location = new System.Drawing.Point(177, 46);
            this.textBoxAuthorId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAuthorId.Name = "textBoxAuthorId";
            this.textBoxAuthorId.Size = new System.Drawing.Size(137, 22);
            this.textBoxAuthorId.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(29, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 22);
            this.label10.TabIndex = 16;
            this.label10.Text = "Author ID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxLastName.Location = new System.Drawing.Point(177, 181);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(137, 22);
            this.textBoxLastName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(29, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Author Last Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewDSBook
            // 
            this.dataGridViewDSBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSBook.Location = new System.Drawing.Point(56, 630);
            this.dataGridViewDSBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDSBook.Name = "dataGridViewDSBook";
            this.dataGridViewDSBook.ReadOnly = true;
            this.dataGridViewDSBook.RowHeadersWidth = 51;
            this.dataGridViewDSBook.RowTemplate.Height = 24;
            this.dataGridViewDSBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDSBook.Size = new System.Drawing.Size(626, 231);
            this.dataGridViewDSBook.TabIndex = 81;
            this.dataGridViewDSBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSBook_CellClick);
            // 
            // groupBoxAuthor
            // 
            this.groupBoxAuthor.Controls.Add(this.label14);
            this.groupBoxAuthor.Controls.Add(this.comboBoxSearchAuthor);
            this.groupBoxAuthor.Controls.Add(this.buttonSearchAuthor);
            this.groupBoxAuthor.Controls.Add(this.textBoxSearchAuthor);
            this.groupBoxAuthor.Controls.Add(this.buttonListDSAuthor);
            this.groupBoxAuthor.Controls.Add(this.label16);
            this.groupBoxAuthor.Controls.Add(this.buttonClearAuthor);
            this.groupBoxAuthor.Controls.Add(this.buttonDeleteAuthor);
            this.groupBoxAuthor.Controls.Add(this.buttonUpdateAuthor);
            this.groupBoxAuthor.Controls.Add(this.buttonSaveAuthor);
            this.groupBoxAuthor.Controls.Add(this.label10);
            this.groupBoxAuthor.Controls.Add(this.label7);
            this.groupBoxAuthor.Controls.Add(this.textBoxLastName);
            this.groupBoxAuthor.Controls.Add(this.textBoxAuthorId);
            this.groupBoxAuthor.Controls.Add(this.label13);
            this.groupBoxAuthor.Controls.Add(this.label11);
            this.groupBoxAuthor.Controls.Add(this.textBoxEmail);
            this.groupBoxAuthor.Controls.Add(this.textBoxFirstName);
            this.groupBoxAuthor.Location = new System.Drawing.Point(900, 73);
            this.groupBoxAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAuthor.Name = "groupBoxAuthor";
            this.groupBoxAuthor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAuthor.Size = new System.Drawing.Size(634, 539);
            this.groupBoxAuthor.TabIndex = 83;
            this.groupBoxAuthor.TabStop = false;
            this.groupBoxAuthor.Text = "Author Information";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label14.Location = new System.Drawing.Point(158, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(179, 34);
            this.label14.TabIndex = 87;
            this.label14.Text = "Select first";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSearchAuthor
            // 
            this.comboBoxSearchAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchAuthor.FormattingEnabled = true;
            this.comboBoxSearchAuthor.Items.AddRange(new object[] {
            "Author ID",
            "First Name",
            "Last Name",
            "Email"});
            this.comboBoxSearchAuthor.Location = new System.Drawing.Point(177, 409);
            this.comboBoxSearchAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSearchAuthor.Name = "comboBoxSearchAuthor";
            this.comboBoxSearchAuthor.Size = new System.Drawing.Size(149, 24);
            this.comboBoxSearchAuthor.TabIndex = 86;
            // 
            // buttonSearchAuthor
            // 
            this.buttonSearchAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearchAuthor.Location = new System.Drawing.Point(379, 465);
            this.buttonSearchAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearchAuthor.Name = "buttonSearchAuthor";
            this.buttonSearchAuthor.Size = new System.Drawing.Size(163, 39);
            this.buttonSearchAuthor.TabIndex = 83;
            this.buttonSearchAuthor.Tag = "";
            this.buttonSearchAuthor.Text = "Search Author";
            this.buttonSearchAuthor.UseVisualStyleBackColor = false;
            this.buttonSearchAuthor.Click += new System.EventHandler(this.buttonSearchAuthor_Click);
            // 
            // textBoxSearchAuthor
            // 
            this.textBoxSearchAuthor.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearchAuthor.Location = new System.Drawing.Point(368, 411);
            this.textBoxSearchAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearchAuthor.Name = "textBoxSearchAuthor";
            this.textBoxSearchAuthor.Size = new System.Drawing.Size(184, 22);
            this.textBoxSearchAuthor.TabIndex = 82;
            // 
            // buttonListDSAuthor
            // 
            this.buttonListDSAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListDSAuthor.Location = new System.Drawing.Point(379, 255);
            this.buttonListDSAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonListDSAuthor.Name = "buttonListDSAuthor";
            this.buttonListDSAuthor.Size = new System.Drawing.Size(149, 36);
            this.buttonListDSAuthor.TabIndex = 86;
            this.buttonListDSAuthor.Tag = "";
            this.buttonListDSAuthor.Text = "&List Author";
            this.buttonListDSAuthor.UseVisualStyleBackColor = false;
            this.buttonListDSAuthor.Click += new System.EventHandler(this.buttonListDSAuthor_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(15, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 30);
            this.label16.TabIndex = 85;
            this.label16.Text = "Search By";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClearAuthor
            // 
            this.buttonClearAuthor.BackColor = System.Drawing.Color.Tan;
            this.buttonClearAuthor.Location = new System.Drawing.Point(379, 190);
            this.buttonClearAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClearAuthor.Name = "buttonClearAuthor";
            this.buttonClearAuthor.Size = new System.Drawing.Size(149, 36);
            this.buttonClearAuthor.TabIndex = 29;
            this.buttonClearAuthor.Tag = "";
            this.buttonClearAuthor.Text = "&Clear All";
            this.buttonClearAuthor.UseVisualStyleBackColor = false;
            this.buttonClearAuthor.Click += new System.EventHandler(this.buttonClearAuthor_Click);
            // 
            // buttonDeleteAuthor
            // 
            this.buttonDeleteAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDeleteAuthor.Location = new System.Drawing.Point(379, 126);
            this.buttonDeleteAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteAuthor.Name = "buttonDeleteAuthor";
            this.buttonDeleteAuthor.Size = new System.Drawing.Size(149, 36);
            this.buttonDeleteAuthor.TabIndex = 28;
            this.buttonDeleteAuthor.Tag = "";
            this.buttonDeleteAuthor.Text = "&Delete Author";
            this.buttonDeleteAuthor.UseVisualStyleBackColor = false;
            this.buttonDeleteAuthor.Click += new System.EventHandler(this.buttonDeleteAuthor_Click);
            // 
            // buttonUpdateAuthor
            // 
            this.buttonUpdateAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateAuthor.Location = new System.Drawing.Point(379, 75);
            this.buttonUpdateAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateAuthor.Name = "buttonUpdateAuthor";
            this.buttonUpdateAuthor.Size = new System.Drawing.Size(149, 38);
            this.buttonUpdateAuthor.TabIndex = 27;
            this.buttonUpdateAuthor.Tag = "";
            this.buttonUpdateAuthor.Text = "&Update Author";
            this.buttonUpdateAuthor.UseVisualStyleBackColor = false;
            this.buttonUpdateAuthor.Click += new System.EventHandler(this.buttonUpdateAuthor_Click);
            // 
            // buttonSaveAuthor
            // 
            this.buttonSaveAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSaveAuthor.Location = new System.Drawing.Point(379, 25);
            this.buttonSaveAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveAuthor.Name = "buttonSaveAuthor";
            this.buttonSaveAuthor.Size = new System.Drawing.Size(149, 36);
            this.buttonSaveAuthor.TabIndex = 26;
            this.buttonSaveAuthor.Tag = "";
            this.buttonSaveAuthor.Text = "&Save Author";
            this.buttonSaveAuthor.UseVisualStyleBackColor = false;
            this.buttonSaveAuthor.Click += new System.EventHandler(this.buttonSaveAuthor_Click);
            // 
            // dataGridViewDSAuthor
            // 
            this.dataGridViewDSAuthor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSAuthor.Location = new System.Drawing.Point(900, 630);
            this.dataGridViewDSAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDSAuthor.Name = "dataGridViewDSAuthor";
            this.dataGridViewDSAuthor.ReadOnly = true;
            this.dataGridViewDSAuthor.RowHeadersWidth = 51;
            this.dataGridViewDSAuthor.RowTemplate.Height = 24;
            this.dataGridViewDSAuthor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDSAuthor.Size = new System.Drawing.Size(634, 231);
            this.dataGridViewDSAuthor.TabIndex = 87;
            this.dataGridViewDSAuthor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSAuthor_CellClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1700, 24);
            this.menuStrip1.TabIndex = 90;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1700, 24);
            this.menuStrip2.TabIndex = 91;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonClose.Location = new System.Drawing.Point(1562, 888);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(113, 58);
            this.buttonClose.TabIndex = 97;
            this.buttonClose.Tag = "";
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 973);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonUpdateDBBook);
            this.Controls.Add(this.dataGridViewDSAuthor);
            this.Controls.Add(this.groupBoxAuthor);
            this.Controls.Add(this.dataGridViewDSBook);
            this.Controls.Add(this.groupBoxBook);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBook";
            this.Text = "Book And Author Management";
            this.Load += new System.EventHandler(this.FormBook_Load);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSBook)).EndInit();
            this.groupBoxAuthor.ResumeLayout(false);
            this.groupBoxAuthor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSAuthor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdateDBBook;
        private System.Windows.Forms.Button buttonClearBook;
        private System.Windows.Forms.Button buttonSaveBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAuthorId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxQOH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonDeleteBook;
        private System.Windows.Forms.Button buttonUpdateBook;
        private System.Windows.Forms.TextBox textBoxUnitPrice;
        private System.Windows.Forms.TextBox textBoxBookTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewDSBook;
        private System.Windows.Forms.Button buttonSearchBook;
        private System.Windows.Forms.TextBox textBoxSearchBook;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonListDSBook;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBoxAuthor;
        private System.Windows.Forms.Button buttonClearAuthor;
        private System.Windows.Forms.Button buttonDeleteAuthor;
        private System.Windows.Forms.Button buttonUpdateAuthor;
        private System.Windows.Forms.Button buttonSaveAuthor;
        private System.Windows.Forms.Button buttonSearchAuthor;
        private System.Windows.Forms.TextBox textBoxSearchAuthor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataGridViewDSAuthor;
        private System.Windows.Forms.Button buttonListDSAuthor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxPublisher;
        private System.Windows.Forms.ComboBox comboBoxSearchBook;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxSearchAuthor;
    }
}