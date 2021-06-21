using PdaHub.Models;
using System;
using System.Collections.Generic;
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


        private delegate Task<SucessResponseModel<PromotionItemsReponseModel>> SearchPromoDeletget();
        private async Task<SucessResponseModel<PromotionItemsReponseModel>> TryCatch(SearchPromoDeletget model)
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
