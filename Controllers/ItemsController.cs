using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Services.Items;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ItemsController : PdaHubBaseContraoller
    {
        private readonly IItemsServices _itemsServices;

        public ItemsController(IItemsServices itemsServices)
            => _itemsServices = itemsServices;


        [HttpGet("{barcode}")]
        [ProducesResponseType(typeof(SucessResponseModel<ItemDetailsResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        public Task<ActionResult<SucessResponseModel<ItemDetailsResponseModel>>> GetItemAsync(string barcode)
            => TryCatch<ItemDetailsResponseModel>(async () =>
            {
                var output = await _itemsServices.GetPosItemAsync(barcode);
                return Ok(output);
            });

        

        [HttpGet("Promotion/{SearchCode}")]
        [ProducesResponseType(typeof(SucessResponseModel<ItemDetailsResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        public Task<ActionResult<SucessResponseModel<PromotionItemsReponseModel>>> GetPromotionItmesAsync(string SearchCode)
            => TryCatch<PromotionItemsReponseModel>(async () =>
            {
                var output = await _itemsServices.GetPromotionItemsAsync(SearchCode);
                return Ok(output);
            });
    }
}
