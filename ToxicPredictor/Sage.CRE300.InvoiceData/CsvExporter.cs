namespace Sage.CRE300.InvoiceData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.IO;

    public class CsvExporter
    {
        public static void Export<T>(string path, IEnumerable<T> list)
        {
            T model = (T)Activator.CreateInstance(typeof(T));
            var records = GetHeader(model) + "\r\n";
            
            records += GetValues<T>(model, list);

            SendToCsv(path, records);
        }

        private static string GetHeader(object model)
        {
            var type = model.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string header = "";
            
            foreach(var property in properties)
            {
                if (header.Length > 0)
                {
                    header += ",";
                }

                header += $"\"{property.Name}\"";
            }

            return header;
        }

        private static string GetValues<T>(object model, IEnumerable<T> list)
        {
            var type = model.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string results = "";
            string rowValues = "";

            foreach(var item in list)
            {
                foreach(var property in properties)
                {
                    if (rowValues.Length > 0)
                    {
                        rowValues += ",";
                    }

                    if (property.PropertyType == typeof(string))
                    {
                        rowValues += $"\"{item.GetType().GetProperty(property.Name).GetValue(item, null)}\"";
                    }
                    else
                    {
                        var value = item.GetType().GetProperty(property.Name).GetValue(item, null);

                        if (value == null)
                        {
                            rowValues += "";
                        }
                        else
                        { 
                            rowValues += item.GetType().GetProperty(property.Name).GetValue(item, null).ToString();
                        }
                    }
                }

                if (results.Length > 0)
                {
                    results += "\r\n";
                }

                results += rowValues;
                rowValues = "";
            }

            return results;
        }

        private static void SendToCsv(string path, string textToWrite)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.Write(textToWrite);
                sw.Close();
            }
        }
    }
}
