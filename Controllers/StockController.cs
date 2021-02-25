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
       

        public StockController(IStockService stockService)=>
            _stockService = stockService;
           
        
    
        [HttpGet]
        public string Get()
          {
              return "Stock Controller Get method";
          }
       
        [HttpPost]
        public Task<ResponseModel> SendUpdate(StockReviewModel model)
            => TryCatch(async () =>
            {
                var output = await _stockService.SendUpdate(model);
                return output;
            });


    }
}
