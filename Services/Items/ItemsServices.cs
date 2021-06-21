using PdaHub.Models;
using PdaHub.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Services.Items
{
    public partial class ItemsServices : IItemsServices
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsServices(IItemsRepository itemsRepository)
                => _itemsRepository = itemsRepository;
        
        public Task<SucessResponseModel<ItemDetailsResponseModel>> GetPosItemAsync(string barcode)
            => TryCatch(async () =>
            {
                barcode = barcode.Trim();
                var dbModel = await _itemsRepository.GetPosItemAsync(barcode);
                var catModel = await _itemsRepository.GetItemSectionAsync(barcode);
                var specialItemModel = await _itemsRepository.ItemSpecialAsync(barcode);
                ValidatePosItem(dbModel);
                var modelName = ItemName(dbModel);
                ItemDetailsResponseModel item = new ItemDetailsResponseModel
                {
                    ArabicName = modelName.ArabicName,
                    Barcode = dbModel.barcode.Trim(),
                    EnglishName = modelName.EnglsihName,
                    Price = dbModel.sell_price.Value,
                    PrintDate = DateTime.Today,
                    CategoryName = catModel.a_name,
                };
                if (specialItemModel is not null)
                { item.IsSpecial = true; item.Notes = specialItemModel.Notes; }

                SucessResponseModel<ItemDetailsResponseModel> output = new(item, @$"Last price update on {dbModel.last_modified_time.ToShortDateString()}" +
                    $"-{dbModel.last_modified_time.ToShortTimeString()}", MessageType.Information);
                return output;
            });
        public Task<SucessResponseModel<List<PromotionItemDetailsResponseModel>>> GetPromotionItemsAsync(int DiscountNo)
          => TryCatch(async () =>
          {

              var items = await _itemsRepository.GetItemsInPromo(DiscountNo);
              ValidatePromotion(DiscountNo, items);
              int discountType = items.First().discountno.Value;
              List<PromotionItemDetailsResponseModel> output = new();
              switch (discountType)
              {
                  case 101:
                      break;

                  case 102:

                      break;
        
                 
              }

              return new SucessResponseModel<List<PromotionItemDetailsResponseModel>> { Data = output };

             
          });
    }
}
