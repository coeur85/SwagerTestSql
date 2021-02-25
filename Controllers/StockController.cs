using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Services;
using System.Threading.Tasks;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class StockController : PdaHubBaseContraoller
    {
        private readonly IStockService _stockService;


        public StockController(IStockService stockService) =>
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
