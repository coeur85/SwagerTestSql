using PdaHub.Api.Models.Response;
using PdaHub.Api.Models.Stock;
using PdaHub.Broker.RunAs;
using PdaHub.Helpers;
using PdaHub.Repositories.Stock;
using System.IO;
using System.Threading.Tasks;

namespace PdaHub.Services.Stock
{
    public partial class StockService : IStockService
    {
        private readonly IStockRepository _repo;
        private readonly iHelper _helper;
        private readonly IRunAs _runAs;

        public StockService(IStockRepository repo, iHelper helper, IRunAs runAs)
        {
            _repo = repo;
            _helper = helper;
            _runAs = runAs;
        }


        public Task<SucessResponseModel<StockInOutDetailModel>> SendUpdate(StockReviewModel model) =>
            TryCatch(async () =>
            {
                StockInOutDetailModel data = new StockInOutDetailModel();
                data.StockOrderIn = await _repo.GetOrderDetailAsync(model, _helper.PdaHubConnection());
                if (data.StockOrderIn.StockOrder.Invoicedate.HasValue &&
                data.StockOrderIn.StockOrder.Invoiceno.HasValue)
                {
                    data.StockOrderOut = await _repo.GetOrderDetailAsync(new StockReviewModel
                    {
                        BranchCode = data.StockOrderIn.StockOrder.Sites,
                        DocType = 2052,
                        OrderNo = data.StockOrderIn.StockOrder.Invoiceno.Value,
                        OrderDate = data.StockOrderIn.StockOrder.Invoicedate.Value
                    }, _helper.BranchLocalDB());
                }
                var fileBytes = await SaveToExcelByteArrayAsync(data);
                var filename = GenrateExcelFullFileName(data);
                _runAs.RunAsAdminUser(async () => await SaveBytesToFileAsync(filename, fileBytes));

                return new SucessResponseModel<StockInOutDetailModel>() { Data = data };
            });

        private Task SaveBytesToFileAsync(string name, byte[] bytes) =>
            File.WriteAllBytesAsync(name, bytes);

    }
}
