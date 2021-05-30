using Microsoft.AspNetCore.Mvc;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Controllers
{
    public class AccountsController : PdaHubBaseContraoller
    {
        private readonly IAccountsServices _services;
        public AccountsController(IAccountsServices services)
            => _services = services;
        

        [HttpGet]
        public Task<ActionResult<SucessResponseModel<ItemDetailsResponseModel>>> Get(string barcode)
            => TryCatch<ItemDetailsResponseModel>(async () =>
            {
                var output = await _services.GetAllowdUsersAsync();
                return Ok(output);
            });
    }
}
