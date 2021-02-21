using System.Threading.Tasks;

namespace PdaHub.Repositories
{
    public interface IBasicDataRepository
    {
        Task<string> GetBarcodeItemNameAsync(string barcode);
        Task<string> GetBranchNameAsync(int branchCode);
        Task<string> GetUnitNameAsync(int unit);
    }
}