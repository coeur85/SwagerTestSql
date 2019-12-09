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

        public  string PdaNubConnection()
        {
            return _configuration.GetConnectionString("PdaHub");
        }

        public string BranchLocalDB()
        {
            return _configuration.GetConnectionString("LocalRetail");
        }

        public string ExcelSaveRoot()
        {
            return _configuration.GetSection("ExcelSaveRoot").Value;
        }
    }
}
