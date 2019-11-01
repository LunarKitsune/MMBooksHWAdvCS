using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBooks
{
    class BookData
    {
        MMABooksDataSetTableAdapters.CustomersTableAdapter customerAdapter;
        MMABooksDataSetTableAdapters.InvoicesTableAdapter invoiceAdapter;
        MMABooksDataSet dataSet;

        public MMABooksDataSet GetDataSet()
        {
            customerAdapter = new MMABooksDataSetTableAdapters.CustomersTableAdapter();
            invoiceAdapter = new MMABooksDataSetTableAdapters.InvoicesTableAdapter();
            dataSet = new MMABooksDataSet();

            customerAdapter.Fill(dataSet.Customers);
            invoiceAdapter.Fill(dataSet.Invoices);

            return dataSet;
        }

    }
}
