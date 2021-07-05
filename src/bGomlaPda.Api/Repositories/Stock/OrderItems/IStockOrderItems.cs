using PdaHub.Api.Models.Stock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Stock.OrderItems
{
    public interface IStockOrderItems
    {
        Task<List<StockOrderItemsModel>> GetOrderItemsAsync(StockReviewModel model, string connectionString);
    }
}