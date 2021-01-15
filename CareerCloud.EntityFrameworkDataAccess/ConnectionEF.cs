using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CareerCloud.EntityFrameworkDataAccess
{
   public  class ConnectionEF
    {
       
            public readonly string _connStr = string.Empty;
            public ConnectionEF()
            {
                var config = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                config.AddJsonFile(path, false);
                var root = config.Build();
                _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            }
    }
    
}
