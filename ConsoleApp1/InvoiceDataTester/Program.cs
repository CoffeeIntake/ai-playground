using System;
using System.Collections.Generic;
using InvoiceData;

namespace InvoiceDataTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = "SELECT * FROM [ABM_MASTER__CONTACT]";
            var customer = InvoiceData.ListBase.GetList<Customer>(query);
        }
    }
}
