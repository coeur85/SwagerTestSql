using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Repositories.Stock;
using PdaHub.Services.Stock;
using SimpleImpersonation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PdaHub.Services.Stock
{
    public partial class StockService : IStockService
    {
        private readonly IStockOrderRepository _stockReository;
        private readonly iHelper _helper;
        public StockService(IStockOrderRepository stockReository, iHelper helper)
        {
            _stockReository = stockReository;
            _helper = helper;
        }


        public Task<SucessResponseModel<StockInOutDetailModel>> SendUpdate(StockReviewModel model) =>
            TryCatch(async () =>
            {
                var data = await _stockReository.GetInOutOrderDetailAsync(model);
                var fileBytes = await SaveToExcelByteArrayAsync(data);
                var filename = GenrateExcelFullFileName(data);
                RunAsAdminUser(async () => await SaveBytesToFileAsync(filename, fileBytes));

                return new SucessResponseModel<StockInOutDetailModel>() { Data = data };
            });
        private void RunAsAdminUser(Action model)
        {
            var credentials = new UserCredentials(@"bGomla\sql.svc", @"PkJ)A96y3q\^41@<;Fu3Zh4J/NT.to");
            Impersonation.RunAsUser(credentials, LogonType.NetworkCleartext, () =>
            {
                model();
            });

        }
        private Task SaveBytesToFileAsync(string name, byte[] bytes) =>
            File.WriteAllBytesAsync(name, bytes);

    }
}
