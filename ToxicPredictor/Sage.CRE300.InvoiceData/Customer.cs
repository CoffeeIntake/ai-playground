namespace Sage.CRE300.InvoiceData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Customer
    {
        public string Contact_ID { get; set; }
        public string Contact_name { get; set; }
        public string Type { get; set; }

        public static IEnumerable<Customer> GetList()
        {
            var list = ListBase.GetList<Customer>("SELECT * FROM [ABM_MASTER__CONTACT]");

            return list;
        }
    }
}
