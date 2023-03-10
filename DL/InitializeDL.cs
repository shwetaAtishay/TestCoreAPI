using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DL
{
    public  class InitializeDL
    {
        public static string connectionString;
        public static string queryString;
        public static IConfiguration _configuration;
        //public  InitializeDL(IConfiguration configuration)
        //{
        //    _configuration = configuration;



        //}
        public static string Databasestring()
        {
            connectionString = _configuration.GetConnectionString("DBCS");
            return connectionString;
        }
    }
}
