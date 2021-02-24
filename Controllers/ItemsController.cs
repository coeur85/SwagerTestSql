using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        {
            _itemsServices = itemsServices;
        }

        [HttpGet("{id}")]
        public Task<ResponseModel> Get(string id)
            => TryCatch(async ()=> {
                var output = await _itemsServices.GetPosItem(id);
                return output;
            });
        
    }
}
