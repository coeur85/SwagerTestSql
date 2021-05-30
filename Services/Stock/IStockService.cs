using PdaHub.Models;
using PdaHub.Models.Stock;
using System.Threading.Tasks;

namespace PdaHub.Services.Stock
{
    public interface IStockService
    {
        Task<SucessResponseModel<StockInOutDetailModel>> SendUpdate(StockReviewModel model);
    }
}