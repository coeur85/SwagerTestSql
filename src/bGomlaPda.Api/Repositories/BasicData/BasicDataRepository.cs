using PdaHub.Broker.DataAccess;
using PdaHub.Helpers;
using System.Threading.Tasks;

namespace PdaHub.Repositories.BasicData
{
    public class BasicDataRepository : IBasicDataRepository
    {
        private readonly iHelper _helper;
        private readonly ISqlDataAccess _dataAccess;

        public BasicDataRepository(iHelper helper, ISqlDataAccess dataAccess)
        {
            _helper = helper;
            _dataAccess = dataAccess;
        }
        public async Task<string> GetBarcodeItemNameAsync(string barcode)
        {


            var output = await _dataAccess.QuerySingleAsync<string, dynamic>(_helper.BranchLocalDB(), "select i.a_name from sys_item i inner " +
                "join sys_item_units iu on i.itemean = iu.itemean where iu.barcode = @barcode ", new { barcode });

            return output;

        }
        public async Task<string> GetBranchNameAsync(int branchCode)
        {

            var output = await _dataAccess.QuerySingleAsync<string, dynamic>(_helper.BranchLocalDB()
                , "select a_name from sys_branch where branch" +
                " = @branchCode", new { branchCode });
            return output;

        }
        public async Task<string> GetUnitNameAsync(int unit)
        {

            var output = await _dataAccess.QuerySingleAsync<string, dynamic>(_helper.BranchLocalDB(), "select a_name from sys_unit where unit" +
                " = @unit", new { unit });
            return output;

        }
    }
}
