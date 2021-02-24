using Dapper;
using Microsoft.Data.SqlClient;
using PdaHub.Helpers;
using PdaHub.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly iHelper _iHelper;

        public ItemsRepository(iHelper iHelper)
        {
            _iHelper = iHelper;
        }

        public async Task<PosItemEnitityModel> GetPosItem(string barcode)
        {
            using (IDbConnection connection = new SqlConnection(_iHelper.BranchLocalDB()))
            {
                var output = await connection.QueryFirstOrDefaultAsync<PosItemEnitityModel>("select * from pos_items where barcode = @barcode", new { barcode });
                return output;
            }
        }
        public async Task<ItemSectionEnitiyModel> GetItemSection(string barcode)
        {
            using (IDbConnection connection = new SqlConnection(_iHelper.BranchLocalDB()))
            {
                var output = await connection.QuerySingleAsync<ItemSectionEnitiyModel>(@"select sec.* from sys_section sec inner join  sys_item si on
                                                si.section = sec.section and si.itemclass = sec.itemclass
                                                inner join sys_item_units siu on siu.itemean = si.itemean
                                                where siu.barcode = @barcode", new { barcode });
                return output;
            }
        }
        public async Task<ItemSpecialEnitiyModel> itemSpecial(string barcode)
        {
            using (IDbConnection connection = new SqlConnection(_iHelper.PdaHubConnection()))
            {
                var output = await connection.QueryFirstOrDefaultAsync<ItemSpecialEnitiyModel>
                    ("select * from mkt_item_special where barcode=@barcode", new { barcode });
                return output;
            }
        }

    }
}
