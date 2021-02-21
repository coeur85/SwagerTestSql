using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Repositories
{
    public interface IStockDataRepository
    {
        Task<StockInOutDetailModel> GetInOutOrderDetailAsync(StockReviewModel model);
        Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model, string connectionString);
        void SaveToExcel(StockInOutDetailModel model);
    }
}