using PdaHub.Exceptions;
using PdaHub.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
