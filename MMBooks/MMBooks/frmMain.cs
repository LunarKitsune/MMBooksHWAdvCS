using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBooks
{
    public partial class frmMain : Form
    {
        BookData clsBookData;
        BindingSource customerSource;
        BindingSource invoiceSource;
        MMABooksDataSet bookDataSet;


        Boolean gridInitialized = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initializes the data set with two tables
            clsBookData = new BookData();
            bookDataSet = clsBookData.GetDataSet();

            //initializes the sources and references the table customers
            customerSource = new BindingSource();
            customerSource.DataSource = bookDataSet;
            customerSource.DataMember = "Customers";

            //initializes the source and references the table invoices
            invoiceSource = new BindingSource();
            invoiceSource.DataSource = bookDataSet;
            invoiceSource.DataMember = "Invoices";

            //the data source 
            txtName.DataSource = bookDataSet.Tables[0];
            txtName.DisplayMember = "Name";
            txtName.ValueMember = "CustomerID";

            txtCustomerID.DataBindings.Add("Text", customerSource, "CustomerID");
            txtAddress.DataBindings.Add("Text", customerSource, "Address");
            txtCity.DataBindings.Add("Text", customerSource, "City");
            txtState.DataBindings.Add("Text", customerSource, "State");
            txtZip.DataBindings.Add("Text", customerSource, "ZipCode");

            txtName_SelectionChangeCommitted(txtName, e);
        }


        private void txtName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string IDSelected;
            IDSelected = Convert.ToString(txtName.SelectedValue);

            if(!gridInitialized)
            {
                dgvInvoices.DataSource = invoiceSource;
                gridInitialized = true;
            }

            invoiceSource.Filter = $"CustomerID = '{IDSelected}'";
            customerSource.Filter = $"CustomerID = '{IDSelected}'";
            
        }
    }
}
