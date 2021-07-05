using PdaHub.Api.Models.Response;
using System;
using System.Threading.Tasks;

namespace PdaHub.Services.Accounts
{
    public partial class AccountsServices
    {

        private delegate Task<SucessResponseModel<T>> TaskOfT<T>();
        private async Task<SucessResponseModel<T>> TryCatch<T>(TaskOfT<T> model)
        {
            try
            {
                return await model();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
