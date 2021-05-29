using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock
{
    public interface IStockOrderRepository
    {
        Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model, string connectionString);

    }
}