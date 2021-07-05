using PdaHub.Api.Models.Response;
using PdaHub.Api.Models.Stock;
using System.Threading.Tasks;

namespace PdaHub.Services.Stock
{
    public interface IStockService
    {
        Task<SucessResponseModel<StockInOutDetailModel>> SendUpdate(StockReviewModel model);
    }
}