using PdaHub.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Accounts
{
    public interface IAccountsRepository
    {
        Task<List<UserNameModel>> GetAllowedUsersAsync();
    }
}