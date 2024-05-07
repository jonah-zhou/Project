﻿namespace Bike_Factory.Client
{
    partial class FormBikeFactory
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
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.labelMake = new System.Windows.Forms.Label();
            this.textBoxMake = new System.Windows.Forms.TextBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.labelMadeDate = new System.Windows.Forms.Label();
            this.labelSeatHeight = new System.Windows.Forms.Label();
            this.textBoxSeatHeight = new System.Windows.Forms.TextBox();
            this.labelSuspension = new System.Windows.Forms.Label();
            this.comboBoxSuspension = new System.Windows.Forms.ComboBox();
            this.labelHeightFromGround = new System.Windows.Forms.Label();
            this.textBoxHeightFromGround = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonPrintBike = new System.Windows.Forms.Button();
            this.buttonPrintMountainBike = new System.Windows.Forms.Button();
            this.buttonPrintRoadBike = new System.Windows.Forms.Button();
            this.listBoxBike = new System.Windows.Forms.ListBox();
            this.listBoxMountainBike = new System.Windows.Forms.ListBox();
            this.listBoxRoadBike = new System.Windows.Forms.ListBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelNewSpeed = new System.Windows.Forms.Label();
            this.textBoxNewSpeed = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemRoad = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMountain = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePickerMadeDate = new System.Windows.Forms.DateTimePicker();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listViewBikes = new System.Windows.Forms.ListView();
            this.columnHeaderSerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMake = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMaxSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSpeedUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMadeDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonReadFromFile = new System.Windows.Forms.Button();
            this.buttonWriteToFile = new System.Windows.Forms.Button();
            this.labelBinaryFile = new System.Windows.Forms.Label();
            this.buttonReadFromXML = new System.Windows.Forms.Button();
            this.buttonWriteToXML = new System.Windows.Forms.Button();
            this.labelXMLFile = new System.Windows.Forms.Label();
            this.groupBoxBrinary = new System.Windows.Forms.GroupBox();
            this.groupBoxXml = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerialNumber.Location = new System.Drawing.Point(31, 46);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(167, 32);
            this.labelSerialNumber.TabIndex = 0;
            this.labelSerialNumber.Text = "Bike Serial Number ?:";
            this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSerialNumber.Location = new System.Drawing.Point(219, 57);
            this.textBoxSerialNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(121, 22);
            this.textBoxSerialNumber.TabIndex = 1;
            this.textBoxSerialNumber.TextChanged += new System.EventHandler(this.textBoxSerialNumber_TextChanged);
            this.textBoxSerialNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSerialNumber_KeyPress);
            // 
            // labelMake
            // 
            this.labelMake.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelMake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMake.Location = new System.Drawing.Point(31, 78);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(167, 36);
            this.labelMake.TabIndex = 2;
            this.labelMake.Text = "Bike Make ?:";
            this.labelMake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMake
            // 
            this.textBoxMake.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxMake.Location = new System.Drawing.Point(219, 92);
            this.textBoxMake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMake.Name = "textBoxMake";
            this.textBoxMake.Size = new System.Drawing.Size(121, 22);
            this.textBoxMake.TabIndex = 3;
            // 
            // labelModel
            // 
            this.labelModel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelModel.Location = new System.Drawing.Point(31, 114);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(167, 37);
            this.labelModel.TabIndex = 4;
            this.labelModel.Text = "Bike Model ?:";
            this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxModel
            // 
            this.textBoxModel.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxModel.Location = new System.Drawing.Point(219, 130);
            this.textBoxModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(121, 22);
            this.textBoxModel.TabIndex = 5;
            // 
            // labelColor
            // 
            this.labelColor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelColor.Location = new System.Drawing.Point(31, 223);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(167, 36);
            this.labelColor.TabIndex = 10;
            this.labelColor.Text = "Bike Color ?:";
            this.labelColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(219, 235);
            this.comboBoxColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(121, 24);
            this.comboBoxColor.TabIndex = 11;
            // 
            // labelSpeed
            // 
            this.labelSpeed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSpeed.Location = new System.Drawing.Point(31, 151);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(167, 34);
            this.labelSpeed.TabIndex = 6;
            this.labelSpeed.Text = "Bike Speed ?:";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSpeed.Location = new System.Drawing.Point(219, 162);
            this.textBoxSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(121, 22);
            this.textBoxSpeed.TabIndex = 7;
            this.textBoxSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSpeed_KeyPress);
            // 
            // labelMadeDate
            // 
            this.labelMadeDate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelMadeDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMadeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMadeDate.Location = new System.Drawing.Point(31, 258);
            this.labelMadeDate.Name = "labelMadeDate";
            this.labelMadeDate.Size = new System.Drawing.Size(167, 39);
            this.labelMadeDate.TabIndex = 12;
            this.labelMadeDate.Text = "Bike Made Date ?:";
            this.labelMadeDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSeatHeight
            // 
            this.labelSeatHeight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSeatHeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSeatHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSeatHeight.Location = new System.Drawing.Point(31, 298);
            this.labelSeatHeight.Name = "labelSeatHeight";
            this.labelSeatHeight.Size = new System.Drawing.Size(167, 60);
            this.labelSeatHeight.TabIndex = 12;
            this.labelSeatHeight.Text = "Seat Height ?:";
            this.labelSeatHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSeatHeight
            // 
            this.textBoxSeatHeight.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSeatHeight.Location = new System.Drawing.Point(219, 336);
            this.textBoxSeatHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSeatHeight.Name = "textBoxSeatHeight";
            this.textBoxSeatHeight.Size = new System.Drawing.Size(121, 22);
            this.textBoxSeatHeight.TabIndex = 13;
            this.textBoxSeatHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSeatHeight_KeyPress);
            // 
            // labelSuspension
            // 
            this.labelSuspension.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSuspension.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSuspension.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSuspension.Location = new System.Drawing.Point(31, 358);
            this.labelSuspension.Name = "labelSuspension";
            this.labelSuspension.Size = new System.Drawing.Size(167, 55);
            this.labelSuspension.TabIndex = 16;
            this.labelSuspension.Text = "Suspension ?:";
            this.labelSuspension.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSuspension
            // 
            this.comboBoxSuspension.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxSuspension.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxSuspension.FormattingEnabled = true;
            this.comboBoxSuspension.Location = new System.Drawing.Point(219, 389);
            this.comboBoxSuspension.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSuspension.Name = "comboBoxSuspension";
            this.comboBoxSuspension.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSuspension.TabIndex = 17;
            // 
            // labelHeightFromGround
            // 
            this.labelHeightFromGround.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelHeightFromGround.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHeightFromGround.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHeightFromGround.Location = new System.Drawing.Point(31, 298);
            this.labelHeightFromGround.Name = "labelHeightFromGround";
            this.labelHeightFromGround.Size = new System.Drawing.Size(167, 60);
            this.labelHeightFromGround.TabIndex = 14;
            this.labelHeightFromGround.Text = "Height From Ground ?:";
            this.labelHeightFromGround.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHeightFromGround
            // 
            this.textBoxHeightFromGround.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxHeightFromGround.Location = new System.Drawing.Point(219, 336);
            this.textBoxHeightFromGround.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHeightFromGround.Name = "textBoxHeightFromGround";
            this.textBoxHeightFromGround.Size = new System.Drawing.Size(121, 22);
            this.textBoxHeightFromGround.TabIndex = 15;
            this.textBoxHeightFromGround.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHeightFromGround_KeyPress);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAdd.Location = new System.Drawing.Point(31, 446);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(83, 34);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUpdate.Location = new System.Drawing.Point(131, 446);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(91, 34);
            this.buttonUpdate.TabIndex = 20;
            this.buttonUpdate.Text = "UPDATE";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSearch.Location = new System.Drawing.Point(445, 374);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(203, 46);
            this.labelSearch.TabIndex = 22;
            this.labelSearch.Text = "Search Serial Number ?:";
            this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSearch.Location = new System.Drawing.Point(671, 385);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(103, 22);
            this.textBoxSearch.TabIndex = 23;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSearch.Location = new System.Drawing.Point(792, 379);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(89, 34);
            this.buttonSearch.TabIndex = 24;
            this.buttonSearch.Text = "SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonPrintBike
            // 
            this.buttonPrintBike.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPrintBike.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPrintBike.Location = new System.Drawing.Point(444, 57);
            this.buttonPrintBike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrintBike.Name = "buttonPrintBike";
            this.buttonPrintBike.Size = new System.Drawing.Size(117, 59);
            this.buttonPrintBike.TabIndex = 25;
            this.buttonPrintBike.Text = "Print Bike";
            this.buttonPrintBike.UseVisualStyleBackColor = false;
            this.buttonPrintBike.Click += new System.EventHandler(this.buttonPrintBike_Click);
            // 
            // buttonPrintMountainBike
            // 
            this.buttonPrintMountainBike.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPrintMountainBike.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPrintMountainBike.Location = new System.Drawing.Point(444, 274);
            this.buttonPrintMountainBike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrintMountainBike.Name = "buttonPrintMountainBike";
            this.buttonPrintMountainBike.Size = new System.Drawing.Size(117, 63);
            this.buttonPrintMountainBike.TabIndex = 26;
            this.buttonPrintMountainBike.Text = "Print Mountain Bike";
            this.buttonPrintMountainBike.UseVisualStyleBackColor = false;
            this.buttonPrintMountainBike.Click += new System.EventHandler(this.buttonPrintMountainBike_Click);
            // 
            // buttonPrintRoadBike
            // 
            this.buttonPrintRoadBike.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPrintRoadBike.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPrintRoadBike.Location = new System.Drawing.Point(444, 162);
            this.buttonPrintRoadBike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrintRoadBike.Name = "buttonPrintRoadBike";
            this.buttonPrintRoadBike.Size = new System.Drawing.Size(117, 64);
            this.buttonPrintRoadBike.TabIndex = 27;
            this.buttonPrintRoadBike.Text = "Print Road Bike";
            this.buttonPrintRoadBike.UseVisualStyleBackColor = false;
            this.buttonPrintRoadBike.Click += new System.EventHandler(this.buttonPrintRoadBike_Click);
            // 
            // listBoxBike
            // 
            this.listBoxBike.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxBike.FormattingEnabled = true;
            this.listBoxBike.ItemHeight = 16;
            this.listBoxBike.Location = new System.Drawing.Point(587, 34);
            this.listBoxBike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxBike.Name = "listBoxBike";
            this.listBoxBike.Size = new System.Drawing.Size(461, 100);
            this.listBoxBike.TabIndex = 28;
            this.listBoxBike.SelectedIndexChanged += new System.EventHandler(this.listBoxBike_SelectedIndexChanged);
            // 
            // listBoxMountainBike
            // 
            this.listBoxMountainBike.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxMountainBike.FormattingEnabled = true;
            this.listBoxMountainBike.ItemHeight = 16;
            this.listBoxMountainBike.Location = new System.Drawing.Point(587, 252);
            this.listBoxMountainBike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxMountainBike.Name = "listBoxMountainBike";
            this.listBoxMountainBike.Size = new System.Drawing.Size(461, 84);
            this.listBoxMountainBike.TabIndex = 29;
            this.listBoxMountainBike.SelectedIndexChanged += new System.EventHandler(this.listBoxMountainBike_SelectedIndexChanged);
            // 
            // listBoxRoadBike
            // 
            this.listBoxRoadBike.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxRoadBike.FormattingEnabled = true;
            this.listBoxRoadBike.ItemHeight = 16;
            this.listBoxRoadBike.Location = new System.Drawing.Point(587, 150);
            this.listBoxRoadBike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxRoadBike.Name = "listBoxRoadBike";
            this.listBoxRoadBike.Size = new System.Drawing.Size(461, 84);
            this.listBoxRoadBike.TabIndex = 30;
            this.listBoxRoadBike.SelectedIndexChanged += new System.EventHandler(this.listBoxRoadBike_SelectedIndexChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(856, 446);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(87, 34);
            this.buttonExit.TabIndex = 31;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClear.Location = new System.Drawing.Point(963, 446);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(87, 34);
            this.buttonClear.TabIndex = 32;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelNewSpeed
            // 
            this.labelNewSpeed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelNewSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNewSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNewSpeed.Location = new System.Drawing.Point(31, 185);
            this.labelNewSpeed.Name = "labelNewSpeed";
            this.labelNewSpeed.Size = new System.Drawing.Size(167, 38);
            this.labelNewSpeed.TabIndex = 8;
            this.labelNewSpeed.Text = "Bike New Speed ?:";
            this.labelNewSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNewSpeed
            // 
            this.textBoxNewSpeed.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxNewSpeed.Location = new System.Drawing.Point(219, 201);
            this.textBoxNewSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNewSpeed.Name = "textBoxNewSpeed";
            this.textBoxNewSpeed.Size = new System.Drawing.Size(121, 22);
            this.textBoxNewSpeed.TabIndex = 9;
            this.textBoxNewSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewSpeed_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemRoad,
            this.ToolStripMenuItemMountain});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1071, 30);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemRoad
            // 
            this.ToolStripMenuItemRoad.AutoSize = false;
            this.ToolStripMenuItemRoad.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ToolStripMenuItemRoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ToolStripMenuItemRoad.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ToolStripMenuItemRoad.Name = "ToolStripMenuItemRoad";
            this.ToolStripMenuItemRoad.Padding = new System.Windows.Forms.Padding(10);
            this.ToolStripMenuItemRoad.Size = new System.Drawing.Size(152, 24);
            this.ToolStripMenuItemRoad.Text = "Road Bike";
            this.ToolStripMenuItemRoad.Click += new System.EventHandler(this.ToolStripMenuItemRoad_Click);
            // 
            // ToolStripMenuItemMountain
            // 
            this.ToolStripMenuItemMountain.AutoSize = false;
            this.ToolStripMenuItemMountain.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ToolStripMenuItemMountain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ToolStripMenuItemMountain.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ToolStripMenuItemMountain.Name = "ToolStripMenuItemMountain";
            this.ToolStripMenuItemMountain.Padding = new System.Windows.Forms.Padding(10);
            this.ToolStripMenuItemMountain.Size = new System.Drawing.Size(152, 26);
            this.ToolStripMenuItemMountain.Text = "Mountain Bike";
            this.ToolStripMenuItemMountain.Click += new System.EventHandler(this.ToolStripMenuItemMountain_Click);
            // 
            // dateTimePickerMadeDate
            // 
            this.dateTimePickerMadeDate.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dateTimePickerMadeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerMadeDate.Location = new System.Drawing.Point(219, 274);
            this.dateTimePickerMadeDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerMadeDate.Name = "dateTimePickerMadeDate";
            this.dateTimePickerMadeDate.Size = new System.Drawing.Size(121, 22);
            this.dateTimePickerMadeDate.TabIndex = 13;
            this.dateTimePickerMadeDate.Value = new System.DateTime(2022, 7, 16, 0, 0, 0, 0);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRemove.Location = new System.Drawing.Point(233, 446);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(107, 34);
            this.buttonRemove.TabIndex = 37;
            this.buttonRemove.Text = "REMOVE";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listViewBikes
            // 
            this.listViewBikes.BackColor = System.Drawing.SystemColors.Info;
            this.listViewBikes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSerialNumber,
            this.columnHeaderMake,
            this.columnHeaderModel,
            this.columnHeaderMaxSpeed,
            this.columnHeaderSpeedUp,
            this.columnHeaderColor,
            this.columnHeaderMadeDate});
            this.listViewBikes.FullRowSelect = true;
            this.listViewBikes.GridLines = true;
            this.listViewBikes.HideSelection = false;
            this.listViewBikes.Location = new System.Drawing.Point(31, 569);
            this.listViewBikes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewBikes.Name = "listViewBikes";
            this.listViewBikes.Size = new System.Drawing.Size(1017, 143);
            this.listViewBikes.TabIndex = 38;
            this.listViewBikes.UseCompatibleStateImageBehavior = false;
            this.listViewBikes.View = System.Windows.Forms.View.Details;
            this.listViewBikes.SelectedIndexChanged += new System.EventHandler(this.listViewBikes_SelectedIndexChanged);
            // 
            // columnHeaderSerialNumber
            // 
            this.columnHeaderSerialNumber.Text = "SerialNumber";
            this.columnHeaderSerialNumber.Width = 156;
            // 
            // columnHeaderMake
            // 
            this.columnHeaderMake.Text = "Make";
            this.columnHeaderMake.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMake.Width = 130;
            // 
            // columnHeaderModel
            // 
            this.columnHeaderModel.Text = "Model";
            this.columnHeaderModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderModel.Width = 165;
            // 
            // columnHeaderMaxSpeed
            // 
            this.columnHeaderMaxSpeed.Text = "Max Speed";
            this.columnHeaderMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMaxSpeed.Width = 102;
            // 
            // columnHeaderSpeedUp
            // 
            this.columnHeaderSpeedUp.Text = "SpeedUp";
            this.columnHeaderSpeedUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderSpeedUp.Width = 97;
            // 
            // columnHeaderColor
            // 
            this.columnHeaderColor.Text = "Color";
            this.columnHeaderColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderColor.Width = 89;
            // 
            // columnHeaderMadeDate
            // 
            this.columnHeaderMadeDate.Text = "Made Date";
            this.columnHeaderMadeDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMadeDate.Width = 204;
            // 
            // buttonReadFromFile
            // 
            this.buttonReadFromFile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonReadFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReadFromFile.Location = new System.Drawing.Point(139, 513);
            this.buttonReadFromFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReadFromFile.Name = "buttonReadFromFile";
            this.buttonReadFromFile.Size = new System.Drawing.Size(163, 34);
            this.buttonReadFromFile.TabIndex = 39;
            this.buttonReadFromFile.Text = "READ FROM FILE";
            this.buttonReadFromFile.UseVisualStyleBackColor = false;
            this.buttonReadFromFile.Click += new System.EventHandler(this.buttonReadFromFile_Click);
            // 
            // buttonWriteToFile
            // 
            this.buttonWriteToFile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWriteToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonWriteToFile.Location = new System.Drawing.Point(307, 513);
            this.buttonWriteToFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWriteToFile.Name = "buttonWriteToFile";
            this.buttonWriteToFile.Size = new System.Drawing.Size(163, 34);
            this.buttonWriteToFile.TabIndex = 40;
            this.buttonWriteToFile.Text = "WRITE TO FILE";
            this.buttonWriteToFile.UseVisualStyleBackColor = false;
            this.buttonWriteToFile.Click += new System.EventHandler(this.buttonWriteToFile_Click);
            // 
            // labelBinaryFile
            // 
            this.labelBinaryFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelBinaryFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBinaryFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBinaryFile.Location = new System.Drawing.Point(31, 511);
            this.labelBinaryFile.Name = "labelBinaryFile";
            this.labelBinaryFile.Size = new System.Drawing.Size(97, 37);
            this.labelBinaryFile.TabIndex = 43;
            this.labelBinaryFile.Text = "Binary :";
            this.labelBinaryFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReadFromXML
            // 
            this.buttonReadFromXML.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonReadFromXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReadFromXML.Location = new System.Drawing.Point(713, 513);
            this.buttonReadFromXML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReadFromXML.Name = "buttonReadFromXML";
            this.buttonReadFromXML.Size = new System.Drawing.Size(163, 34);
            this.buttonReadFromXML.TabIndex = 41;
            this.buttonReadFromXML.Text = "READ FROM FILE";
            this.buttonReadFromXML.UseVisualStyleBackColor = false;
            this.buttonReadFromXML.Click += new System.EventHandler(this.buttonReadFromXML_Click);
            // 
            // buttonWriteToXML
            // 
            this.buttonWriteToXML.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWriteToXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonWriteToXML.Location = new System.Drawing.Point(887, 512);
            this.buttonWriteToXML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWriteToXML.Name = "buttonWriteToXML";
            this.buttonWriteToXML.Size = new System.Drawing.Size(163, 34);
            this.buttonWriteToXML.TabIndex = 42;
            this.buttonWriteToXML.Text = "WRITE TO FILE";
            this.buttonWriteToXML.UseVisualStyleBackColor = false;
            this.buttonWriteToXML.Click += new System.EventHandler(this.buttonWriteToXML_Click);
            // 
            // labelXMLFile
            // 
            this.labelXMLFile.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelXMLFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelXMLFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXMLFile.Location = new System.Drawing.Point(601, 511);
            this.labelXMLFile.Name = "labelXMLFile";
            this.labelXMLFile.Size = new System.Drawing.Size(97, 37);
            this.labelXMLFile.TabIndex = 44;
            this.labelXMLFile.Text = "XML :";
            this.labelXMLFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxBrinary
            // 
            this.groupBoxBrinary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxBrinary.Location = new System.Drawing.Point(12, 485);
            this.groupBoxBrinary.Name = "groupBoxBrinary";
            this.groupBoxBrinary.Size = new System.Drawing.Size(480, 79);
            this.groupBoxBrinary.TabIndex = 45;
            this.groupBoxBrinary.TabStop = false;
            this.groupBoxBrinary.Text = "groupBoxBrinary";
            // 
            // groupBoxXml
            // 
            this.groupBoxXml.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxXml.Location = new System.Drawing.Point(578, 485);
            this.groupBoxXml.Name = "groupBoxXml";
            this.groupBoxXml.Size = new System.Drawing.Size(481, 79);
            this.groupBoxXml.TabIndex = 46;
            this.groupBoxXml.TabStop = false;
            this.groupBoxXml.Text = "groupBoxXml";
            // 
            // FormBikeFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 741);
            this.Controls.Add(this.labelXMLFile);
            this.Controls.Add(this.labelBinaryFile);
            this.Controls.Add(this.buttonWriteToXML);
            this.Controls.Add(this.buttonReadFromXML);
            this.Controls.Add(this.buttonWriteToFile);
            this.Controls.Add(this.buttonReadFromFile);
            this.Controls.Add(this.listViewBikes);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.dateTimePickerMadeDate);
            this.Controls.Add(this.textBoxNewSpeed);
            this.Controls.Add(this.labelNewSpeed);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.listBoxRoadBike);
            this.Controls.Add(this.listBoxMountainBike);
            this.Controls.Add(this.listBoxBike);
            this.Controls.Add(this.buttonPrintRoadBike);
            this.Controls.Add(this.buttonPrintMountainBike);
            this.Controls.Add(this.buttonPrintBike);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxHeightFromGround);
            this.Controls.Add(this.labelHeightFromGround);
            this.Controls.Add(this.comboBoxSuspension);
            this.Controls.Add(this.labelSuspension);
            this.Controls.Add(this.textBoxSeatHeight);
            this.Controls.Add(this.labelSeatHeight);
            this.Controls.Add(this.labelMadeDate);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.textBoxMake);
            this.Controls.Add(this.labelMake);
            this.Controls.Add(this.textBoxSerialNumber);
            this.Controls.Add(this.labelSerialNumber);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxBrinary);
            this.Controls.Add(this.groupBoxXml);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBikeFactory";
            this.Text = "$$ Bike Factory $$";
            this.Load += new System.EventHandler(this.FormBikeFactory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSerialNumber;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.TextBox textBoxMake;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label labelMadeDate;
        private System.Windows.Forms.Label labelSeatHeight;
        private System.Windows.Forms.TextBox textBoxSeatHeight;
        private System.Windows.Forms.Label labelSuspension;
        private System.Windows.Forms.ComboBox comboBoxSuspension;
        private System.Windows.Forms.Label labelHeightFromGround;
        private System.Windows.Forms.TextBox textBoxHeightFromGround;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBoxRoadBike;
        private System.Windows.Forms.ListBox listBoxMountainBike;
        private System.Windows.Forms.ListBox listBoxBike;
        private System.Windows.Forms.Button buttonPrintRoadBike;
        private System.Windows.Forms.Button buttonPrintMountainBike;
        private System.Windows.Forms.Button buttonPrintBike;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelNewSpeed;
        private System.Windows.Forms.TextBox textBoxNewSpeed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRoad;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMountain;
        private System.Windows.Forms.DateTimePicker dateTimePickerMadeDate;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListView listViewBikes;
        private System.Windows.Forms.ColumnHeader columnHeaderSerialNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderMake;
        private System.Windows.Forms.ColumnHeader columnHeaderModel;
        private System.Windows.Forms.ColumnHeader columnHeaderMaxSpeed;
        private System.Windows.Forms.ColumnHeader columnHeaderSpeedUp;
        private System.Windows.Forms.ColumnHeader columnHeaderColor;
        private System.Windows.Forms.ColumnHeader columnHeaderMadeDate;
        private System.Windows.Forms.Button buttonReadFromFile;
        private System.Windows.Forms.Button buttonWriteToFile;
        private System.Windows.Forms.Label labelBinaryFile;
        private System.Windows.Forms.Button buttonReadFromXML;
        private System.Windows.Forms.Button buttonWriteToXML;
        private System.Windows.Forms.Label labelXMLFile;
        private System.Windows.Forms.GroupBox groupBoxBrinary;
        private System.Windows.Forms.GroupBox groupBoxXml;
    }
}
