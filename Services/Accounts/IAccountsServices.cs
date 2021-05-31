using PdaHub.Models;
using PdaHub.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Services.Accounts
{
    public interface IAccountsServices
    {
        Task<SucessResponseModel<List<UserNameModel>>> GetAllowdUsersAsync();
        Task<SucessResponseModel<LoginSucess>> LoginAsync(LoginModel model);
    }
}