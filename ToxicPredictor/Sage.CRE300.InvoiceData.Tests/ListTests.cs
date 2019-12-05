using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Sage.CRE300.InvoiceData;

namespace Sage.CRE300.InvoiceData.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void GetCustomerList()
        {
            var list = Customer.GetList();

            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void GetAgingList()
        {
            var list = AgingData.GetAgingData();

            Assert.IsTrue(list.Count() > 0);

            CsvExporter.Export<AgingData>("Test.csv", list);
        }
    }
}
