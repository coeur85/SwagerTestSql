using PdaHub.Models;
using PdaHub.Models.Accounts;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PdaHub.Services.Accounts
{
    public interface IAccountsServices
    {
        Task<SucessResponseModel<List<UserNameModel>>> GetAllowdUsersAsync();
        Task<SucessResponseModel<LoginSucessModel>> LoginAsync(LoginModel model);
        Task<SucessResponseModel<List<DocTypeModel>>> PermissionsAsync(ClaimsPrincipal User);
    }
}