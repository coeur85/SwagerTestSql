using PdaHub.Models.Stock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.OrderItems
{
    public interface IStockOrderItems
    {
        Task<List<StockOrderItemsModel>> GetOrderItems(StockReviewModel model, string connectionString);
    }
}