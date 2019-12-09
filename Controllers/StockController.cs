using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdaHub.DataAccess;
using PdaHub.Models;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class StockController : ControllerBase
    {
        private readonly StockData _stockData;

        public StockController(StockData stockData)
        {
            _stockData = stockData;
        }
    
    [HttpGet]
      public string Get()
      {
          return "Stock Controller Get method";
      }


      [HttpPost]
    //  [Route("StockReview")]
      //public int Post ( StockReviewModel model){

      //      Task.Run(() => sendUpdate(model)); 

      //  return 1;
      //}

        [HttpPost]
        public async Task<StockInOutDetailModel> sendUpdate(StockReviewModel model)
        {

            var data = await _stockData.GetInOutOrderDetailAsync(model);
            _stockData.SaveToExcel(data);

            return data;
        }

        

    }
}
