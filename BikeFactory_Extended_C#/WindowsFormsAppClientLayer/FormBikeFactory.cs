﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ClassLibraryBikeFactoryBusLayer;
using ClassLibraryBikeFactoryDataLayer;

namespace WindowsFormsAppClientLayer
{
    public partial class FormBikeFactory : Form
    {
        public FormBikeFactory()
        {
            InitializeComponent();
        }

        List<Bike> listOfBikes = new List<Bike>();
        List<MountainBike> listOfMountainBikes = new List<MountainBike>();
        List<RoadBike> listOfRoadBikes = new List<RoadBike>();

        int indexBike = -1, indexRoadBike = -1, indexMountainBike = -1;

        // Load form and menu

        private void FormBikeFactory_Load(object sender, EventArgs e)
        {
            foreach (EnumColor currentItem in Enum.GetValues(typeof(EnumColor)))
            {
                this.comboBoxColor.Items.Add(currentItem);
            }

            string[] enumElements = Enum.GetNames(typeof(EnumSuspension));
            foreach (var currentSuspension in enumElements)
            {
                this.comboBoxSuspension.Items.Add(currentSuspension.Replace("_", " "));
            }

            this.ToolStripMenuItemRoad_Click(sender, e);

            this.buttonAdd.Enabled = false;
            this.buttonUpdate.Enabled = false;
            this.buttonRemove.Enabled = false;
            this.buttonExit.Enabled = true;
            this.buttonPrintBike.Enabled = true;
            this.buttonPrintMountainBike.Enabled = true;
            this.buttonPrintRoadBike.Enabled = true;
            this.buttonClear.Enabled = true;
            this.buttonSearch.Enabled = false;
            this.buttonWriteToFile.Enabled = false;
            this.buttonReadFromFile.Enabled = true;
            this.buttonWriteToXML.Enabled = false;
            this.buttonReadFromXML.Enabled = true;
        }

        private void ToolStripMenuItemMountain_Click(object sender, EventArgs e)
        {
            this.ToolStripMenuItemMountain.BackColor = Color.LightBlue;
            this.ToolStripMenuItemRoad.BackColor = Color.Blue;

            this.labelSuspension.Visible = true;
            this.comboBoxSuspension.Visible = true;
            this.labelHeightFromGround.Visible = true;
            this.textBoxHeightFromGround.Visible = true;

            this.labelSeatHeight.Visible = false;
            this.textBoxSeatHeight.Visible = false;

            this.comboBoxColor.Text = EnumColor.Undefined.ToString();
            this.comboBoxSuspension.Text = EnumSuspension.Undefined.ToString();
            this.dateTimePickerMadeDate.Value = DateTime.Today;
        }

        private void ToolStripMenuItemRoad_Click(object sender, EventArgs e)
        {
            this.ToolStripMenuItemRoad.BackColor = Color.LightBlue;
            this.ToolStripMenuItemMountain.BackColor = Color.Blue;

            this.labelSeatHeight.Visible = true;
            this.textBoxSeatHeight.Visible = true;

            this.labelSuspension.Visible = false;
            this.comboBoxSuspension.Visible = false;
            this.labelHeightFromGround.Visible = false;
            this.textBoxHeightFromGround.Visible = false;

            this.comboBoxColor.Text = EnumColor.Undefined.ToString();
            this.dateTimePickerMadeDate.Value = DateTime.Today;
        }

        // CRUD Methods (Add, Print, Remove, Update)

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.listBoxMountainBike.Items.Clear();
            this.listBoxRoadBike.Items.Clear();

