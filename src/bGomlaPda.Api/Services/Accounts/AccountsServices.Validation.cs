using PdaHub.Api.Models.Account;
using PdaHub.Exceptions;

namespace PdaHub.Services.Accounts
{
    public partial class AccountsServices
    {
        public void ValidateLoginAccount(AccountModel model)
        {
            if (model is null)
                throw new InvalidLoginCredentialsExceptions();
        }
    }
}
