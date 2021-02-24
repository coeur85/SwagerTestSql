using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Repositories
{
    public interface IItemsRepository
    {
        Task<ItemSectionEnitiyModel> GetItemSection(string barcode);
        Task<PosItemEnitityModel> GetPosItem(string barcode);
        Task<ItemSpecialEnitiyModel> itemSpecial(string barcode);
    }
}