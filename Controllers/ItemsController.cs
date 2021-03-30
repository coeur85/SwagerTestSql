using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Services;
using System.Net;
using System.Threading.Tasks;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ItemsController : PdaHubBaseContraoller
    {
        private readonly IItemsServices _itemsServices;

        public ItemsController(IItemsServices itemsServices)
            => _itemsServices = itemsServices;


        [HttpGet("{barcode}")]
        [ProducesResponseType(typeof(SucessResponseModel<ItemDetailsResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        public Task<ActionResult<SucessResponseModel<ItemDetailsResponseModel>>> Get(string barcode)
            => TryCatch<ItemDetailsResponseModel>(async () =>
            {
                var output = await _itemsServices.GetPosItem(barcode);
                return Ok(output);
            });


    }
}
