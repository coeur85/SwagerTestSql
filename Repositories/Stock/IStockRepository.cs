using PdaHub.Models;
using PdaHub.Models.Stock;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock
{
    public interface IStockRepository
    {
        Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model, string connectionString);

    }
}