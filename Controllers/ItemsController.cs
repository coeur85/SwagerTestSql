﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
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
        {
            _itemsServices = itemsServices;
        }

        [HttpGet("{id}")]
        public Task<ResponseModel> Get(string id)
            => TryCatch(async () =>
            {
                var output = await _itemsServices.GetPosItem(id);
                return output;
            });

    }
}
