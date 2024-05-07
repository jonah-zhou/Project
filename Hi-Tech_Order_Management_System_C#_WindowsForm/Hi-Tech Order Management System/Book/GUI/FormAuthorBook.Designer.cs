namespace ProjectBook.GUI
{
    partial class FormAuthorBook
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
            this.groupBoxAuthorBook = new System.Windows.Forms.GroupBox();
            this.comboBoxSearchOption = new System.Windows.Forms.ComboBox();
            this.buttonGetAuthor = new System.Windows.Forms.Button();
            this.buttonGetBook = new System.Windows.Forms.Button();
            this.comboBoxAuthor = new System.Windows.Forms.ComboBox();
            this.comboBoxBook = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdateDB = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxYearPublished = new System.Windows.Forms.TextBox();
            this.buttonListDSAuthorBook = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.buttonDeleteAuthorBook = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxEdition = new System.Windows.Forms.TextBox();
            this.buttonUpdateAuthorBook = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonSaveAuthorBook = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelInformation = new System.Windows.Forms.Label();
            this.dataGridViewInformation = new System.Windows.Forms.DataGridView();
            this.dataGridViewDSAuthorBook = new System.Windows.Forms.DataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxAuthorBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSAuthorBook)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAuthorBook
            // 
            this.groupBoxAuthorBook.Controls.Add(this.comboBoxSearchOption);
            this.groupBoxAuthorBook.Controls.Add(this.buttonGetAuthor);
            this.groupBoxAuthorBook.Controls.Add(this.buttonGetBook);
            this.groupBoxAuthorBook.Controls.Add(this.comboBoxAuthor);
            this.groupBoxAuthorBook.Controls.Add(this.comboBoxBook);
            this.groupBoxAuthorBook.Controls.Add(this.buttonSearch);
            this.groupBoxAuthorBook.Controls.Add(this.buttonUpdateDB);
            this.groupBoxAuthorBook.Controls.Add(this.label20);
            this.groupBoxAuthorBook.Controls.Add(this.textBoxYearPublished);
            this.groupBoxAuthorBook.Controls.Add(this.buttonListDSAuthorBook);
            this.groupBoxAuthorBook.Controls.Add(this.textBoxSearch);
            this.groupBoxAuthorBook.Controls.Add(this.buttonClear);
            this.groupBoxAuthorBook.Controls.Add(this.labelDisplay);
            this.groupBoxAuthorBook.Controls.Add(this.label19);
            this.groupBoxAuthorBook.Controls.Add(this.comboBoxSearch);
            this.groupBoxAuthorBook.Controls.Add(this.buttonDeleteAuthorBook);
            this.groupBoxAuthorBook.Controls.Add(this.label22);
            this.groupBoxAuthorBook.Controls.Add(this.textBoxEdition);
            this.groupBoxAuthorBook.Controls.Add(this.buttonUpdateAuthorBook);
            this.groupBoxAuthorBook.Controls.Add(this.label18);
            this.groupBoxAuthorBook.Controls.Add(this.buttonSaveAuthorBook);
            this.groupBoxAuthorBook.Controls.Add(this.label17);
            this.groupBoxAuthorBook.Controls.Add(this.label15);
            this.groupBoxAuthorBook.Location = new System.Drawing.Point(109, 68);
            this.groupBoxAuthorBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAuthorBook.Name = "groupBoxAuthorBook";
            this.groupBoxAuthorBook.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAuthorBook.Size = new System.Drawing.Size(917, 315);
            this.groupBoxAuthorBook.TabIndex = 87;
            this.groupBoxAuthorBook.TabStop = false;
            this.groupBoxAuthorBook.Text = "Year Publish and Edition";
            // 
            // comboBoxSearchOption
            // 
            this.comboBoxSearchOption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchOption.FormattingEnabled = true;
            this.comboBoxSearchOption.Location = new System.Drawing.Point(348, 251);
            this.comboBoxSearchOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSearchOption.Name = "comboBoxSearchOption";
            this.comboBoxSearchOption.Size = new System.Drawing.Size(184, 24);
            this.comboBoxSearchOption.TabIndex = 99;
            // 
            // buttonGetAuthor
            // 
            this.buttonGetAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonGetAuthor.Location = new System.Drawing.Point(404, 70);
            this.buttonGetAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetAuthor.Name = "buttonGetAuthor";
            this.buttonGetAuthor.Size = new System.Drawing.Size(49, 31);
            this.buttonGetAuthor.TabIndex = 98;
            this.buttonGetAuthor.Tag = "";
            this.buttonGetAuthor.Text = "Get";
            this.buttonGetAuthor.UseVisualStyleBackColor = false;
            this.buttonGetAuthor.Click += new System.EventHandler(this.buttonGetAuthor_Click);
            // 
            // buttonGetBook
            // 
            this.buttonGetBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonGetBook.Location = new System.Drawing.Point(404, 30);
            this.buttonGetBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetBook.Name = "buttonGetBook";
            this.buttonGetBook.Size = new System.Drawing.Size(49, 31);
            this.buttonGetBook.TabIndex = 97;
            this.buttonGetBook.Tag = "";
            this.buttonGetBook.Text = "Get";
            this.buttonGetBook.UseVisualStyleBackColor = false;
            this.buttonGetBook.Click += new System.EventHandler(this.buttonGetBook_Click);
            // 
            // comboBoxAuthor
            // 
            this.comboBoxAuthor.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthor.FormattingEnabled = true;
            this.comboBoxAuthor.Location = new System.Drawing.Point(177, 70);
            this.comboBoxAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAuthor.Name = "comboBoxAuthor";
            this.comboBoxAuthor.Size = new System.Drawing.Size(199, 24);
            this.comboBoxAuthor.TabIndex = 96;
            this.comboBoxAuthor.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthor_SelectedIndexChanged);
            // 
            // comboBoxBook
            // 
            this.comboBoxBook.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBook.FormattingEnabled = true;
            this.comboBoxBook.Location = new System.Drawing.Point(177, 34);
            this.comboBoxBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxBook.Name = "comboBoxBook";
            this.comboBoxBook.Size = new System.Drawing.Size(199, 24);
            this.comboBoxBook.TabIndex = 95;
            this.comboBoxBook.SelectedIndexChanged += new System.EventHandler(this.comboBoxBook_SelectedIndexChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearch.Location = new System.Drawing.Point(564, 241);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(163, 39);
            this.buttonSearch.TabIndex = 89;
            this.buttonSearch.Tag = "";
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonUpdateDB
            // 
            this.buttonUpdateDB.BackColor = System.Drawing.Color.Aqua;
            this.buttonUpdateDB.Location = new System.Drawing.Point(746, 93);
            this.buttonUpdateDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateDB.Name = "buttonUpdateDB";
            this.buttonUpdateDB.Size = new System.Drawing.Size(149, 36);
            this.buttonUpdateDB.TabIndex = 91;
            this.buttonUpdateDB.Tag = "";
            this.buttonUpdateDB.Text = "&Update DB";
            this.buttonUpdateDB.UseVisualStyleBackColor = false;
            this.buttonUpdateDB.Click += new System.EventHandler(this.buttonUpdateDB_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label20.Location = new System.Drawing.Point(173, 212);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 28);
            this.label20.TabIndex = 92;
            this.label20.Text = "Please Select First";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxYearPublished
            // 
            this.textBoxYearPublished.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxYearPublished.Location = new System.Drawing.Point(177, 107);
            this.textBoxYearPublished.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxYearPublished.Name = "textBoxYearPublished";
            this.textBoxYearPublished.Size = new System.Drawing.Size(137, 22);
            this.textBoxYearPublished.TabIndex = 94;
            // 
            // buttonListDSAuthorBook
            // 
            this.buttonListDSAuthorBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListDSAuthorBook.Location = new System.Drawing.Point(746, 148);
            this.buttonListDSAuthorBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonListDSAuthorBook.Name = "buttonListDSAuthorBook";
            this.buttonListDSAuthorBook.Size = new System.Drawing.Size(137, 36);
            this.buttonListDSAuthorBook.TabIndex = 90;
            this.buttonListDSAuthorBook.Tag = "";
            this.buttonListDSAuthorBook.Text = "&List All";
            this.buttonListDSAuthorBook.UseVisualStyleBackColor = false;
            this.buttonListDSAuthorBook.Click += new System.EventHandler(this.buttonListDSAuthorBook_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearch.Location = new System.Drawing.Point(348, 251);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(184, 22);
            this.textBoxSearch.TabIndex = 88;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Tan;
            this.buttonClear.Location = new System.Drawing.Point(746, 34);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(149, 36);
            this.buttonClear.TabIndex = 90;
            this.buttonClear.Tag = "";
            this.buttonClear.Text = "&Clear All";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelDisplay
            // 
            this.labelDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelDisplay.Location = new System.Drawing.Point(345, 212);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(195, 28);
            this.labelDisplay.TabIndex = 90;
            this.labelDisplay.Text = "Message";
            this.labelDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(29, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 22);
            this.label19.TabIndex = 93;
            this.label19.Text = "Year Published";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Book Title",
            "Author First Name",
            "Year Published",
            "Edition"});
            this.comboBoxSearch.Location = new System.Drawing.Point(165, 250);
            this.comboBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(149, 24);
            this.comboBoxSearch.TabIndex = 87;
            this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged);
            // 
            // buttonDeleteAuthorBook
            // 
            this.buttonDeleteAuthorBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDeleteAuthorBook.Location = new System.Drawing.Point(561, 148);
            this.buttonDeleteAuthorBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteAuthorBook.Name = "buttonDeleteAuthorBook";
            this.buttonDeleteAuthorBook.Size = new System.Drawing.Size(149, 36);
            this.buttonDeleteAuthorBook.TabIndex = 89;
            this.buttonDeleteAuthorBook.Tag = "";
            this.buttonDeleteAuthorBook.Text = "&Delete";
            this.buttonDeleteAuthorBook.UseVisualStyleBackColor = false;
            this.buttonDeleteAuthorBook.Click += new System.EventHandler(this.buttonDeleteAuthorBook_Click);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(40, 241);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 30);
            this.label22.TabIndex = 91;
            this.label22.Text = "Search By";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEdition
            // 
            this.textBoxEdition.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxEdition.Location = new System.Drawing.Point(177, 148);
            this.textBoxEdition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEdition.Name = "textBoxEdition";
            this.textBoxEdition.Size = new System.Drawing.Size(137, 22);
            this.textBoxEdition.TabIndex = 92;
            // 
            // buttonUpdateAuthorBook
            // 
            this.buttonUpdateAuthorBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateAuthorBook.Location = new System.Drawing.Point(564, 82);
            this.buttonUpdateAuthorBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateAuthorBook.Name = "buttonUpdateAuthorBook";
            this.buttonUpdateAuthorBook.Size = new System.Drawing.Size(149, 38);
            this.buttonUpdateAuthorBook.TabIndex = 88;
            this.buttonUpdateAuthorBook.Tag = "";
            this.buttonUpdateAuthorBook.Text = "&Update";
            this.buttonUpdateAuthorBook.UseVisualStyleBackColor = false;
            this.buttonUpdateAuthorBook.Click += new System.EventHandler(this.buttonUpdateAuthorBook_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(29, 148);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 22);
            this.label18.TabIndex = 91;
            this.label18.Text = "Edition";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSaveAuthorBook
            // 
            this.buttonSaveAuthorBook.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSaveAuthorBook.Location = new System.Drawing.Point(564, 30);
            this.buttonSaveAuthorBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveAuthorBook.Name = "buttonSaveAuthorBook";
            this.buttonSaveAuthorBook.Size = new System.Drawing.Size(149, 36);
            this.buttonSaveAuthorBook.TabIndex = 87;
            this.buttonSaveAuthorBook.Tag = "";
            this.buttonSaveAuthorBook.Text = "&Save";
            this.buttonSaveAuthorBook.UseVisualStyleBackColor = false;
            this.buttonSaveAuthorBook.Click += new System.EventHandler(this.buttonSaveAuthorBook_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(29, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 22);
            this.label17.TabIndex = 89;
            this.label17.Text = "Book";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(29, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 22);
            this.label15.TabIndex = 88;
            this.label15.Text = "Author";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1147, 24);
            this.menuStrip1.TabIndex = 88;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonClose.Location = new System.Drawing.Point(879, 457);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(113, 58);
            this.buttonClose.TabIndex = 96;
            this.buttonClose.Tag = "";
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelInformation.Location = new System.Drawing.Point(255, 418);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(394, 28);
            this.labelInformation.TabIndex = 100;
            this.labelInformation.Text = "Result Search";
            this.labelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewInformation
            // 
            this.dataGridViewInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInformation.Enabled = false;
            this.dataGridViewInformation.Location = new System.Drawing.Point(122, 457);
            this.dataGridViewInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInformation.Name = "dataGridViewInformation";
            this.dataGridViewInformation.ReadOnly = true;
            this.dataGridViewInformation.RowHeadersWidth = 51;
            this.dataGridViewInformation.RowTemplate.Height = 24;
            this.dataGridViewInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInformation.Size = new System.Drawing.Size(648, 156);
            this.dataGridViewInformation.TabIndex = 99;
            // 
            // dataGridViewDSAuthorBook
            // 
            this.dataGridViewDSAuthorBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDSAuthorBook.Location = new System.Drawing.Point(122, 457);
            this.dataGridViewDSAuthorBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDSAuthorBook.Name = "dataGridViewDSAuthorBook";
            this.dataGridViewDSAuthorBook.ReadOnly = true;
            this.dataGridViewDSAuthorBook.RowHeadersWidth = 51;
            this.dataGridViewDSAuthorBook.RowTemplate.Height = 24;
            this.dataGridViewDSAuthorBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDSAuthorBook.Size = new System.Drawing.Size(648, 156);
            this.dataGridViewDSAuthorBook.TabIndex = 91;
            this.dataGridViewDSAuthorBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDSAuthorBook_CellClick);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonExit.Location = new System.Drawing.Point(879, 555);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 58);
            this.buttonExit.TabIndex = 101;
            this.buttonExit.Tag = "";
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormAuthorBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 653);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.dataGridViewInformation);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewDSAuthorBook);
            this.Controls.Add(this.groupBoxAuthorBook);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAuthorBook";
            this.Text = "Book Edition Management";
            this.Load += new System.EventHandler(this.FormAuthorBook_Load);
            this.groupBoxAuthorBook.ResumeLayout(false);
            this.groupBoxAuthorBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDSAuthorBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAuthorBook;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonUpdateDB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxYearPublished;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Button buttonDeleteAuthorBook;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxEdition;
        private System.Windows.Forms.Button buttonUpdateAuthorBook;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonSaveAuthorBook;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonListDSAuthorBook;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxAuthor;
        private System.Windows.Forms.ComboBox comboBoxBook;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.DataGridView dataGridViewInformation;
        private System.Windows.Forms.Button buttonGetAuthor;
        private System.Windows.Forms.Button buttonGetBook;
        private System.Windows.Forms.ComboBox comboBoxSearchOption;
        private System.Windows.Forms.DataGridView dataGridViewDSAuthorBook;
        private System.Windows.Forms.Button buttonExit;
    }
}