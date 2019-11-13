namespace InvoiceData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class Configuration
    {
        private static readonly string _driver = @"{TIMBERLINE DATA}";        
        private static readonly string _configPath = "config.json";

        private static Configuration _instance;

        public static Configuration Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = LoadConfig();                    
                }
                return _instance; 
            }
        }

        public string DataFolderPath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string GetConnectionString()
        {
            var cs = System.String.Format(System.Globalization.CultureInfo.InvariantCulture,
                        @"Driver={0};dbq={1};uid={2};pwd={3};codepage=1252;shortennames=0;standardmode=1;maxcolsupport=1536",
                        _driver, DataFolderPath, UserName, Password);
            return cs;
        }

        public void Save()
        {
            using (var writer = new System.IO.StreamWriter(_configPath))
            {
                var contents = JsonConvert.SerializeObject(this);
                writer.Write(contents);
            }
        }

        private static Configuration LoadConfig()
        {
            Configuration configuration;
            
            if (!System.IO.File.Exists(_configPath))
            {
                var config = new Configuration();
                config.Save();
            }

            using (var reader = new System.IO.StreamReader(_configPath))
            {
                var contents = reader.ReadToEnd();
                configuration = JsonConvert.DeserializeObject<Configuration>(contents);
            }
            
            return configuration;
        }

        
    }
}
