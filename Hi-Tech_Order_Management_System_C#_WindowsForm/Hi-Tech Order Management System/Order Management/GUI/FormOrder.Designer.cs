namespace Order_Management.GUI
{
    partial class FormOrder
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
            this.buttonToLogin = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewOrders = new System.Windows.Forms.ListView();
            this.columnHeaderOrderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRequiredDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShippingDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCustomerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmployeeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSearchOrder = new System.Windows.Forms.Button();
            this.labelDisplayOrder = new System.Windows.Forms.Label();
            this.textBoxSearchOrder = new System.Windows.Forms.TextBox();
            this.comboBoxSearchOrder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.buttonGetEmployee = new System.Windows.Forms.Button();
            this.buttonGetCustomer = new System.Windows.Forms.Button();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerShippingDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxOrderType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxOrderStatus = new System.Windows.Forms.ComboBox();
            this.buttonClearOrder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonListOrder = new System.Windows.Forms.Button();
            this.buttonCancelOrder = new System.Windows.Forms.Button();
            this.buttonUpdateOrder = new System.Windows.Forms.Button();
            this.buttonSaveOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGetBook = new System.Windows.Forms.Button();
            this.buttonGetOrder = new System.Windows.Forms.Button();
            this.textBoxQuantityOrdered = new System.Windows.Forms.TextBox();
            this.comboBoxBookTitle = new System.Windows.Forms.ComboBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxOrderId = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonClearOrderLine = new System.Windows.Forms.Button();
            this.buttonListOrderLine = new System.Windows.Forms.Button();
            this.buttonCancelOrderLine = new System.Windows.Forms.Button();
            this.buttonUpdateOrderLine = new System.Windows.Forms.Button();
            this.buttonSaveOrderLine = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labelDisplayOrderLine = new System.Windows.Forms.Label();
            this.textBoxSearchOrderLine = new System.Windows.Forms.TextBox();
            this.comboBoxSearchOrderLine = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listViewOrderLine = new System.Windows.Forms.ListView();
            this.columnHeaderOrderLineId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderISBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantityOrdered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePickerSearch = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSearchOption = new System.Windows.Forms.ComboBox();
            this.buttonSearchOrderLine = new System.Windows.Forms.Button();
            this.groupBoxOrder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonToLogin
            // 
            this.buttonToLogin.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonToLogin.Location = new System.Drawing.Point(1472, 158);
            this.buttonToLogin.Name = "buttonToLogin";
            this.buttonToLogin.Size = new System.Drawing.Size(128, 46);
            this.buttonToLogin.TabIndex = 85;
            this.buttonToLogin.Tag = "";
            this.buttonToLogin.Text = "Back To Login";
            this.buttonToLogin.UseVisualStyleBackColor = false;
            this.buttonToLogin.Click += new System.EventHandler(this.buttonToLogin_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Location = new System.Drawing.Point(170, 529);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 28);
            this.label8.TabIndex = 84;
            this.label8.Text = "Please Select First";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewOrders
            // 
            this.listViewOrders.BackColor = System.Drawing.SystemColors.Info;
            this.listViewOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrderId,
            this.columnHeaderOrderDate,
            this.columnHeaderOrderType,
            this.columnHeaderRequiredDate,
            this.columnHeaderShippingDate,
            this.columnHeaderOrderStatus,
            this.columnHeaderCustomerId,
            this.columnHeaderEmployeeId});
            this.listViewOrders.FullRowSelect = true;
            this.listViewOrders.GridLines = true;
            this.listViewOrders.HideSelection = false;
            this.listViewOrders.Location = new System.Drawing.Point(31, 636);
            this.listViewOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewOrders.Name = "listViewOrders";
            this.listViewOrders.Size = new System.Drawing.Size(709, 175);
            this.listViewOrders.TabIndex = 83;
            this.listViewOrders.UseCompatibleStateImageBehavior = false;
            this.listViewOrders.View = System.Windows.Forms.View.Details;
            this.listViewOrders.SelectedIndexChanged += new System.EventHandler(this.listViewOrders_SelectedIndexChanged);
            // 
            // columnHeaderOrderId
            // 
            this.columnHeaderOrderId.Text = "Order ID";
            this.columnHeaderOrderId.Width = 116;
            // 
            // columnHeaderOrderDate
            // 
            this.columnHeaderOrderDate.Text = "Order Date";
            this.columnHeaderOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderDate.Width = 91;
            // 
            // columnHeaderOrderType
            // 
            this.columnHeaderOrderType.Text = "Order Type";
            this.columnHeaderOrderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderType.Width = 117;
            // 
            // columnHeaderRequiredDate
            // 
            this.columnHeaderRequiredDate.Text = "Required Date";
            this.columnHeaderRequiredDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderRequiredDate.Width = 138;
            // 
            // columnHeaderShippingDate
            // 
            this.columnHeaderShippingDate.Text = "Shipping Date";
            this.columnHeaderShippingDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderShippingDate.Width = 83;
            // 
            // columnHeaderOrderStatus
            // 
            this.columnHeaderOrderStatus.Text = "Order Status";
            this.columnHeaderOrderStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderOrderStatus.Width = 160;
            // 
            // columnHeaderCustomerId
            // 
            this.columnHeaderCustomerId.Text = "Customer ID";
            // 
            // columnHeaderEmployeeId
            // 
            this.columnHeaderEmployeeId.Text = "Employee ID";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonExit.Location = new System.Drawing.Point(1488, 211);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 46);
            this.buttonExit.TabIndex = 80;
            this.buttonExit.Tag = "";
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSearchOrder
            // 
            this.buttonSearchOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearchOrder.Location = new System.Drawing.Point(547, 546);
            this.buttonSearchOrder.Name = "buttonSearchOrder";
            this.buttonSearchOrder.Size = new System.Drawing.Size(163, 40);
            this.buttonSearchOrder.TabIndex = 78;
            this.buttonSearchOrder.Tag = "";
            this.buttonSearchOrder.Text = "Search Order";
            this.buttonSearchOrder.UseVisualStyleBackColor = false;
            this.buttonSearchOrder.Click += new System.EventHandler(this.buttonSearchOrder_Click);
            // 
            // labelDisplayOrder
            // 
            this.labelDisplayOrder.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelDisplayOrder.Location = new System.Drawing.Point(330, 529);
            this.labelDisplayOrder.Name = "labelDisplayOrder";
            this.labelDisplayOrder.Size = new System.Drawing.Size(211, 28);
            this.labelDisplayOrder.TabIndex = 81;
            this.labelDisplayOrder.Text = "Message";
            this.labelDisplayOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearchOrder
            // 
            this.textBoxSearchOrder.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearchOrder.Location = new System.Drawing.Point(359, 560);
            this.textBoxSearchOrder.Name = "textBoxSearchOrder";
            this.textBoxSearchOrder.Size = new System.Drawing.Size(148, 22);
            this.textBoxSearchOrder.TabIndex = 77;
            // 
            // comboBoxSearchOrder
            // 
            this.comboBoxSearchOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearchOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchOrder.FormattingEnabled = true;
            this.comboBoxSearchOrder.Items.AddRange(new object[] {
            "Order ID",
            "Order Date",
            "Order Type",
            "Required Date",
            "Shipping Date",
            "Order Status"});
            this.comboBoxSearchOrder.Location = new System.Drawing.Point(173, 560);
            this.comboBoxSearchOrder.Name = "comboBoxSearchOrder";
            this.comboBoxSearchOrder.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSearchOrder.TabIndex = 76;
            this.comboBoxSearchOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchOrder_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(45, 556);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 30);
            this.label6.TabIndex = 82;
            this.label6.Text = "Search By";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.buttonGetEmployee);
            this.groupBoxOrder.Controls.Add(this.buttonGetCustomer);
            this.groupBoxOrder.Controls.Add(this.comboBoxEmployee);
            this.groupBoxOrder.Controls.Add(this.label11);
            this.groupBoxOrder.Controls.Add(this.comboBoxCustomer);
            this.groupBoxOrder.Controls.Add(this.label10);
            this.groupBoxOrder.Controls.Add(this.dateTimePickerShippingDate);
            this.groupBoxOrder.Controls.Add(this.dateTimePickerRequiredDate);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderType);
            this.groupBoxOrder.Controls.Add(this.dateTimePickerOrderDate);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderStatus);
            this.groupBoxOrder.Controls.Add(this.buttonClearOrder);
            this.groupBoxOrder.Controls.Add(this.label9);
            this.groupBoxOrder.Controls.Add(this.label7);
            this.groupBoxOrder.Controls.Add(this.buttonListOrder);
            this.groupBoxOrder.Controls.Add(this.buttonCancelOrder);
            this.groupBoxOrder.Controls.Add(this.buttonUpdateOrder);
            this.groupBoxOrder.Controls.Add(this.buttonSaveOrder);
            this.groupBoxOrder.Controls.Add(this.label5);
            this.groupBoxOrder.Controls.Add(this.label4);
            this.groupBoxOrder.Controls.Add(this.label3);
            this.groupBoxOrder.Controls.Add(this.label2);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderId);
            this.groupBoxOrder.Controls.Add(this.label1);
            this.groupBoxOrder.Location = new System.Drawing.Point(75, 30);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(542, 478);
            this.groupBoxOrder.TabIndex = 79;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Order Information";
            // 
            // buttonGetEmployee
            // 
            this.buttonGetEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonGetEmployee.Location = new System.Drawing.Point(314, 410);
            this.buttonGetEmployee.Name = "buttonGetEmployee";
            this.buttonGetEmployee.Size = new System.Drawing.Size(135, 36);
            this.buttonGetEmployee.TabIndex = 23;
            this.buttonGetEmployee.Tag = "";
            this.buttonGetEmployee.Text = "Get Information";
            this.buttonGetEmployee.UseVisualStyleBackColor = false;
            this.buttonGetEmployee.Click += new System.EventHandler(this.buttonGetEmployee_Click);
            // 
            // buttonGetCustomer
            // 
            this.buttonGetCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonGetCustomer.Location = new System.Drawing.Point(314, 362);
            this.buttonGetCustomer.Name = "buttonGetCustomer";
            this.buttonGetCustomer.Size = new System.Drawing.Size(135, 36);
            this.buttonGetCustomer.TabIndex = 22;
            this.buttonGetCustomer.Tag = "";
            this.buttonGetCustomer.Text = "Get Information";
            this.buttonGetCustomer.UseVisualStyleBackColor = false;
            this.buttonGetCustomer.Click += new System.EventHandler(this.buttonGetCustomer_Click);
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(153, 417);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(138, 24);
            this.comboBoxEmployee.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(25, 419);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 22);
            this.label11.TabIndex = 20;
            this.label11.Text = "Employee ID";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(153, 367);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(138, 24);
            this.comboBoxCustomer.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(25, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 22);
            this.label10.TabIndex = 18;
            this.label10.Text = "Customer ID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerShippingDate
            // 
            this.dateTimePickerShippingDate.Location = new System.Drawing.Point(153, 267);
            this.dateTimePickerShippingDate.Name = "dateTimePickerShippingDate";
            this.dateTimePickerShippingDate.Size = new System.Drawing.Size(173, 22);
            this.dateTimePickerShippingDate.TabIndex = 17;
            // 
            // dateTimePickerRequiredDate
            // 
            this.dateTimePickerRequiredDate.Location = new System.Drawing.Point(153, 219);
            this.dateTimePickerRequiredDate.Name = "dateTimePickerRequiredDate";
            this.dateTimePickerRequiredDate.Size = new System.Drawing.Size(173, 22);
            this.dateTimePickerRequiredDate.TabIndex = 16;
            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderType.FormattingEnabled = true;
            this.comboBoxOrderType.Items.AddRange(new object[] {
            "By Phone",
            "By Fax",
            "By Email"});
            this.comboBoxOrderType.Location = new System.Drawing.Point(153, 163);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new System.Drawing.Size(138, 24);
            this.comboBoxOrderType.TabIndex = 15;
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(153, 97);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(173, 22);
            this.dateTimePickerOrderDate.TabIndex = 14;
            // 
            // comboBoxOrderStatus
            // 
            this.comboBoxOrderStatus.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxOrderStatus.FormattingEnabled = true;
            this.comboBoxOrderStatus.Items.AddRange(new object[] {
            "In Process",
            "Pending",
            "Completed",
            "Shipped"});
            this.comboBoxOrderStatus.Location = new System.Drawing.Point(153, 316);
            this.comboBoxOrderStatus.Name = "comboBoxOrderStatus";
            this.comboBoxOrderStatus.Size = new System.Drawing.Size(138, 24);
            this.comboBoxOrderStatus.TabIndex = 13;
            // 
            // buttonClearOrder
            // 
            this.buttonClearOrder.BackColor = System.Drawing.Color.Tan;
            this.buttonClearOrder.Location = new System.Drawing.Point(349, 244);
            this.buttonClearOrder.Name = "buttonClearOrder";
            this.buttonClearOrder.Size = new System.Drawing.Size(150, 36);
            this.buttonClearOrder.TabIndex = 11;
            this.buttonClearOrder.Tag = "";
            this.buttonClearOrder.Text = "Clear &All";
            this.buttonClearOrder.UseVisualStyleBackColor = false;
            this.buttonClearOrder.Click += new System.EventHandler(this.buttonClearOrder_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 22);
            this.label9.TabIndex = 12;
            this.label9.Text = "Shipping Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(25, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Required Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonListOrder
            // 
            this.buttonListOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListOrder.Location = new System.Drawing.Point(349, 191);
            this.buttonListOrder.Name = "buttonListOrder";
            this.buttonListOrder.Size = new System.Drawing.Size(150, 36);
            this.buttonListOrder.TabIndex = 10;
            this.buttonListOrder.Tag = "";
            this.buttonListOrder.Text = "&List Orders";
            this.buttonListOrder.UseVisualStyleBackColor = false;
            this.buttonListOrder.Click += new System.EventHandler(this.buttonListOrder_Click);
            // 
            // buttonCancelOrder
            // 
            this.buttonCancelOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCancelOrder.Location = new System.Drawing.Point(349, 138);
            this.buttonCancelOrder.Name = "buttonCancelOrder";
            this.buttonCancelOrder.Size = new System.Drawing.Size(150, 36);
            this.buttonCancelOrder.TabIndex = 9;
            this.buttonCancelOrder.Tag = "";
            this.buttonCancelOrder.Text = "&Cancel Order";
            this.buttonCancelOrder.UseVisualStyleBackColor = false;
            this.buttonCancelOrder.Click += new System.EventHandler(this.buttonCancelOrder_Click);
            // 
            // buttonUpdateOrder
            // 
            this.buttonUpdateOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateOrder.Location = new System.Drawing.Point(349, 81);
            this.buttonUpdateOrder.Name = "buttonUpdateOrder";
            this.buttonUpdateOrder.Size = new System.Drawing.Size(150, 38);
            this.buttonUpdateOrder.TabIndex = 8;
            this.buttonUpdateOrder.Tag = "";
            this.buttonUpdateOrder.Text = "&Update Order";
            this.buttonUpdateOrder.UseVisualStyleBackColor = false;
            this.buttonUpdateOrder.Click += new System.EventHandler(this.buttonUpdateOrder_Click);
            // 
            // buttonSaveOrder
            // 
            this.buttonSaveOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSaveOrder.Location = new System.Drawing.Point(349, 31);
            this.buttonSaveOrder.Name = "buttonSaveOrder";
            this.buttonSaveOrder.Size = new System.Drawing.Size(150, 36);
            this.buttonSaveOrder.TabIndex = 7;
            this.buttonSaveOrder.Tag = "";
            this.buttonSaveOrder.Text = "&Save Order";
            this.buttonSaveOrder.UseVisualStyleBackColor = false;
            this.buttonSaveOrder.Click += new System.EventHandler(this.buttonSaveOrder_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Order Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Order Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Order Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(140, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Only Digits)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxOrderId.Location = new System.Drawing.Point(143, 29);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(138, 22);
            this.textBoxOrderId.TabIndex = 1;
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
            this.label1.Text = "Order ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGetBook);
            this.groupBox1.Controls.Add(this.buttonGetOrder);
            this.groupBox1.Controls.Add(this.textBoxQuantityOrdered);
            this.groupBox1.Controls.Add(this.comboBoxBookTitle);
            this.groupBox1.Controls.Add(this.buttonRefresh);
            this.groupBox1.Controls.Add(this.comboBoxOrderId);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.buttonClearOrderLine);
            this.groupBox1.Controls.Add(this.buttonListOrderLine);
            this.groupBox1.Controls.Add(this.buttonCancelOrderLine);
            this.groupBox1.Controls.Add(this.buttonUpdateOrderLine);
            this.groupBox1.Controls.Add(this.buttonSaveOrderLine);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(815, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 478);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Line Information";
            // 
            // buttonGetBook
            // 
            this.buttonGetBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonGetBook.Location = new System.Drawing.Point(308, 237);
            this.buttonGetBook.Name = "buttonGetBook";
            this.buttonGetBook.Size = new System.Drawing.Size(131, 36);
            this.buttonGetBook.TabIndex = 25;
            this.buttonGetBook.Tag = "";
            this.buttonGetBook.Text = "Get Information";
            this.buttonGetBook.UseVisualStyleBackColor = false;
            this.buttonGetBook.Click += new System.EventHandler(this.buttonGetBook_Click);
            // 
            // buttonGetOrder
            // 
            this.buttonGetOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonGetOrder.Location = new System.Drawing.Point(308, 121);
            this.buttonGetOrder.Name = "buttonGetOrder";
            this.buttonGetOrder.Size = new System.Drawing.Size(131, 36);
            this.buttonGetOrder.TabIndex = 24;
            this.buttonGetOrder.Tag = "";
            this.buttonGetOrder.Text = "Get Information";
            this.buttonGetOrder.UseVisualStyleBackColor = false;
            this.buttonGetOrder.Click += new System.EventHandler(this.buttonGetOrder_Click);
            // 
            // textBoxQuantityOrdered
            // 
            this.textBoxQuantityOrdered.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxQuantityOrdered.Location = new System.Drawing.Point(153, 361);
            this.textBoxQuantityOrdered.Name = "textBoxQuantityOrdered";
            this.textBoxQuantityOrdered.Size = new System.Drawing.Size(138, 22);
            this.textBoxQuantityOrdered.TabIndex = 22;
            // 
            // comboBoxBookTitle
            // 
            this.comboBoxBookTitle.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxBookTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBookTitle.FormattingEnabled = true;
            this.comboBoxBookTitle.Location = new System.Drawing.Point(153, 244);
            this.comboBoxBookTitle.Name = "comboBoxBookTitle";
            this.comboBoxBookTitle.Size = new System.Drawing.Size(138, 24);
            this.comboBoxBookTitle.TabIndex = 23;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Tan;
            this.buttonRefresh.Location = new System.Drawing.Point(462, 405);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(150, 36);
            this.buttonRefresh.TabIndex = 22;
            this.buttonRefresh.Tag = "";
            this.buttonRefresh.Text = "Refresh Form";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxOrderId
            // 
            this.comboBoxOrderId.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxOrderId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderId.FormattingEnabled = true;
            this.comboBoxOrderId.Location = new System.Drawing.Point(153, 128);
            this.comboBoxOrderId.Name = "comboBoxOrderId";
            this.comboBoxOrderId.Size = new System.Drawing.Size(138, 24);
            this.comboBoxOrderId.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(25, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 38);
            this.label12.TabIndex = 20;
            this.label12.Text = "Quantity Ordered";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClearOrderLine
            // 
            this.buttonClearOrderLine.BackColor = System.Drawing.Color.Tan;
            this.buttonClearOrderLine.Location = new System.Drawing.Point(462, 329);
            this.buttonClearOrderLine.Name = "buttonClearOrderLine";
            this.buttonClearOrderLine.Size = new System.Drawing.Size(150, 36);
            this.buttonClearOrderLine.TabIndex = 11;
            this.buttonClearOrderLine.Tag = "";
            this.buttonClearOrderLine.Text = "Clear &All";
            this.buttonClearOrderLine.UseVisualStyleBackColor = false;
            this.buttonClearOrderLine.Click += new System.EventHandler(this.buttonClearOrderLine_Click);
            // 
            // buttonListOrderLine
            // 
            this.buttonListOrderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonListOrderLine.Location = new System.Drawing.Point(462, 253);
            this.buttonListOrderLine.Name = "buttonListOrderLine";
            this.buttonListOrderLine.Size = new System.Drawing.Size(150, 36);
            this.buttonListOrderLine.TabIndex = 10;
            this.buttonListOrderLine.Tag = "";
            this.buttonListOrderLine.Text = "&List Order Lines";
            this.buttonListOrderLine.UseVisualStyleBackColor = false;
            this.buttonListOrderLine.Click += new System.EventHandler(this.buttonListOrderLine_Click);
            // 
            // buttonCancelOrderLine
            // 
            this.buttonCancelOrderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCancelOrderLine.Enabled = false;
            this.buttonCancelOrderLine.Location = new System.Drawing.Point(462, 181);
            this.buttonCancelOrderLine.Name = "buttonCancelOrderLine";
            this.buttonCancelOrderLine.Size = new System.Drawing.Size(150, 36);
            this.buttonCancelOrderLine.TabIndex = 9;
            this.buttonCancelOrderLine.Tag = "";
            this.buttonCancelOrderLine.Text = "&Cancel Order Line";
            this.buttonCancelOrderLine.UseVisualStyleBackColor = false;
            this.buttonCancelOrderLine.Click += new System.EventHandler(this.buttonCancelOrderLine_Click);
            // 
            // buttonUpdateOrderLine
            // 
            this.buttonUpdateOrderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdateOrderLine.Enabled = false;
            this.buttonUpdateOrderLine.Location = new System.Drawing.Point(462, 109);
            this.buttonUpdateOrderLine.Name = "buttonUpdateOrderLine";
            this.buttonUpdateOrderLine.Size = new System.Drawing.Size(150, 38);
            this.buttonUpdateOrderLine.TabIndex = 8;
            this.buttonUpdateOrderLine.Tag = "";
            this.buttonUpdateOrderLine.Text = "&Update Order Line";
            this.buttonUpdateOrderLine.UseVisualStyleBackColor = false;
            this.buttonUpdateOrderLine.Click += new System.EventHandler(this.buttonUpdateOrderLine_Click);
            // 
            // buttonSaveOrderLine
            // 
            this.buttonSaveOrderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSaveOrderLine.Location = new System.Drawing.Point(462, 49);
            this.buttonSaveOrderLine.Name = "buttonSaveOrderLine";
            this.buttonSaveOrderLine.Size = new System.Drawing.Size(150, 36);
            this.buttonSaveOrderLine.TabIndex = 7;
            this.buttonSaveOrderLine.Tag = "";
            this.buttonSaveOrderLine.Text = "&Save Order Line";
            this.buttonSaveOrderLine.UseVisualStyleBackColor = false;
            this.buttonSaveOrderLine.Click += new System.EventHandler(this.buttonSaveOrderLine_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(25, 244);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 22);
            this.label18.TabIndex = 3;
            this.label18.Text = "Book Title";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(25, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 22);
            this.label20.TabIndex = 0;
            this.label20.Text = "Order ID";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label13.Location = new System.Drawing.Point(940, 519);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 28);
            this.label13.TabIndex = 91;
            this.label13.Text = "Please Select First";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDisplayOrderLine
            // 
            this.labelDisplayOrderLine.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelDisplayOrderLine.Location = new System.Drawing.Point(1100, 519);
            this.labelDisplayOrderLine.Name = "labelDisplayOrderLine";
            this.labelDisplayOrderLine.Size = new System.Drawing.Size(194, 28);
            this.labelDisplayOrderLine.TabIndex = 89;
            this.labelDisplayOrderLine.Text = "Message";
            this.labelDisplayOrderLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearchOrderLine
            // 
            this.textBoxSearchOrderLine.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearchOrderLine.Location = new System.Drawing.Point(1123, 550);
            this.textBoxSearchOrderLine.Name = "textBoxSearchOrderLine";
            this.textBoxSearchOrderLine.Size = new System.Drawing.Size(148, 22);
            this.textBoxSearchOrderLine.TabIndex = 87;
            // 
            // comboBoxSearchOrderLine
            // 
            this.comboBoxSearchOrderLine.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBoxSearchOrderLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchOrderLine.FormattingEnabled = true;
            this.comboBoxSearchOrderLine.Items.AddRange(new object[] {
            "Order ID",
            "Book Title"});
            this.comboBoxSearchOrderLine.Location = new System.Drawing.Point(943, 550);
            this.comboBoxSearchOrderLine.Name = "comboBoxSearchOrderLine";
            this.comboBoxSearchOrderLine.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSearchOrderLine.TabIndex = 86;
            this.comboBoxSearchOrderLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchOrderLine_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(815, 546);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 30);
            this.label15.TabIndex = 90;
            this.label15.Text = "Search By";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewOrderLine
            // 
            this.listViewOrderLine.BackColor = System.Drawing.SystemColors.Info;
            this.listViewOrderLine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrderLineId,
            this.columnHeaderISBN,
            this.columnHeaderQuantityOrdered});
            this.listViewOrderLine.FullRowSelect = true;
            this.listViewOrderLine.GridLines = true;
            this.listViewOrderLine.HideSelection = false;
            this.listViewOrderLine.Location = new System.Drawing.Point(815, 636);
            this.listViewOrderLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewOrderLine.Name = "listViewOrderLine";
            this.listViewOrderLine.Size = new System.Drawing.Size(709, 175);
            this.listViewOrderLine.TabIndex = 92;
            this.listViewOrderLine.UseCompatibleStateImageBehavior = false;
            this.listViewOrderLine.View = System.Windows.Forms.View.Details;
            this.listViewOrderLine.SelectedIndexChanged += new System.EventHandler(this.listViewOrderLine_SelectedIndexChanged);
            // 
            // columnHeaderOrderLineId
            // 
            this.columnHeaderOrderLineId.Text = "Order ID";
            this.columnHeaderOrderLineId.Width = 116;
            // 
            // columnHeaderISBN
            // 
            this.columnHeaderISBN.Text = "ISBN";
            this.columnHeaderISBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderISBN.Width = 91;
            // 
            // columnHeaderQuantityOrdered
            // 
            this.columnHeaderQuantityOrdered.Text = "Quantity Ordered";
            this.columnHeaderQuantityOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderQuantityOrdered.Width = 117;
            // 
            // dateTimePickerSearch
            // 
            this.dateTimePickerSearch.Location = new System.Drawing.Point(351, 560);
            this.dateTimePickerSearch.Name = "dateTimePickerSearch";
            this.dateTimePickerSearch.Size = new System.Drawing.Size(173, 22);
            this.dateTimePickerSearch.TabIndex = 24;
            this.dateTimePickerSearch.Visible = false;
            // 
            // comboBoxSearchOption
            // 
            this.comboBoxSearchOption.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchOption.FormattingEnabled = true;
            this.comboBoxSearchOption.Items.AddRange(new object[] {
            "By Phone",
            "By Fax",
            "By Email"});
            this.comboBoxSearchOption.Location = new System.Drawing.Point(359, 562);
            this.comboBoxSearchOption.Name = "comboBoxSearchOption";
            this.comboBoxSearchOption.Size = new System.Drawing.Size(148, 24);
            this.comboBoxSearchOption.TabIndex = 24;
            this.comboBoxSearchOption.Visible = false;
            // 
            // buttonSearchOrderLine
            // 
            this.buttonSearchOrderLine.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearchOrderLine.Location = new System.Drawing.Point(1317, 536);
            this.buttonSearchOrderLine.Name = "buttonSearchOrderLine";
            this.buttonSearchOrderLine.Size = new System.Drawing.Size(163, 40);
            this.buttonSearchOrderLine.TabIndex = 88;
            this.buttonSearchOrderLine.Tag = "";
            this.buttonSearchOrderLine.Text = "Search Order Lines";
            this.buttonSearchOrderLine.UseVisualStyleBackColor = false;
            this.buttonSearchOrderLine.Click += new System.EventHandler(this.buttonSearchOrderLine_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 885);
            this.Controls.Add(this.comboBoxSearchOption);
            this.Controls.Add(this.dateTimePickerSearch);
            this.Controls.Add(this.listViewOrderLine);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonSearchOrderLine);
            this.Controls.Add(this.labelDisplayOrderLine);
            this.Controls.Add(this.textBoxSearchOrderLine);
            this.Controls.Add(this.comboBoxSearchOrderLine);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonToLogin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listViewOrders);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSearchOrder);
            this.Controls.Add(this.labelDisplayOrder);
            this.Controls.Add(this.textBoxSearchOrder);
            this.Controls.Add(this.comboBoxSearchOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "FormOrder";
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToLogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listViewOrders;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderId;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderType;
        private System.Windows.Forms.ColumnHeader columnHeaderRequiredDate;
        private System.Windows.Forms.ColumnHeader columnHeaderShippingDate;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderStatus;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSearchOrder;
        private System.Windows.Forms.Label labelDisplayOrder;
        private System.Windows.Forms.TextBox textBoxSearchOrder;
        private System.Windows.Forms.ComboBox comboBoxSearchOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.ComboBox comboBoxOrderStatus;
        private System.Windows.Forms.Button buttonClearOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonListOrder;
        private System.Windows.Forms.Button buttonCancelOrder;
        private System.Windows.Forms.Button buttonUpdateOrder;
        private System.Windows.Forms.Button buttonSaveOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerShippingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequiredDate;
        private System.Windows.Forms.ComboBox comboBoxOrderType;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader columnHeaderCustomerId;
        private System.Windows.Forms.ColumnHeader columnHeaderEmployeeId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxQuantityOrdered;
        private System.Windows.Forms.ComboBox comboBoxBookTitle;
        private System.Windows.Forms.ComboBox comboBoxOrderId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonClearOrderLine;
        private System.Windows.Forms.Button buttonListOrderLine;
        private System.Windows.Forms.Button buttonCancelOrderLine;
        private System.Windows.Forms.Button buttonUpdateOrderLine;
        private System.Windows.Forms.Button buttonSaveOrderLine;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelDisplayOrderLine;
        private System.Windows.Forms.TextBox textBoxSearchOrderLine;
        private System.Windows.Forms.ComboBox comboBoxSearchOrderLine;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView listViewOrderLine;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderLineId;
        private System.Windows.Forms.ColumnHeader columnHeaderISBN;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantityOrdered;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonGetEmployee;
        private System.Windows.Forms.Button buttonGetCustomer;
        private System.Windows.Forms.Button buttonGetOrder;
        private System.Windows.Forms.Button buttonGetBook;
        private System.Windows.Forms.DateTimePicker dateTimePickerSearch;
        private System.Windows.Forms.ComboBox comboBoxSearchOption;
        private System.Windows.Forms.Button buttonSearchOrderLine;
    }
}