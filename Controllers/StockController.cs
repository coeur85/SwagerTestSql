using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdaHub.Repositories;
using PdaHub.Models;
using SimpleImpersonation;
using PdaHub.Helpers;
using PdaHub.Services;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
        public class StockController : PdaHubBaseContraoller
        {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
            {
            _stockService = stockService;
        }
    
        [HttpGet]
        public string Get()
          {
              return "Stock Controller Get method";
          }
        //[HttpPost]
        //public async Task<StockInOutDetailModel> sendUpdate(StockReviewModel model)
        //    {
        //        var data = await _stockData.GetInOutOrderDetailAsync(model);
        //        var credentials = new UserCredentials(@"bGomla\sql.svc", @"PkJ)A96y3q\^41@<;Fu3Zh4J/NT.to");
        //        Impersonation.RunAsUser(credentials, LogonType.NetworkCleartext, () =>
        //        {
        //            _stockData.SaveToExcel(data);
        //        });
        //        return data;
        //    }
        [HttpPost]
        public  Task<ResponseModel> SendUpdate(StockReviewModel model)
            => TryCatch(async () => {
                var output = await _stockService.SendUpdate(model);
                return output;
            });
        

    }
}
