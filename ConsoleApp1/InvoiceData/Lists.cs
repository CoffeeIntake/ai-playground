namespace InvoiceData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.Odbc;
    using System.Reflection;

    public class ListBase
    {
        public static IEnumerable<T> GetList<T>(string query)
        {
            List<T> results = new List<T>();

            string odbcDriver = @"{TIMBERLINE DATA}";
            string dataFolderPath = @"C:\repos\source\Main\Library Sets\STO\Libraries\Legacy\DemoData\Ext GC DemoData\";
            string userName = "1";
            string password = userName;

            var connectionString = System.String.Format(System.Globalization.CultureInfo.InvariantCulture,
                @"Driver={0};dbq={1};uid={2};pwd={3};codepage=1252;shortennames=0;standardmode=1;maxcolsupport=1536",
                odbcDriver, dataFolderPath, userName, password);

            using (var connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 100;
                        command.CommandText = query;

                        using (var reader = command.ExecuteReader())
                        {   
                            while (reader.Read())
                            {
                                var result = (T)Activator.CreateInstance(typeof(T));
                                var properties = result.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                                try
                                {
                                    // TODO: Check types on the properties I have.  Good to commit for now.
                                    foreach (var property in properties)
                                    {
                                        property.SetValue(result, reader[property.Name.Replace(" ","_")]);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    string message = "Handle errors better: " + ex.ToString();
                                    Console.WriteLine(message);
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    string message = "Handle errors better here, too: " + ex.ToString();
                    Console.WriteLine(message);
                }
                finally
                {
                    connection.Close();
                }
            }


            return results;
        }
    }
}
