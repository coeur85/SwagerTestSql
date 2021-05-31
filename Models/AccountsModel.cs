using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Models.Accounts
{
   
    public record UserNameModel(int UserID ,string UserName);

    public record LoginModel(int UserID,string Password);

    public record AccountModel(int UserID,string ArabicTitle,string EnglishTitle);
   
    public record LoginSucess(AccountModel Account, string BearerToken);
}
