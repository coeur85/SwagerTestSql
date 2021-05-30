using PdaHub.Models;
using PdaHub.Models.Accounts;
using PdaHub.Repositories.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PdaHub.Services.Accounts
{
    public partial class AccountsServices : IAccountsServices
    {
        private readonly IAccountsRepository _repo;

        public AccountsServices(IAccountsRepository repository)
        {
            _repo = repository;
        }


        public Task<SucessResponseModel<List<UserNameModel>>> GetAllowdUsersAsync()
            => TryCatch(async () =>
            {
                var users = await _repo.GetAllowedUsersAsync();
                SucessResponseModel<List<UserNameModel>> output = new();
                output.Data = users;
                return output;
            });

    }
}
