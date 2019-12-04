using System;
using System.Collections.Generic;
using InvoiceData;

namespace InvoiceDataTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new Configuration
            //{
            //    DataFolderPath = "C:\\repos\\source\\Main\\Library Sets\\STO\\Libraries\\Legacy\\DemoData\\Ext GC DemoData",
            //    UserName = "1",
            //    Password = "1"
            //};

            //config.Save();
            string query = "SELECT * FROM [ABM_MASTER__CONTACT]";
            var customer = InvoiceData.ListBase.GetList<Customer>(query);
        }
    }
}
