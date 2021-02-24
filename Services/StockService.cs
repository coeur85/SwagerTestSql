using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Repositories;
using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Services
{
    public partial class StockService : IStockService
    {
        private readonly IStockRepository _stockReository;
        private readonly iHelper _helper;
        public StockService(IStockRepository stockReository, iHelper helper)
        {
            _stockReository = stockReository;
            _helper = helper;
        }


        public Task<SucessResponseModel> SendUpdate(StockReviewModel model) =>
            TryCatch(async () =>
            {
                var data = await _stockReository.GetInOutOrderDetailAsync(model);
              

                var credentials = new UserCredentials(@"bGomla\sql.svc", @"PkJ)A96y3q\^41@<;Fu3Zh4J/NT.to");
               

                Impersonation.RunAsUser(credentials, LogonType.NetworkCleartext, () =>
                {
                    SaveToExcel(data);
                });
                return new SucessResponseModel { Data = data };
            });
        private void RunAsAdminUser(StockInOutDetailModel model)
        {
           var credentials = new UserCredentials(@"bGomla\sql.svc", @"PkJ)A96y3q\^41@<;Fu3Zh4J/NT.to");
          // var credentials = new UserCredentials(@"bGomla\am.dadmin", @"Az0103061!");

            Impersonation.RunAsUser(credentials, LogonType.NetworkCleartext, () =>
            {
                // model();
                SaveToExcel(model);
            });

        }

    }
}
