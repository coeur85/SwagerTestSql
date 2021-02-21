using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Helpers
{
    public class Helper : iHelper

    {
        private readonly IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  string PdaNubConnection() => 
            _configuration.GetConnectionString("PdaHub");
        public string BranchLocalDB() =>
            _configuration.GetConnectionString("LocalRetail");
        public string ExcelSaveRoot() =>
          _configuration.GetSection("ExcelSaveRoot").Value;
        
    }
}
