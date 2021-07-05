using PdaHub.Models.Item;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Items
{
    public interface IItemsRepository
    {
        Task<ItemSectionEnitiyModel> GetItemSectionAsync(string barcode);
        Task<PosItemEnitityModel> GetPosItemAsync(string barcode);
        Task<ItemSpecialEnitiyModel> ItemSpecialAsync(string barcode);
        Task<List<PosItemEnitityModel>> GetItemsInPromo(int DiscountNo);
    }
}