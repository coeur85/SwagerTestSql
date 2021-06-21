using PdaHub.Broker.DataAccess;
using PdaHub.Helpers;
using PdaHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Items
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly iHelper _iHelper;
        private readonly ISqlDataAccess _sqlData;

        public ItemsRepository(iHelper iHelper, ISqlDataAccess sqlData)
        {
            _iHelper = iHelper;
            _sqlData = sqlData;
        }

        public async Task<PosItemEnitityModel> GetPosItemAsync(string barcode)
        {

            var output = await _sqlData.QueryFirstOrDefaultAsync<PosItemEnitityModel, dynamic>(_iHelper.BranchLocalDB(),
                "select * from pos_items where barcode = @barcode", new { barcode });
            return output;

        }
        public async Task<ItemSectionEnitiyModel> GetItemSectionAsync(string barcode)
        {

            var output = await _sqlData.QueryFirstOrDefaultAsync<ItemSectionEnitiyModel, dynamic>(_iHelper.BranchLocalDB(),
                @"select sec.* from sys_section sec inner join  sys_item si on
                                                si.section = sec.section and si.itemclass = sec.itemclass
                                                inner join sys_item_units siu on siu.itemean = si.itemean
                                                where siu.barcode = @barcode", new { barcode });
            return output;

        }
        public async Task<ItemSpecialEnitiyModel> ItemSpecialAsync(string barcode)
        {

            var output = await _sqlData.QueryFirstOrDefaultAsync<ItemSpecialEnitiyModel, dynamic>(_iHelper.PdaHubConnection(),
                "select * from mkt_item_special where barcode=@barcode", new { barcode });
            return output;
        }
        public async Task<List<PosItemEnitityModel>> GetItemsInPromo(int PromotionCode)
        {
            var output = await _sqlData.QueryFirstOrDefaultAsync<PosItemEnitityModel, dynamic>(_iHelper.BranchLocalDB(),
                "select * from pos_items where barcode = @barcode", new { barcode });
            return output;
        }
    }

}

