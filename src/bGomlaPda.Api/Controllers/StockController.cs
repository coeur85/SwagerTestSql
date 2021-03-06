using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdaHub.Api.Models.Response;
using PdaHub.Api.Models.Stock;
using PdaHub.Helpers;
using PdaHub.Models.Item;
using PdaHub.Services.Stock;
using System.Net;
using System.Threading.Tasks;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    /// [ApiExplorerSettings(IgnoreApi = true)]
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
        [ProducesResponseType(typeof(SucessResponseModel<ItemDetailsResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        public Task<ActionResult<SucessResponseModel<StockInOutDetailModel>>> SendUpdate(StockReviewModel model)
            => TryCatch<StockInOutDetailModel>(async () =>
            {
                var output = await _stockService.SendUpdate(model);
                return Ok(output);
            });


    }
}
