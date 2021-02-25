using Microsoft.Extensions.Configuration;

namespace PdaHub.Helpers
{
    public class Helper : iHelper

    {
        private readonly IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string PdaHubConnection() =>
            _configuration.GetConnectionString("PdaHub");
        public string BranchLocalDB() =>
            _configuration.GetConnectionString("LocalRetail");
        public string ExcelSaveRoot() =>
          _configuration.GetSection("ExcelSaveRoot").Value;

    }
}
