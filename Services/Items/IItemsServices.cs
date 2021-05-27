using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Services.Items
{
    public interface IItemsServices
    {
        Task<SucessResponseModel<ItemDetailsResponseModel>> GetPosItem(string barcode);
    }
}