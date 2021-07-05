using PdaHub.Api.Models.Account;
using PdaHub.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Accounts
{
    public interface IAccountsRepository
    {
        Task<List<UserNameModel>> GetAllowedUsersAsync();
        Task<AccountModel> FindActiveAccountAsync(int UserID, string Password);
        Task<List<DocTypeModel>> GetUserPermissionsAsync(int UserID);
    }
}