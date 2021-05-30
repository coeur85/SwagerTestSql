using Microsoft.Extensions.Configuration;
using PdaHub.Broker.DataAccess;
using System.Threading.Tasks;

namespace PdaHub.Helpers
{
    public class Helper : iHelper

    {
        private readonly IConfiguration _configuration;
        private readonly ISqlDataAccess _dataAccess;
        private int BranchCode { get; set; }

        public Helper(IConfiguration configuration , ISqlDataAccess dataAccess)
        {
            _configuration = configuration;
            _dataAccess = dataAccess;
            BranchCode = 0;
        }

        public string PdaHubConnection() =>
            _configuration.GetConnectionString("PdaHub");
        public string BranchLocalDB() =>
            _configuration.GetConnectionString("LocalRetail");
        public string ExcelSaveRoot() =>
          _configuration.GetSection("ExcelSaveRoot").Value;
        public async ValueTask<int> GetBranchCodeAsync()
        {
            if(BranchCode == 0)
                BranchCode= await _dataAccess.QuerySingleAsync<int>(BranchLocalDB(), "select setting  from sys_setup where parameter  = 'cbranch'");

            return BranchCode;
        }

    }
}
