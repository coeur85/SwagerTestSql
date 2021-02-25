using PdaHub.Models;
using System;
using System.Threading.Tasks;

namespace PdaHub.Services
{
    public partial class ItemsServices
    {

        private delegate Task<SucessResponseModel> SearchBarcodeDeletget();
        private async Task<SucessResponseModel> TryCatch(SearchBarcodeDeletget model)
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
