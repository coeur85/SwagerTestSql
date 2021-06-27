using PdaHub.Exceptions;
using PdaHub.Models.Accounts;

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
