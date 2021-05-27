using PdaHub.Models;
using System;
using System.Threading.Tasks;

namespace PdaHub.Services.Items
{
    public partial class ItemsServices
    {

        private delegate Task<SucessResponseModel<ItemDetailsResponseModel>> SearchBarcodeDeletget();
        private async Task<SucessResponseModel<ItemDetailsResponseModel>> TryCatch(SearchBarcodeDeletget model)
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
