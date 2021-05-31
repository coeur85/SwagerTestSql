using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdaHub.Helpers;
using PdaHub.Models;
using PdaHub.Models.Accounts;
using PdaHub.Services.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Controllers
{

    [ApiController]
    [Route("[controller]")]
   
    public class AccountsController : PdaHubBaseContraoller
    {
        private readonly IAccountsServices _services;
        public AccountsController(IAccountsServices services)
            => _services = services;


        [HttpGet]
        public Task<ActionResult<SucessResponseModel<List<UserNameModel>>>> Get()
            => TryCatch<List<UserNameModel>>(async () =>
            {
                var output = await _services.GetAllowdUsersAsync();
                return Ok(output);
            });
        [HttpPost("login")]
        public Task<ActionResult<SucessResponseModel<LoginSucess>>> Login(LoginModel model)
            => TryCatch<LoginSucess>(async () =>
            {
                var output = await _services.LoginAsync(model);
                return Ok(output);
            });
      
        [HttpGet("Permissions")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<ActionResult<SucessResponseModel<string>>> Permissions()
         => TryCatch<string>(async () =>
         {
             SucessResponseModel<string> sucessResponseModel = new SucessResponseModel<string>();
             sucessResponseModel.Data = User.Identity.Name;
             return Ok(sucessResponseModel);
         });


    }
}
