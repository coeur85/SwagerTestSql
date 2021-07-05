using PdaHub.Models.Stock;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.Order
{
    public interface IStockOrder
    {
        Task<StockOrderModel> GetOrder(StockReviewModel model, string connectionString);
    }
}