using PdaHub.Api.Models.Response;
using PdaHub.Api.Models.Stock;
using System;
using System.Threading.Tasks;

namespace PdaHub.Services.Stock
{
    public partial class StockService
    {
        private delegate Task<SucessResponseModel<StockInOutDetailModel>> SendUpdateDelegate();
        private async Task<SucessResponseModel<StockInOutDetailModel>> TryCatch(SendUpdateDelegate model)
        {
            try
            {
                return await model();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
