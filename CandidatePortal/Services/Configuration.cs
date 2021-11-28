using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CandidatePortal.Services
{
    public class Configuration
    {
        private readonly IConfiguration _config;

        public Configuration(IConfiguration config)
        {
            _config = config;
        }
        public string GetConnectionString()
        {
            string strconnect = _config.GetValue<string>("ConnectionStrings:DefaultConnection:"); 
            return strconnect;
        }
    }
}
