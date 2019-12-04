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
            object value;

            var connectionString = Configuration.Instance.GetConnectionString();

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
                                        value = reader[property.Name];

                                        if (property.PropertyType == typeof(string))
                                            property.SetValue(result, value.ToString());
                                        else if (property.PropertyType == typeof(int))
                                            property.SetValue(result, (int)value);
                                        else if (property.PropertyType == typeof(double))
                                            property.SetValue(result, (double)value);
                                    }

                                    results.Add(result);
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
