using Order_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.VALIDATION;
using System.Security.Cryptography;
using System.Collections;
using System.Security.Policy;
using System.Diagnostics;
using SystemLogin;
namespace Order_Management.GUI
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }
        int indexOrderLine = -1;
        int indexOrder = -1;

        List<Order> listGeneralOrder = new List<Order>();
        List<OrderLine> listGenenalOrderLine = new List<OrderLine>();

        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                Order newOrder = new Order();
                if (textBoxOrderId.Text.Trim().Length > 0)
                {
                    if (Validator.IsValidId(textBoxOrderId.Text.Trim(), textBoxOrderId.Text.Trim().Length))
                    {

                        List<Order> listO = newOrder.GetAllOrders();
                        bool checkExist = false;
                        foreach (Order ord in listO)
                        {
                            if (ord.OrderId == Convert.ToInt32(textBoxOrderId.Text.Trim()))
                            {
                                if (ord.OrderId == Convert.ToInt32(textBoxOrderId.Text.Trim()))
                                {
                                    checkExist = true;
                                }
                            }
                        }
                        if (checkExist)
                        {
                            MessageBox.Show("The Order ID you input has already existed", "Duplicated ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxOrderId.Clear();
                            textBoxOrderId.Focus();
                            dateTimePickerOrderDate.Value = DateTime.Now;
                            dateTimePickerRequiredDate.Value = DateTime.Now;
                            dateTimePickerShippingDate.Value = DateTime.Now;
                            comboBoxOrderType.Text = "";
                            comboBoxOrderStatus.Text = "";
                            comboBoxEmployee.Text = "";
                            comboBoxCustomer.Text = "";
                            return;
                        }
                        else
                        {
                            newOrder.OrderId = Convert.ToInt32(textBoxOrderId.Text.Trim());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please insert only digits for Order ID", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxOrderId.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please insert the Order ID", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxOrderId.Clear();
                    return;

                }
                TimeSpan value = DateTime.Now.Subtract(dateTimePickerOrderDate.Value);
                int checkValue = (int)value.TotalMinutes;
                if (checkValue >= 0)
                {
                    newOrder.OrderDate = dateTimePickerOrderDate.Value;
                }
                else
                {
                    MessageBox.Show("The Order Date must be in past", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dateTimePickerOrderDate.Value = DateTime.Now;
                    dateTimePickerRequiredDate.Value = DateTime.Now;
                    dateTimePickerShippingDate.Value = DateTime.Now;
                    comboBoxOrderType.Text = "";
                    comboBoxOrderStatus.Text = "";
                    comboBoxEmployee.Text = "";
                    comboBoxCustomer.Text = "";
                    return;
                }



                switch (comboBoxOrderType.Text)
                {
                    case "By Phone":
                        {
                            newOrder.OrderType = "By Phone";
                            break;
                        }
                    case "By Fax":
                        {
                            newOrder.OrderType = "By Fax";
                            break;
                        }
                    case "By Email":
                        {
                            newOrder.OrderType = "By Email";
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("The Order Type must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            dateTimePickerRequiredDate.Value = DateTime.Now;
                            dateTimePickerShippingDate.Value = DateTime.Now;
                            comboBoxOrderType.Text = "";
                            comboBoxOrderStatus.Text = "";
                            comboBoxEmployee.Text = "";
                            comboBoxCustomer.Text = "";

                            return;
                        }

                }
                value = DateTime.Now.Subtract(dateTimePickerRequiredDate.Value);
                checkValue = (int)value.TotalMinutes;
                if (checkValue <= 0)
                {
                    newOrder.RequiredDate = dateTimePickerRequiredDate.Value;
                }
                else
                {
                    MessageBox.Show("The Required Date must be in future", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dateTimePickerRequiredDate.Value = DateTime.Now;
                    dateTimePickerShippingDate.Value = DateTime.Now;

                    comboBoxOrderStatus.Text = "";
                    comboBoxEmployee.Text = "";
                    comboBoxCustomer.Text = "";
                    return;
                }
                value = DateTime.Now.Subtract(dateTimePickerShippingDate.Value);
                checkValue = (int)value.TotalMinutes;
                if (checkValue <= 0)
                {
                    newOrder.ShippingDate = dateTimePickerShippingDate.Value;
                }
                else
                {
                    MessageBox.Show("The Shipping Date must be in future", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                    dateTimePickerShippingDate.Value = DateTime.Now;

                    comboBoxOrderStatus.Text = "";
                    comboBoxEmployee.Text = "";
                    comboBoxCustomer.Text = "";
                    return;
                }

                switch (comboBoxOrderStatus.Text)
                {
                    case "In Process":
                        {
                            newOrder.OrderStatus = 1;
                            break;
                        }
                    case "Pending":
                        {
                            newOrder.OrderStatus = 2;
                            break;
                        }
                    case "Completed":
                        {
                            newOrder.OrderStatus = 3;
                            break;
                        }
                    case "Shipped":
                        {
                            newOrder.OrderStatus = 4;
                            break;
                        }

                    default:
                        {
                            MessageBox.Show("The Order Status must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            comboBoxOrderStatus.Text = "";
                            comboBoxEmployee.Text = "";
                            comboBoxCustomer.Text = "";
                            return;
                        }
                }
                if (comboBoxCustomer.Text.Length > 0)
                {

                    Customer cu = new Customer();
                    cu = db.Customers.Find(Convert.ToInt32(comboBoxCustomer.Text));

                    newOrder.CustomerId = cu.CustomerId;
                }
                else
                {
                    MessageBox.Show("The Customer ID must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxEmployee.Text = "";
                    comboBoxCustomer.Text = "";

                    return;
                }
                if (comboBoxEmployee.Text.Length > 0)
                {

                    Employee emp = new Employee();
                    emp = db.Employees.Find(Convert.ToInt32(comboBoxEmployee.Text));
                    newOrder.EmployeeId = emp.EmployeeId;
                }
                else
                {
                    MessageBox.Show("The Employee ID must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxEmployee.Text = "";
                    return;
                }
                MessageBox.Show($"{newOrder}");
                MessageBox.Show("New Order is added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Orders.Add(newOrder);
                db.SaveChanges();
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                dateTimePickerOrderDate.Value = DateTime.Now;
                dateTimePickerRequiredDate.Value = DateTime.Now;
                dateTimePickerShippingDate.Value = DateTime.Now;
                comboBoxOrderType.Text = "";
                comboBoxOrderStatus.Text = "";
                comboBoxEmployee.Text = "";
                comboBoxCustomer.Text = "";
                listViewOrders.Items.Clear();
            }


        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listE = emp.GetAllEmployees();
            comboBoxEmployee.Items.Clear();
            foreach (Employee em in listE)
            {
                comboBoxEmployee.Items.Add(em.EmployeeId);
            }
            Customer cu = new Customer();
            List<Customer> listC = cu.GetAllCustomers();
            comboBoxCustomer.Items.Clear();
            foreach (Customer c in listC)
            {
                comboBoxCustomer.Items.Add(c.CustomerId);
            }
            Book boo = new Book();
            List<Book> listB = boo.GetAllBooks();
            comboBoxBookTitle.Items.Clear();
            foreach (Book b in listB)
            {
                comboBoxBookTitle.Items.Add(b.BookTitle);
            }
            Order ord = new Order();
            List<Order> listO = ord.GetAllOrders();
            comboBoxOrderId.Items.Clear();
            foreach (Order o in listO)
            {
                comboBoxOrderId.Items.Add(o.OrderId);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {

            FormOrder_Load(sender, e);
        }

        private void buttonGetCustomer_Click(object sender, EventArgs e)
        {

            if (comboBoxCustomer.Text.Length > 0)
            {
                Customer cu = new Customer();
                List<Customer> listC = cu.GetAllCustomers();
                foreach (Customer customer in listC)
                {
                    if (customer.CustomerId == Convert.ToInt32(comboBoxCustomer.Text.Trim()))
                    {
                        MessageBox.Show($"{customer}", "Customer Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the Customer ID", "Missing Informtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void buttonGetEmployee_Click(object sender, EventArgs e)
        {

            if (comboBoxEmployee.Text.Length > 0)
            {
                Employee emp = new Employee();
                List<Employee> listE = emp.GetAllEmployees();
                foreach (Employee employee in listE)
                {
                    if (employee.EmployeeId == Convert.ToInt32(comboBoxEmployee.Text.Trim()))
                    {
                        MessageBox.Show($"{employee}", "Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the Employee ID", "Missing Informtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void buttonGetOrder_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                if (comboBoxOrderId.Text.Length > 0)
                {
                    Order ord = new Order();
                    List<Order> listO = ord.GetAllOrders();

                    foreach (Order order in listO)
                    {
                        if (order.OrderId == Convert.ToInt32(comboBoxOrderId.Text.Trim()))
                        {
                            MessageBox.Show($"{order}", "Order Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    listViewOrderLine.Columns.Clear();
                    listViewOrderLine.Items.Clear();
                    listViewOrderLine.Columns.Add("ISBN");
                    listViewOrderLine.Columns.Add("Book Title");
                    listViewOrderLine.Columns.Add("Unit Price");
                    listViewOrderLine.Columns.Add("QOH");
                    listViewOrderLine.Columns.Add("Publisher ID");
                    listViewOrderLine.Columns.Add("Category ID");
                    listViewOrderLine.Columns.Add("Status");
                    foreach (OrderLine orderLine in db.OrderLines)
                    {
                        if (orderLine.OrderId == Convert.ToInt32(comboBoxOrderId.Text))
                        {
                            Book newBook = db.Books.Find(orderLine.ISBN);
                            ListViewItem item = new ListViewItem(newBook.ISBN);
                            item.SubItems.Add(newBook.BookTitle);
                            item.SubItems.Add(Convert.ToString(newBook.UnitPrice));
                            item.SubItems.Add(Convert.ToString(newBook.QOH));
                            item.SubItems.Add(Convert.ToString(newBook.PublisherId));
                            item.SubItems.Add(Convert.ToString(newBook.CategoryId));
                            item.SubItems.Add(Convert.ToString(newBook.Status));
                            listViewOrderLine.Items.Add(item);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please select the Order ID", "Missing Informtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void listViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order order = new Order();

            indexOrder = listViewOrders.FocusedItem.Index;
            if (indexOrder >= 0)
            {
                order = listGeneralOrder[indexOrder];
                textBoxOrderId.Text = Convert.ToString(order.OrderId);
                dateTimePickerOrderDate.Value = order.OrderDate;
                comboBoxOrderType.Text = order.OrderType;
                dateTimePickerRequiredDate.Value = order.RequiredDate;
                dateTimePickerShippingDate.Value = order.ShippingDate;
                switch (order.OrderStatus)
                {
                    case 1:
                        {
                            comboBoxOrderStatus.Text = "In Process";
                            break;
                        }
                    case 2:
                        {
                            comboBoxOrderStatus.Text = "Pending";
                            break;
                        }
                    case 3:
                        {
                            comboBoxOrderStatus.Text = "Completed";
                            break;
                        }
                    case 4:
                        {
                            comboBoxOrderStatus.Text = "Shipped";
                            break;
                        }
                    case 7:
                        {
                            comboBoxOrderStatus.Text = "Cancelled";
                            break;
                        }
                }
                comboBoxCustomer.Text = Convert.ToString(order.CustomerId);
                comboBoxEmployee.Text = Convert.ToString(order.EmployeeId);
                textBoxOrderId.Enabled = false;
                buttonSaveOrder.Enabled = false;
            }


        }

        private void buttonListOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            listGeneralOrder.Clear();
            listGeneralOrder = order.GetAllOrders();
            displayListOrder(listGeneralOrder, listViewOrders);
        }
        public void displayListOrder(List<Order> listO, ListView listV)
        {
            listV.Items.Clear();
            foreach (Order ord in listO)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(ord.OrderId));
                item.SubItems.Add(Convert.ToString(ord.OrderDate.Date.ToString("dd/MM/yyyy")));
                item.SubItems.Add(ord.OrderType);
                item.SubItems.Add(Convert.ToString(ord.RequiredDate.Date.ToString("dd/MM/yyyy")));
                item.SubItems.Add(Convert.ToString(ord.ShippingDate.Date.ToString("dd/MM/yyyy")));
                item.SubItems.Add(Convert.ToString(ord.OrderStatus));
                item.SubItems.Add(Convert.ToString(ord.CustomerId));
                item.SubItems.Add(Convert.ToString(ord.EmployeeId));
                listV.Items.Add(item);
            }
        }

        private void buttonGetBook_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                if (comboBoxBookTitle.Text.Length > 0)
                {

                    foreach (Book book in db.Books)
                    {
                        if (book.BookTitle == comboBoxBookTitle.Text.Trim())
                        {
                            MessageBox.Show($"{book}", "Book Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    listViewOrderLine.Columns.Clear();
                    listViewOrderLine.Items.Clear();

                    listViewOrderLine.Columns.Add("Order ID");
                    listViewOrderLine.Columns.Add("Order Date");
                    listViewOrderLine.Columns.Add("Order Type");
                    listViewOrderLine.Columns.Add("Required Date");
                    listViewOrderLine.Columns.Add("Shipping Date");
                    listViewOrderLine.Columns.Add("Order Status");
                    listViewOrderLine.Columns.Add("Customer ID");
                    listViewOrderLine.Columns.Add("Employee ID");
                    foreach (OrderLine orderLine in db.OrderLines)
                    {
                        if (orderLine.Book.BookTitle == comboBoxBookTitle.Text)
                        {
                            Order newOrder = db.Orders.Find(orderLine.OrderId);
                            ListViewItem item = new ListViewItem(Convert.ToString(newOrder.OrderId));
                            item.SubItems.Add(Convert.ToString(newOrder.OrderId));
                            item.SubItems.Add(newOrder.OrderDate.ToString("dd/MM/yyyy"));
                            item.SubItems.Add(newOrder.OrderType);
                            item.SubItems.Add(newOrder.ShippingDate.ToString("dd/MM/yyyy"));
                            item.SubItems.Add(Convert.ToString(newOrder.OrderStatus));
                            item.SubItems.Add(Convert.ToString(newOrder.CustomerId));
                            item.SubItems.Add(Convert.ToString(newOrder.EmployeeId));
                            listViewOrderLine.Items.Add(item);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please select the Book Title", "Missing Informtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }



        private void buttonUpdateOrder_Click(object sender, EventArgs e)
        {
            if (textBoxOrderId.Text.Length >= 0)
            {
                using (HiTechDBEntities1 db = new HiTechDBEntities1())
                {
                    Order updateOrder = db.Orders.Find(Convert.ToInt32(textBoxOrderId.Text));

                    TimeSpan value = DateTime.Now.Subtract(dateTimePickerOrderDate.Value);
                    int checkValue = (int)value.TotalMinutes;
                    if (checkValue >= 0)
                    {
                        updateOrder.OrderDate = dateTimePickerOrderDate.Value;
                    }
                    else
                    {
                        MessageBox.Show("The Order Date must be in past", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        dateTimePickerOrderDate.Value = DateTime.Now;
                        dateTimePickerRequiredDate.Value = DateTime.Now;
                        dateTimePickerShippingDate.Value = DateTime.Now;
                        comboBoxOrderType.Text = "";
                        comboBoxOrderStatus.Text = "";
                        comboBoxEmployee.Text = "";
                        comboBoxCustomer.Text = "";
                        return;
                    }



                    switch (comboBoxOrderType.Text)
                    {
                        case "By Phone":
                            {
                                updateOrder.OrderType = "By Phone";
                                break;
                            }
                        case "By Fax":
                            {
                                updateOrder.OrderType = "By Fax";
                                break;
                            }
                        case "By Email":
                            {
                                updateOrder.OrderType = "By Email";
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("The Order Type must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                dateTimePickerRequiredDate.Value = DateTime.Now;
                                dateTimePickerShippingDate.Value = DateTime.Now;
                                comboBoxOrderType.Text = "";
                                comboBoxOrderStatus.Text = "";
                                comboBoxEmployee.Text = "";
                                comboBoxCustomer.Text = "";

                                return;
                            }

                    }
                    value = DateTime.Now.Subtract(dateTimePickerRequiredDate.Value);
                    checkValue = (int)value.TotalMinutes;
                    if (checkValue <= 0)
                    {
                        updateOrder.RequiredDate = dateTimePickerRequiredDate.Value;
                    }
                    else
                    {
                        MessageBox.Show("The Required Date must be in future", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        dateTimePickerRequiredDate.Value = DateTime.Now;
                        dateTimePickerShippingDate.Value = DateTime.Now;

                        comboBoxOrderStatus.Text = "";
                        comboBoxEmployee.Text = "";
                        comboBoxCustomer.Text = "";
                        return;
                    }
                    value = DateTime.Now.Subtract(dateTimePickerShippingDate.Value);
                    checkValue = (int)value.TotalMinutes;
                    if (checkValue <= 0)
                    {
                        updateOrder.ShippingDate = dateTimePickerShippingDate.Value;
                    }
                    else
                    {
                        MessageBox.Show("The Shipping Date must be in future", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                        dateTimePickerShippingDate.Value = DateTime.Now;

                        comboBoxOrderStatus.Text = "";
                        comboBoxEmployee.Text = "";
                        comboBoxCustomer.Text = "";
                        return;
                    }

                    switch (comboBoxOrderStatus.Text)
                    {
                        case "In Process":
                            {
                                updateOrder.OrderStatus = 1;
                                break;
                            }
                        case "Pending":
                            {
                                updateOrder.OrderStatus = 2;
                                break;
                            }
                        case "Completed":
                            {
                                updateOrder.OrderStatus = 3;
                                break;
                            }
                        case "Shipped":
                            {
                                updateOrder.OrderStatus = 4;
                                break;
                            }

                        default:
                            {
                                MessageBox.Show("The Order Status must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                comboBoxOrderStatus.Text = "";
                                comboBoxEmployee.Text = "";
                                comboBoxCustomer.Text = "";
                                return;
                            }
                    }
                    if (comboBoxCustomer.Text.Length > 0)
                    {

                        Customer cu = new Customer();
                        cu = db.Customers.Find(Convert.ToInt32(comboBoxCustomer.Text));

                        updateOrder.CustomerId = cu.CustomerId;
                    }
                    else
                    {
                        MessageBox.Show("The Customer ID must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxEmployee.Text = "";
                        comboBoxCustomer.Text = "";

                        return;
                    }
                    if (comboBoxEmployee.Text.Length > 0)
                    {

                        Employee emp = new Employee();
                        emp = db.Employees.Find(Convert.ToInt32(comboBoxEmployee.Text));
                        updateOrder.EmployeeId = emp.EmployeeId;
                    }
                    else
                    {
                        MessageBox.Show("The Employee ID must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxEmployee.Text = "";
                        return;
                    }
                    MessageBox.Show($"{updateOrder}");
                    MessageBox.Show("The Order is updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.SaveChanges();
                    textBoxOrderId.Clear();
                    textBoxOrderId.Focus();
                    dateTimePickerOrderDate.Value = DateTime.Now;
                    dateTimePickerRequiredDate.Value = DateTime.Now;
                    dateTimePickerShippingDate.Value = DateTime.Now;
                    comboBoxOrderType.Text = "";
                    comboBoxOrderStatus.Text = "";
                    comboBoxEmployee.Text = "";
                    comboBoxCustomer.Text = "";
                    textBoxOrderId.Enabled = true;
                    buttonSaveOrder.Enabled = true;
                    listViewOrders.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please select the customer's order first", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void buttonClearOrder_Click(object sender, EventArgs e)
        {
            textBoxOrderId.Clear();
            textBoxOrderId.Focus();
            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerRequiredDate.Value = DateTime.Now;
            dateTimePickerShippingDate.Value = DateTime.Now;
            comboBoxOrderType.Text = "";
            comboBoxOrderStatus.Text = "";
            comboBoxEmployee.Text = "";
            comboBoxCustomer.Text = "";
            textBoxOrderId.Enabled = true;
            buttonSaveOrder.Enabled = true;
            listViewOrders.Items.Clear();
        }

        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                if (textBoxOrderId.Text.Length >= 0)
                {
                    var asking = MessageBox.Show("Do you want to cancel the order you have selected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (asking == DialogResult.Yes)
                    {
                        Order cancelOrder = db.Orders.Find(Convert.ToInt32(textBoxOrderId.Text));
                        cancelOrder.OrderStatus = 7;
                        db.SaveChanges();
                        MessageBox.Show("Customer's order has been cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Please select the customer's order first", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            textBoxOrderId.Clear();
            textBoxOrderId.Focus();
            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerRequiredDate.Value = DateTime.Now;
            dateTimePickerShippingDate.Value = DateTime.Now;
            comboBoxOrderType.Text = "";
            comboBoxOrderStatus.Text = "";
            comboBoxEmployee.Text = "";
            comboBoxCustomer.Text = "";
            textBoxOrderId.Enabled = true;
            buttonSaveOrder.Enabled = true;
            listViewOrders.Items.Clear();

        }

        private void comboBoxSearchOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSearchOrder.Text)
            {
                case "Order ID":
                    {
                        comboBoxSearchOption.Visible = false;
                        dateTimePickerSearch.Visible = false;
                        textBoxSearchOrder.Visible = true;
                        labelDisplayOrder.Text = "Insert Order ID";

                        break;
                    }
                case "Order Date":
                    {
                        comboBoxSearchOption.Visible = false;
                        dateTimePickerSearch.Visible = true;
                        textBoxSearchOrder.Visible = false;
                        labelDisplayOrder.Text = "Select Order Date";
                        break;
                    }
                case "Order Type":
                    {
                        comboBoxSearchOption.Visible = true;
                        dateTimePickerSearch.Visible = false;
                        textBoxSearchOrder.Visible = false;
                        labelDisplayOrder.Text = "Select Order Type";
                        comboBoxSearchOption.Items.Clear();
                        comboBoxSearchOption.Items.Add("By Phone");
                        comboBoxSearchOption.Items.Add("By Fax");
                        comboBoxSearchOption.Items.Add("By Email");
                        break;
                    }
                case "Required Date":
                    {
                        comboBoxSearchOption.Visible = false;
                        dateTimePickerSearch.Visible = true;
                        textBoxSearchOrder.Visible = false;
                        labelDisplayOrder.Text = "Select Required Date";
                        break;
                    }
                case "Shipping Date":
                    {
                        comboBoxSearchOption.Visible = false;
                        dateTimePickerSearch.Visible = true;
                        textBoxSearchOrder.Visible = false;
                        labelDisplayOrder.Text = "Select Shipping Date";
                        break;
                    }
                case "Order Status":
                    {
                        comboBoxSearchOption.Visible = true;
                        dateTimePickerSearch.Visible = false;
                        textBoxSearchOrder.Visible = false;
                        labelDisplayOrder.Text = "Select Order Status";
                        comboBoxSearchOption.Items.Clear();
                        comboBoxSearchOption.Items.Add("In Process");
                        comboBoxSearchOption.Items.Add("Pending");
                        comboBoxSearchOption.Items.Add("Completed");
                        comboBoxSearchOption.Items.Add("Shipped");
                        comboBoxSearchOption.Items.Add("Cancelled");
                        break;
                    }
            }
        }

        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                switch (comboBoxSearchOrder.Text)
                {
                    case "Order ID":
                        {
                            if (textBoxSearchOrder.Text.Trim().Length > 0)
                            {

                                Order searchOrder = null;
                                searchOrder = db.Orders.Find(Convert.ToInt32(textBoxSearchOrder.Text.Trim()));

                                if (searchOrder != null)
                                {
                                    listGeneralOrder.Clear();
                                    listGeneralOrder.Add(searchOrder);
                                    displayListOrder(listGeneralOrder, listViewOrders);
                                }
                                else
                                {
                                    MessageBox.Show("The Order of customer does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please insert the Order ID to search the customer's order", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }

                    case "Order Date":
                        {
                            Order orderDate = new Order();
                            List<Order> listOrderDate = orderDate.GetAllOrders();
                            listGeneralOrder.Clear();
                            bool checkExist = false;

                            foreach (Order checkOrderDate in listOrderDate)
                            {

                                if (checkOrderDate.OrderDate.Date == dateTimePickerSearch.Value.Date)
                                {

                                    listGeneralOrder.Add(checkOrderDate);
                                    checkExist = true;
                                }
                            }
                            if (checkExist)
                            {
                                displayListOrder(listGeneralOrder, listViewOrders);
                            }
                            else
                            {
                                MessageBox.Show("The Order of customer does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                    case "Order Type":
                        {
                            Order orderType = new Order();
                            List<Order> listOrderType = orderType.GetAllOrders();
                            listGeneralOrder.Clear();
                            bool checkExist = false;

                            foreach (Order checkOrderType in listOrderType)
                            {

                                if (checkOrderType.OrderType == comboBoxSearchOption.Text)
                                {

                                    listGeneralOrder.Add(checkOrderType);
                                    checkExist = true;
                                }
                            }
                            if (checkExist)
                            {
                                displayListOrder(listGeneralOrder, listViewOrders);
                            }
                            else
                            {
                                MessageBox.Show("The Order of customer does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;

                        }
                    case "Required Date":
                        {
                            Order requiredDate = new Order();
                            List<Order> listRequiredDate = requiredDate.GetAllOrders();
                            listGeneralOrder.Clear();
                            bool checkExist = false;

                            foreach (Order checkRequiredDate in listRequiredDate)
                            {

                                if (checkRequiredDate.RequiredDate.Date == dateTimePickerSearch.Value.Date)
                                {

                                    listGeneralOrder.Add(checkRequiredDate);
                                    checkExist = true;
                                }
                            }
                            if (checkExist)
                            {
                                displayListOrder(listGeneralOrder, listViewOrders);
                            }
                            else
                            {
                                MessageBox.Show("The Order of customer does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                    case "Shipping Date":
                        {
                            Order shippingDate = new Order();
                            List<Order> listShippingDate = shippingDate.GetAllOrders();
                            listGeneralOrder.Clear();
                            bool checkExist = false;

                            foreach (Order checkShippingDate in listShippingDate)
                            {

                                if (checkShippingDate.ShippingDate.Date == dateTimePickerSearch.Value.Date)
                                {

                                    listGeneralOrder.Add(checkShippingDate);
                                    checkExist = true;
                                }
                            }
                            if (checkExist)
                            {
                                displayListOrder(listGeneralOrder, listViewOrders);
                            }
                            else
                            {
                                MessageBox.Show("The Order of customer does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                    case "Order Status":
                        {
                            Order orderStatus = new Order();
                            List<Order> listOrderStatus = orderStatus.GetAllOrders();
                            listGeneralOrder.Clear();
                            bool checkExist = false;
                            int statusId = -1;
                            switch (comboBoxSearchOption.Text)
                            {
                                case "In Process":
                                    {
                                        statusId = 1;
                                        break;
                                    }
                                case "Pending":
                                    {
                                        statusId = 2;
                                        break;
                                    }
                                case "Completed":
                                    {
                                        statusId = 3;
                                        break;
                                    }
                                case "Shipped":
                                    {
                                        statusId = 4;
                                        break;
                                    }
                                case "Cancelled":
                                    {
                                        statusId = 7;
                                        break;
                                    }

                            }
                            foreach (Order checkOrderStatus in listOrderStatus)
                            {

                                if (checkOrderStatus.OrderStatus == statusId)
                                {

                                    listGeneralOrder.Add(checkOrderStatus);
                                    checkExist = true;
                                }
                            }
                            if (checkExist)
                            {
                                displayListOrder(listGeneralOrder, listViewOrders);
                            }
                            else
                            {
                                MessageBox.Show("The Order of customer does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Select the option to search first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                }
            }
        }

        private void buttonSaveOrderLine_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                OrderLine newOrderLine = new OrderLine();
                if (comboBoxOrderId.Text.Length > 0)
                {
                    newOrderLine.OrderId = Convert.ToInt32(comboBoxOrderId.Text);
                }
                else
                {
                    MessageBox.Show("The Order ID has not been selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBoxBookTitle.Text.Length > 0)
                {
                    foreach (Book currentBook in db.Books)
                    {
                        if (currentBook.BookTitle == comboBoxBookTitle.Text)
                        {
                            newOrderLine.ISBN = currentBook.ISBN;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The Book Title has not been selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (OrderLine checkOrderLine in db.OrderLines)
                {
                    if (checkOrderLine.ISBN == newOrderLine.ISBN && checkOrderLine.OrderId == newOrderLine.OrderId)
                    {
                        MessageBox.Show("The OrderLine has already existed", "Duplicated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                
                if (textBoxQuantityOrdered.Text.Trim().Length > 0)
                {
                    if (Validator.IsNumber(textBoxQuantityOrdered.Text.Trim()))
                    {

                        
                        Book getBook = db.Books.Find(newOrderLine.ISBN);
                        if (getBook.QOH >= Convert.ToInt32(textBoxQuantityOrdered.Text.Trim()))
                        {
                            newOrderLine.QuantityOrdered = Convert.ToInt32(textBoxQuantityOrdered.Text.Trim());
                            getBook.QOH -= Convert.ToInt32(textBoxQuantityOrdered.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("The Quantity on hand does not have enough books", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Quantity Ordered must be integer number", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The Quantity Ordered must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                db.OrderLines.Add(newOrderLine);
                MessageBox.Show("The new Order Line has been added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.SaveChanges();
                textBoxQuantityOrdered.Clear();
                comboBoxOrderId.Focus();
                listViewOrderLine.Items.Clear();
                listViewOrderLine.Columns.Clear();
                listViewOrderLine.Columns.Add("Order ID");
                listViewOrderLine.Columns.Add("ISBN");
                listViewOrderLine.Columns.Add("Quantity Ordered");
                textBoxSearchOrderLine.Clear();
            }
        }

        private void listViewOrderLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrderLine.Columns[2].Text == "Quantity Ordered")
            {
                using (HiTechDBEntities1 db = new HiTechDBEntities1())
                {
                    indexOrderLine = listViewOrderLine.FocusedItem.Index;
                    comboBoxBookTitle.Enabled = false;
                    comboBoxOrderId.Enabled = false;
                    buttonSaveOrderLine.Enabled = false;
                    comboBoxOrderId.Text = Convert.ToString(listGenenalOrderLine[indexOrderLine].OrderId);
                    buttonUpdateOrderLine.Enabled = true;
                    buttonCancelOrderLine.Enabled = true;
                    foreach (Book book in db.Books)
                    {
                        if (book.ISBN == listGenenalOrderLine[indexOrderLine].ISBN)
                        {
                            comboBoxBookTitle.Text = book.BookTitle;
                            break;
                        }
                    }
                    textBoxQuantityOrdered.Text = Convert.ToString(listGenenalOrderLine[indexOrderLine].QuantityOrdered);
                }

            }
        }

        private void buttonUpdateOrderLine_Click(object sender, EventArgs e)
        {
            if (comboBoxOrderId.Text.Length > 0 && comboBoxBookTitle.Text.Length > 0)
            {
                using (HiTechDBEntities1 db = new HiTechDBEntities1())
                {
                    OrderLine newOrderLine = null;
                    string getISBN = null;

                    foreach (Book currentBook in db.Books)
                    {
                        if (currentBook.BookTitle == comboBoxBookTitle.Text)
                        {
                            getISBN = currentBook.ISBN;
                            break;
                        }

                    }

                    newOrderLine = db.OrderLines.Find(Convert.ToInt32(comboBoxOrderId.Text), getISBN);
                    if (newOrderLine != null)
                    {

                        if (textBoxQuantityOrdered.Text.Trim().Length > 0)
                        {
                            if (Validator.IsNumber(textBoxQuantityOrdered.Text.Trim()))
                            {
                                Book book = db.Books.Find(newOrderLine.ISBN);
                                book.QOH += newOrderLine.QuantityOrdered;
                                newOrderLine.QuantityOrdered = Convert.ToInt32(textBoxQuantityOrdered.Text.Trim());
                                book.QOH -= newOrderLine.QuantityOrdered;
                            }
                            else
                            {
                                MessageBox.Show("The Quantity Ordered must be digits", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Quantity Ordered must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        MessageBox.Show("The new Order Line has been updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.SaveChanges();
                        textBoxQuantityOrdered.Clear();
                        textBoxQuantityOrdered.Focus();
                        listViewOrderLine.Items.Clear();
                        listViewOrderLine.Columns.Clear();
                        listViewOrderLine.Columns.Add("Order ID");
                        listViewOrderLine.Columns.Add("ISBN");
                        listViewOrderLine.Columns.Add("Quantity Ordered");
                        textBoxSearchOrderLine.Clear();
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select Order Line to update", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void buttonListOrderLine_Click(object sender, EventArgs e)
        {


            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                listGenenalOrderLine.Clear();
                foreach (OrderLine orderLine in db.OrderLines)
                {
                    listGenenalOrderLine.Add(orderLine);
                }
                DisplayListOrderLine(listGenenalOrderLine, listViewOrderLine);
            }

        }
        public void DisplayListOrderLine(List<OrderLine> listOL, ListView listV)
        {
            textBoxQuantityOrdered.Clear();
            comboBoxOrderId.Focus();
            listViewOrderLine.Items.Clear();
            listViewOrderLine.Columns.Clear();
            listViewOrderLine.Columns.Add("Order ID");
            listViewOrderLine.Columns.Add("ISBN");
            listViewOrderLine.Columns.Add("Quantity Ordered");
            textBoxSearchOrderLine.Clear();
            foreach (OrderLine orderLine in listOL)
            {

                ListViewItem item = new ListViewItem(Convert.ToString(orderLine.OrderId));
                item.SubItems.Add(orderLine.ISBN);
                item.SubItems.Add(Convert.ToString(orderLine.QuantityOrdered));
                listV.Items.Add(item);
            }
        }

        private void buttonClearOrderLine_Click(object sender, EventArgs e)
        {
            textBoxQuantityOrdered.Clear();
            listViewOrderLine.Items.Clear();
            listViewOrderLine.Columns.Clear();
            listViewOrderLine.Columns.Add("Order ID");
            listViewOrderLine.Columns.Add("ISBN");
            listViewOrderLine.Columns.Add("Quantity Ordered");
            textBoxSearchOrderLine.Clear();
            buttonSaveOrderLine.Enabled = true;
            comboBoxBookTitle.Enabled = true;
            comboBoxOrderId.Enabled = true;
            buttonUpdateOrderLine.Enabled = false;
            buttonCancelOrderLine.Enabled = false;

        }

        private void buttonCancelOrderLine_Click(object sender, EventArgs e)
        {
            if (comboBoxOrderId.Text.Length > 0 && comboBoxBookTitle.Text.Length > 0)
            {
                using (HiTechDBEntities1 db = new HiTechDBEntities1())
                {
                    OrderLine newOrderLine = null;
                    string getISBN = null;

                    foreach (Book currentBook in db.Books)
                    {
                        if (currentBook.BookTitle == comboBoxBookTitle.Text)
                        {
                            getISBN = currentBook.ISBN;
                            break;
                        }

                    }

                    newOrderLine = db.OrderLines.Find(Convert.ToInt32(comboBoxOrderId.Text), getISBN);
                    if (newOrderLine != null)
                    {
                        var asking = MessageBox.Show("DO you want to cancel this order line?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (asking == DialogResult.Yes)
                        {

                            MessageBox.Show("The Order Line has been cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Book getBook = db.Books.Find(newOrderLine.ISBN);
                            getBook.QOH += newOrderLine.QuantityOrdered;
                            db.OrderLines.Remove(newOrderLine);
                            db.SaveChanges();
                            textBoxQuantityOrdered.Clear();
                            textBoxQuantityOrdered.Focus();
                            listViewOrderLine.Items.Clear();
                            listViewOrderLine.Columns.Clear();
                            listViewOrderLine.Columns.Add("Order ID");
                            listViewOrderLine.Columns.Add("ISBN");
                            listViewOrderLine.Columns.Add("Quantity Ordered");
                            textBoxSearchOrderLine.Clear();
                        }


                    }

                }
            }
            else
            {
                MessageBox.Show("Please select Order Line to update", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxSearchOrderLine_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxSearchOrderLine.Text)
            {
                case "Order ID":
                    {
                        labelDisplayOrderLine.Text = "Insert Order ID";
                        break;
                    }
                case "Book Title":
                    {
                        labelDisplayOrderLine.Text = "Insert Book Title";
                        break;
                    }

            }


        }

        private void buttonSearchOrderLine_Click(object sender, EventArgs e)
        {
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                switch (comboBoxSearchOrderLine.Text)
                {
                    case "Order ID":
                        {
                            if (textBoxSearchOrderLine.Text.Length > 0)
                            {
                                if (Validator.IsValidId(textBoxSearchOrderLine.Text, textBoxSearchOrderLine.Text.Length))
                                {
                                    bool checkExist = false;
                                    listGenenalOrderLine.Clear();
                                    foreach (OrderLine orderLine in db.OrderLines)
                                    {
                                        if (orderLine.OrderId == Convert.ToInt32(textBoxSearchOrderLine.Text))
                                        {
                                            listGenenalOrderLine.Add(orderLine);
                                            checkExist = true;
                                        }
                                    }
                                    if (checkExist)
                                    {
                                        DisplayListOrderLine(listGenenalOrderLine, listViewOrderLine);
                                    }
                                    else
                                    {
                                        MessageBox.Show("The OrderLine does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The Order ID must be digits", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please insert Order ID to search ", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                    case "Book Title":
                        {
                            if (textBoxSearchOrderLine.Text.Length > 0)
                            {
                                bool checkExist = false;
                                listGenenalOrderLine.Clear();
                                
                                foreach (OrderLine orderLine in db.OrderLines)
                                {
                                    if (orderLine.Book.BookTitle == textBoxSearchOrderLine.Text)
                                    {
                                        listGenenalOrderLine.Add(orderLine);
                                        checkExist=true;
                                    }
                                }
                                if (checkExist)
                                {
                                    DisplayListOrderLine(listGenenalOrderLine, listViewOrderLine);
                                }
                                else
                                {
                                    MessageBox.Show("The OrderLine does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }


                            }
                            else
                            {
                                MessageBox.Show("Please insert Book Title to search ", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Please select the search option first", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                }
            }
        }

        private void buttonToLogin_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit Application and go back to Login?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Back to Login!", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
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
    }
}
