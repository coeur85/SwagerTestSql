using PdaHub.Api.Models.Stock;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.Order
{
    public interface IStockOrder
    {
        Task<StockOrderModel> GetOrderAsync(StockReviewModel model, string connectionString);
    }
}