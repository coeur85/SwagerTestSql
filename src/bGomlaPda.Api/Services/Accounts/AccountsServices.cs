using Microsoft.IdentityModel.Tokens;
using PdaHub.Api.Models.Account;
using PdaHub.Api.Models.Response;
using PdaHub.Helpers;
using PdaHub.Models.Accounts;
using PdaHub.Repositories.Accounts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PdaHub.Services.Accounts
{
    public partial class AccountsServices : IAccountsServices
    {
        private readonly IAccountsRepository _repo;
        private readonly string _secret;

        public AccountsServices(IAccountsRepository repository, iHelper helper)
        {
            _repo = repository;
            _secret = helper.AuthSecret();
        }

        public Task<SucessResponseModel<List<UserNameModel>>> GetAllowdUsersAsync()
            => TryCatch(async () =>
            {
                var users = await _repo.GetAllowedUsersAsync();
                SucessResponseModel<List<UserNameModel>> output = new();
                output.Data = users;
                return output;
            });
        public Task<SucessResponseModel<LoginSucessModel>> LoginAsync(LoginModel model)
            => TryCatch(async () =>
            {
                var encPass = EncString(model.Password);
                var accouut = await _repo.FindActiveAccountAsync(model.UserID, encPass);
                ValidateLoginAccount(accouut);
                string token = GenrateToken(accouut);
                LoginSucessModel login = new LoginSucessModel(accouut, token);
                return new SucessResponseModel<LoginSucessModel> { Data = login };
            });
        public Task<SucessResponseModel<List<DocTypeModel>>> PermissionsAsync(ClaimsPrincipal User)
           => TryCatch(async () =>
           {
               int userid = Convert.ToInt32(User.FindFirst("Id").Value);
               var output = await _repo.GetUserPermissionsAsync(userid);
               return new SucessResponseModel<List<DocTypeModel>> { Data = output };
           });




        private string GenrateToken(AccountModel model)
        {

            var key = Encoding.ASCII.GetBytes(_secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("Id", model.UserID.ToString()),
                        new Claim(JwtRegisteredClaimNames.NameId,model.ArabicTitle),
                        new Claim(JwtRegisteredClaimNames.GivenName, model.EnglishTitle)

                }),

                Expires = DateTime.Now.AddHours(2),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature),

            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        private string EncString(string str)
        {
            string result = string.Empty;
            char[] crAr = str.ToCharArray();
            int charCode = 0;
            for (int i = 0; i < crAr.Length; i++)
            {
                byte[] charByte = Encoding.ASCII.GetBytes(crAr[i].ToString());
                charCode = charByte[0];
                charCode = (charCode + (2 * (i + 1)));
                char newChar = (char)charCode;
                result = result + newChar;

            }
            return result;
        }


    }
}
