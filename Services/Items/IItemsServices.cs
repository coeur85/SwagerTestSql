using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Services.Items
{
    public interface IItemsServices
    {
        Task<SucessResponseModel<ItemDetailsResponseModel>> GetPosItemAsync(string barcode);
        Task<SucessResponseModel<PromotionItemsReponseModel>> GetPromotionItemsAsync(string DiscountNo);
    }
}