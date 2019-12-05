namespace Sage.CRE300.InvoiceData
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

            var connectionString = Configuration.Instance.GetConnectionString(Configuration.DataSources.Consigli);

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
                                        Type valueType = value.GetType();

                                        try
                                        { 
                                            if (value != DBNull.Value)
                                            {
                                                if (property.PropertyType == typeof(string))
                                                    property.SetValue(result, value.ToString());
                                                else if (property.PropertyType == typeof(Int32))
                                                    property.SetValue(result, (Int32)value);
                                                else if (property.PropertyType == typeof(Int64))
                                                    property.SetValue(result, (Int64)value);
                                                else if (property.PropertyType == typeof(double))
                                                    property.SetValue(result, (double)value);
                                                else if (property.PropertyType == typeof(DateTime))
                                                    property.SetValue(result, (DateTime)value);
                                                else if (property.PropertyType == typeof(DateTime?))
                                                {
                                                    if (value != DBNull.Value)
                                                    {
                                                        property.SetValue(result, (DateTime?)value);
                                                    }
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Unable to assign {property.Name} (Type: {valueType.ToString()}): {ex.ToString()}");
                                        }
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
