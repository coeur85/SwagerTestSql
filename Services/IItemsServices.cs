using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Services
{
    public interface IItemsServices
    {
        Task<SucessResponseModel> GetPosItem(string barcode);
    }
}