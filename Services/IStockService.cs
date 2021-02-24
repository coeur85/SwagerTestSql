using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Services
{
    public interface IStockService
    {
        Task<SucessResponseModel> SendUpdate(StockReviewModel model);
    }
}