            if (this.labelSeatHeight.Visible == true)
            {
                RoadBike currentRoadBike = new RoadBike();

                currentRoadBike.SerialNumber = Convert.ToInt64(this.textBoxSerialNumber.Text);
                currentRoadBike.Make = this.textBoxMake.Text;
                currentRoadBike.Model = this.textBoxModel.Text;
                currentRoadBike.Speed = Convert.ToDouble(this.textBoxSpeed.Text);
                currentRoadBike.NewSpeed = Convert.ToDouble(this.textBoxNewSpeed.Text);
                currentRoadBike.Color = (EnumColor)this.comboBoxColor.SelectedItem;
                currentRoadBike.Date = this.dateTimePickerMadeDate.Value.Date;
                currentRoadBike.SeatHeight = Convert.ToDouble(this.textBoxSeatHeight.Text);

                bool exsit = false;
                foreach (Bike currentItem in listOfBikes)
                {
                    if (currentItem.SerialNumber == Convert.ToInt64(this.textBoxSerialNumber.Text))
                    {
                        exsit = true;
                        break;
                    }
                }

                if (exsit == true)
                {
                    MessageBox.Show("Input Serail Number " + this.textBoxSerialNumber.Text + " is duplicated.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    listOfBikes.Add(currentRoadBike);
                    this.listBoxBike.Items.Add(currentRoadBike);

                    this.buttonWriteToFile.Enabled = true;
                    this.buttonWriteToXML.Enabled = true;
                    DisplayListView();

                    listOfRoadBikes.Add(currentRoadBike);
                    this.listBoxRoadBike.Items.Add(currentRoadBike);

                    double result = Convert.ToDouble(this.textBoxSpeed.Text) + Convert.ToDouble(this.textBoxNewSpeed.Text);
                    if (result > currentRoadBike.GetMaxSpeed())
                    {
                        MessageBox.Show("Speed exceed the MaxSpeed " + currentRoadBike.GetMaxSpeed() + ", set it to Initial Speed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (this.labelHeightFromGround.Visible == true)
            {
                MountainBike currentMountainBike = new MountainBike();

                currentMountainBike.SerialNumber = Convert.ToInt64(this.textBoxSerialNumber.Text);
                currentMountainBike.Make = this.textBoxMake.Text;
                currentMountainBike.Model = this.textBoxModel.Text;
                currentMountainBike.Speed = Convert.ToDouble(this.textBoxSpeed.Text);
                currentMountainBike.NewSpeed = Convert.ToDouble(this.textBoxNewSpeed.Text);
                currentMountainBike.Color = (EnumColor)this.comboBoxColor.SelectedItem;
                currentMountainBike.Date = this.dateTimePickerMadeDate.Value.Date;
                currentMountainBike.Suspension = (EnumSuspension)this.comboBoxSuspension.SelectedIndex;
                currentMountainBike.HeightFromGround = Convert.ToDouble(this.textBoxHeightFromGround.Text);

                bool exsit = false;
                foreach (Bike currentItem in listOfBikes)
                {
                    if (currentItem.SerialNumber == Convert.ToInt64(this.textBoxSerialNumber.Text))
                    {
                        exsit = true;
                        break;
                    }
                }

                if (exsit == true)
                {
                    MessageBox.Show("Input Serail Number " + this.textBoxSerialNumber.Text + " is duplicated.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listOfBikes.Add(currentMountainBike);

                    DisplayListView();
                    this.buttonWriteToFile.Enabled = true;
                    this.buttonWriteToXML.Enabled = true;

                    this.listBoxBike.Items.Add(currentMountainBike);

                    listOfMountainBikes.Add(currentMountainBike);
                    this.listBoxMountainBike.Items.Add(currentMountainBike);

                    double result = Convert.ToDouble(this.textBoxSpeed.Text) + Convert.ToDouble(this.textBoxNewSpeed.Text);
                    if (result > currentMountainBike.GetMaxSpeed())
                    {
                        MessageBox.Show("Speed exceed the MaxSpeed " + currentMountainBike.GetMaxSpeed() + ", set it to Initial Speed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


            this.textBoxSerialNumber.Focus();
            this.comboBoxColor.Text = EnumColor.Undefined.ToString();
            this.comboBoxSuspension.Text = EnumSuspension.Undefined.ToString();

            foreach (Control currentControl in Controls)
            {
                if (currentControl is TextBox)
                {
                    currentControl.Text = null;
                }
            }
        }

        private void buttonPrintBike_Click(object sender, EventArgs e)
        {
            if (this.listOfBikes.Count > 0)
            {
                foreach (Bike currentItem in this.listOfBikes)
                {
                    this.listBoxBike.Items.Add(currentItem);
                }
            }
            else
            {
                MessageBox.Show("No data found", "WARNING");
            }
            this.buttonPrintBike.Enabled = false;
        }

        private void buttonPrintRoadBike_Click(object sender, EventArgs e)
        {
            if (this.listOfRoadBikes.Count > 0)
            {
                foreach (RoadBike currentItem in this.listOfRoadBikes)
                {
                    this.listBoxRoadBike.Items.Add(currentItem);
                }
            }
            else
            {
                MessageBox.Show("No data found", "WARNING");
            }
            this.buttonPrintRoadBike.Enabled = false;
        }

        private void buttonPrintMountainBike_Click(object sender, EventArgs e)
        {
            if (this.listOfMountainBikes.Count > 0)
            {
                foreach (MountainBike currentItem in this.listOfMountainBikes)
                {
                    this.listBoxMountainBike.Items.Add(currentItem);
                }
            }
            else
            {
                MessageBox.Show("No data found", "WARNING");
            }
            this.buttonPrintMountainBike.Enabled = false;
        }

        private void listBoxBike_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexBike = this.listBoxBike.SelectedIndex;

            this.textBoxSerialNumber.Text = Convert.ToString(this.listOfBikes[indexBike].SerialNumber);
            this.textBoxMake.Text = this.listOfBikes[indexBike].Make;
            this.textBoxModel.Text = this.listOfBikes[indexBike].Model;
            this.comboBoxColor.Text = Convert.ToString(this.listOfBikes[indexBike].Color);
            this.textBoxSpeed.Text = Convert.ToString(this.listOfBikes[indexBike].Speed);
            this.textBoxNewSpeed.Text = Convert.ToString(this.listOfBikes[indexBike].NewSpeed);
            this.dateTimePickerMadeDate.Text = Convert.ToString(this.listOfBikes[indexBike].Date);

            if (this.listOfBikes[indexBike] is RoadBike)
            {
                ToolStripMenuItemRoad_Click(sender, e);
                foreach (RoadBike currentItem in this.listOfRoadBikes)
                {
                    if (currentItem == this.listOfBikes[indexBike])
                    {
                        this.listBoxRoadBike.SelectedItem = currentItem;
                        this.listBoxMountainBike.Items.Clear();
                        break;
                    }
                }

            }
            else if (this.listOfBikes[indexBike] is MountainBike)
            {
                ToolStripMenuItemMountain_Click(sender, e);
                foreach (MountainBike currentItem in this.listOfMountainBikes)
                {
                    if (currentItem == this.listOfBikes[indexBike])
                    {
                        this.listBoxMountainBike.SelectedItem = currentItem;
                        this.listBoxRoadBike.Items.Clear();
                        break;
                    }
                }
            }

            this.buttonAdd.Enabled = false;
            this.buttonRemove.Enabled = true;
            this.buttonUpdate.Enabled = true;
        }

        private void listBoxRoadBike_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexRoadBike = this.listBoxRoadBike.SelectedIndex;
            ToolStripMenuItemRoad_Click(sender, e);



            foreach (Bike currentItem in this.listOfBikes)
            {
                if (currentItem == this.listOfRoadBikes[indexRoadBike])
                {
                    this.listBoxBike.SelectedItem = currentItem;
                    this.listBoxMountainBike.Items.Clear();
                    break;
                }
            }

            this.textBoxSerialNumber.Text = Convert.ToString(this.listOfRoadBikes[indexRoadBike].SerialNumber);
            this.textBoxMake.Text = this.listOfRoadBikes[indexRoadBike].Make;
            this.textBoxModel.Text = this.listOfRoadBikes[indexRoadBike].Model;
            this.comboBoxColor.Text = Convert.ToString(this.listOfRoadBikes[indexRoadBike].Color);
            this.textBoxSpeed.Text = Convert.ToString(this.listOfRoadBikes[indexRoadBike].Speed);
            this.textBoxNewSpeed.Text = Convert.ToString(this.listOfRoadBikes[indexRoadBike].NewSpeed);
            this.dateTimePickerMadeDate.Text = Convert.ToString(this.listOfRoadBikes[indexRoadBike].Date);
            this.textBoxSeatHeight.Text = Convert.ToString(this.listOfRoadBikes[indexRoadBike].SeatHeight);

            this.buttonAdd.Enabled = false;
            this.buttonRemove.Enabled = true;
            this.buttonUpdate.Enabled = true;
        }

        private void listBoxMountainBike_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexMountainBike = this.listBoxMountainBike.SelectedIndex;
            ToolStripMenuItemMountain_Click(sender, e);

            foreach (Bike currentItem in this.listOfBikes)
            {
                if (currentItem == this.listOfMountainBikes[indexMountainBike])
                {
                    this.listBoxBike.SelectedItem = currentItem;
                    this.listBoxRoadBike.Items.Clear();
                    break;
                }
            }

            this.textBoxSerialNumber.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].SerialNumber);
            this.textBoxMake.Text = this.listOfMountainBikes[indexMountainBike].Make;
            this.textBoxModel.Text = this.listOfMountainBikes[indexMountainBike].Model;
            this.comboBoxColor.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].Color);
            this.textBoxSpeed.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].Speed);
            this.textBoxNewSpeed.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].NewSpeed);
            this.dateTimePickerMadeDate.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].Date);
            this.comboBoxSuspension.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].Suspension);
            this.textBoxHeightFromGround.Text = Convert.ToString(this.listOfMountainBikes[indexMountainBike].HeightFromGround);

            this.buttonAdd.Enabled = false;
            this.buttonRemove.Enabled = true;
            this.buttonUpdate.Enabled = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to Remove Bike from the list?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                double serial = this.listOfBikes[indexBike].SerialNumber;
                if (this.labelSeatHeight.Visible == true)
                {

                    foreach (RoadBike currentItem in this.listOfRoadBikes)
                    {
                        if (currentItem.SerialNumber == serial)
                        {
                            this.listOfRoadBikes.Remove(currentItem);
                            this.listOfBikes.Remove(currentItem);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (MountainBike currentItem in this.listOfMountainBikes)
                    {
                        if (currentItem.SerialNumber == serial)
                        {
                            this.listOfMountainBikes.Remove(currentItem);
                            this.listOfBikes.Remove(currentItem);
                            break;
                        }
                    }
                }

                MessageBox.Show("Selected Bike is removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Control currentControl in Controls)
                {
                    if (currentControl is TextBox)
                    {
                        currentControl.Text = null;
                    }
                }

                this.listBoxBike.Items.Clear();
                this.listBoxMountainBike.Items.Clear();
                this.listBoxRoadBike.Items.Clear();
                this.textBoxSerialNumber.Focus();
                this.comboBoxColor.Text = EnumColor.Undefined.ToString();
                this.comboBoxSuspension.Text = EnumSuspension.Undefined.ToString();
                this.buttonPrintBike.Enabled = true;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to Update selected bike from list?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (this.labelSeatHeight.Visible == true)
                {
                    this.listOfRoadBikes[indexRoadBike].SerialNumber = Convert.ToInt64(this.textBoxSerialNumber.Text);
                    this.listOfRoadBikes[indexRoadBike].Make = this.textBoxMake.Text;
                    this.listOfRoadBikes[indexRoadBike].Model = this.textBoxModel.Text;
                    this.listOfRoadBikes[indexRoadBike].Color = (EnumColor)Enum.Parse(typeof(EnumColor), this.comboBoxColor.Text);
                    this.listOfRoadBikes[indexRoadBike].Speed = Convert.ToDouble(this.textBoxSpeed.Text);
                    this.listOfRoadBikes[indexRoadBike].NewSpeed = Convert.ToDouble(this.textBoxNewSpeed.Text);
                    this.listOfRoadBikes[indexRoadBike].Date = Convert.ToDateTime(this.dateTimePickerMadeDate.Text);
                    this.listOfRoadBikes[indexRoadBike].SeatHeight = Convert.ToDouble(this.textBoxSeatHeight.Text);

                    MessageBox.Show("RoadBike with Serial Number " + this.textBoxSerialNumber.Text + " has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    double speedsum = Convert.ToDouble(this.textBoxSpeed.Text) + Convert.ToDouble(this.textBoxNewSpeed.Text);
                    if (speedsum > this.listOfRoadBikes[indexRoadBike].GetMaxSpeed())
                    {
                        MessageBox.Show("Speed exceed the MaxSpeed " + this.listOfRoadBikes[indexRoadBike].GetMaxSpeed() + ", set it to Initial Speed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    foreach (Control currentControl in Controls)
                    {
                        if (currentControl is TextBox)
                        {
                            currentControl.Text = null;
                        }
                    }
                    this.listBoxBike.Items.Clear();
                    this.listBoxRoadBike.Items.Clear();
                    this.textBoxSerialNumber.Focus();
                    this.comboBoxColor.Text = EnumColor.Undefined.ToString();

                    foreach (RoadBike currentItem in this.listOfRoadBikes)
                    {
                        this.listBoxRoadBike.Items.Add(currentItem);
                    }

                    foreach (Bike currentItem in this.listOfBikes)
                    {
                        this.listBoxBike.Items.Add(currentItem);
                    }

                    this.buttonWriteToFile.Enabled = true;
                    this.buttonWriteToXML.Enabled = true;
                }
                else
                {
                    this.listOfMountainBikes[indexMountainBike].SerialNumber = Convert.ToInt64(this.textBoxSerialNumber.Text);
                    this.listOfMountainBikes[indexMountainBike].Make = this.textBoxMake.Text;
                    this.listOfMountainBikes[indexMountainBike].Model = this.textBoxModel.Text;
                    this.listOfMountainBikes[indexMountainBike].Color = (EnumColor)Enum.Parse(typeof(EnumColor), this.comboBoxColor.Text);
                    this.listOfMountainBikes[indexMountainBike].Speed = Convert.ToDouble(this.textBoxSpeed.Text);
                    this.listOfMountainBikes[indexMountainBike].NewSpeed = Convert.ToDouble(this.textBoxNewSpeed.Text);
                    this.listOfMountainBikes[indexMountainBike].Date = Convert.ToDateTime(this.dateTimePickerMadeDate.Text);
                    this.listOfMountainBikes[indexMountainBike].HeightFromGround = Convert.ToDouble(this.textBoxHeightFromGround.Text);
                    this.listOfMountainBikes[indexMountainBike].Suspension = (EnumSuspension)Enum.Parse(typeof(EnumSuspension), this.comboBoxSuspension.Text);

                    MessageBox.Show("MountainBike with Serial Number " + this.textBoxSerialNumber.Text + " has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    double speedsum = Convert.ToDouble(this.textBoxSpeed.Text) + Convert.ToDouble(this.textBoxNewSpeed.Text);
                    if (speedsum > this.listOfMountainBikes[indexMountainBike].GetMaxSpeed())
                    {
                        MessageBox.Show("Speed exceed the MaxSpeed " + this.listOfMountainBikes[indexMountainBike].GetMaxSpeed() + ", set it to Initial Speed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    foreach (Control currentControl in Controls)
                    {
                        if (currentControl is TextBox)
                        {
                            currentControl.Text = null;
                        }
                    }
                    this.listBoxBike.Items.Clear();
                    this.listBoxMountainBike.Items.Clear();
                    this.textBoxSerialNumber.Focus();
                    this.comboBoxColor.Text = EnumColor.Undefined.ToString();
                    this.comboBoxSuspension.Text = EnumSuspension.Undefined.ToString();

                    foreach (MountainBike currentItem in this.listOfMountainBikes)
                    {
                        this.listBoxMountainBike.Items.Add(currentItem);
                    }

                    foreach (Bike currentItem in this.listOfBikes)
                    {
                        this.listBoxBike.Items.Add(currentItem);
                    }

                    this.buttonWriteToFile.Enabled = true;
                    this.buttonWriteToXML.Enabled = true;
                }
            }
        }

        // Search, Clear and Exit

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.buttonSearch.Enabled = true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            bool found = false;

            foreach (Bike currentItem in this.listOfBikes)
            {
                if (currentItem.SerialNumber == Convert.ToInt64(this.textBoxSearch.Text))
                {
                    found = true;
                    MessageBox.Show(currentItem.ToString());
                    break;
                }
            }
            if (found == false)
            {
                MessageBox.Show("Bike with Serial Number " + this.textBoxSearch.Text + " not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.textBoxSearch.Text = null;
            this.buttonSearch.Enabled = false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (Control currentControl in Controls)
            {
                if (currentControl is TextBox)
                {
                    currentControl.Text = null;
                }
            }

            this.listBoxBike.Items.Clear();
            this.listBoxMountainBike.Items.Clear();
            this.listBoxRoadBike.Items.Clear();
            this.textBoxSerialNumber.Focus();
            this.comboBoxColor.Text = EnumColor.Undefined.ToString();
            this.comboBoxSuspension.Text = EnumSuspension.Undefined.ToString();

            this.buttonAdd.Enabled = false;
            this.buttonUpdate.Enabled = false;
            this.buttonRemove.Enabled = false;
            this.buttonPrintBike.Enabled = true;
            this.buttonPrintMountainBike.Enabled = true;
            this.buttonPrintRoadBike.Enabled = true;
            this.buttonSearch.Enabled = false;
            this.buttonWriteToFile.Enabled = true;
            this.buttonReadFromFile.Enabled = true;
            this.buttonWriteToXML.Enabled = true;
            this.buttonReadFromXML.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thank you!", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        // Validations

        private void textBoxSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Serial number must be a digit");
                e.Handled = true;
            }
        }

        private void textBoxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("Speed must be a number");
                e.Handled = true;
            }
        }

        private void textBoxNewSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("New Speed must be a number");
                e.Handled = true;
            }
        }

        private void textBoxHeightFromGround_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("Height From Ground must be a number");
                e.Handled = true;
            }
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Serial number must be a digit");
                e.Handled = true;
            }
        }

        private void textBoxSeatHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("Seat height must be a number");
                e.Handled = true;
            }
        }

        private void comboBoxSuspension_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonAdd.Enabled = true;
        }

        private void textBoxSeatHeight_TextChanged(object sender, EventArgs e)
        {
            this.buttonAdd.Enabled = true;
        }

        // ListView

        public void DisplayListView()
        {
            listViewBikes.Items.Clear();

            foreach (Bike item in listOfBikes)
            {
                ListViewItem anItem = new ListViewItem(Convert.ToString(item.SerialNumber));

                anItem.SubItems.Add(item.Make);
                anItem.SubItems.Add(item.Model);
                anItem.SubItems.Add(Convert.ToString(item.GetMaxSpeed()));
                anItem.SubItems.Add(Convert.ToString(item.SpeedUp(newSpeed: Convert.ToDouble(textBoxNewSpeed.Text))));
                anItem.SubItems.Add(Convert.ToString(item.Color));
                anItem.SubItems.Add(item.Date.ToShortDateString());

                listViewBikes.Items.Add(anItem);
            }
        }

        public void DisplayListView(List<Bike> listOfBikes)
        {
            listViewBikes.Items.Clear();

            foreach (Bike item in listOfBikes)
            {
                ListViewItem anItem = new ListViewItem(Convert.ToString(item.SerialNumber));

                anItem.SubItems.Add(item.Make);
                anItem.SubItems.Add(item.Model);
                anItem.SubItems.Add(Convert.ToString(item.GetMaxSpeed()));
                anItem.SubItems.Add(Convert.ToString(item.SpeedUp(newSpeed: Convert.ToDouble(textBoxNewSpeed.Text))));
                anItem.SubItems.Add(Convert.ToString(item.Color));
                anItem.SubItems.Add(item.Date.ToShortDateString());

                listViewBikes.Items.Add(anItem);
            }
        }

        private void listViewBikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonAdd.Enabled = true;
            this.buttonPrintBike.Enabled = true;
            this.buttonPrintMountainBike.Enabled = true;
            this.buttonPrintRoadBike.Enabled = true;
        }

        // Data - Read and Write to files (Binary and XML files)

        private void buttonReadFromXML_Click(object sender, EventArgs e)
        {

            if (FileHandler.ReadFromXmlFile().Count > 0)
            {
                listOfBikes.Clear();

                listOfBikes = FileHandler.ReadFromXmlFile();

                foreach (Bike item in listOfBikes)
                {
                    this.listBoxBike.Items.Add(item);
                }

                MessageBox.Show("Read from file successfully");
            }
            else
            {
               MessageBox.Show("No data found", "WARNING");
            }
        }

        private void buttonWriteToXML_Click(object sender, EventArgs e)
        {
            FileHandler.WriteToXmlFile(listOfBikes);

            MessageBox.Show("You wrote to file successfully");
        }

        private void buttonWriteToFile_Click(object sender, EventArgs e)
        {
            FileHandler.WriteIntoSerializedFile(listOfBikes);

            MessageBox.Show("You wrote to file successfully");
        }

        private void buttonReadFromFile_Click(object sender, EventArgs e)
        {
            if (FileHandler.ReadFromSerializedFile().Count > 0)
            {
                listOfBikes.Clear();

                listOfBikes = FileHandler.ReadFromSerializedFile();

                foreach (Bike item in listOfBikes)
                {
                    this.listBoxBike.Items.Add(item);
                }

                MessageBox.Show("Read from file successfully");
            }
            else
            {
                MessageBox.Show("No data found", "WARNING");
            }
        }

    }
}
