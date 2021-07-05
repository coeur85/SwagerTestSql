using PdaHub.Api.Models.Response;
using PdaHub.Broker.Mapper;
using PdaHub.Models.Item;
using PdaHub.Repositories.BasicData;
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
        private readonly IBasicDataRepository _basicDataRepository;
        private readonly IMapper _mapper;

        public ItemsServices(IItemsRepository itemsRepository, IBasicDataRepository basicDataRepository,
        IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _basicDataRepository = basicDataRepository;
            _mapper = mapper;
        }

        public Task<SucessResponseModel<ItemDetailsResponseModel>> GetPosItemAsync(string barcode)
            => TryCatch(async () =>
            {
                barcode = barcode.Trim();
                var dbModel = await _itemsRepository.GetPosItemAsync(barcode);
                ValidatePosItem(dbModel);

                var catModel = await _itemsRepository.GetItemSectionAsync(barcode);
                var specialItemModel = await _itemsRepository.ItemSpecialAsync(barcode);
                ItemDetailsResponseModel item = _mapper.MapItem(dbModel, catModel, specialItemModel);

                SucessResponseModel<ItemDetailsResponseModel> output = new(item, @$"Last price update on {dbModel.last_modified_time.ToShortDateString()}" +
                    $"-{dbModel.last_modified_time.ToShortTimeString()}", MessageType.Information);
                return output;
            });
        public Task<SucessResponseModel<PromotionItemsReponseModel>> GetPromotionItemsAsync(string Code)
          => TryCatch(async () =>
          {
              ValidateGetSearchCode(Code);
              List<PosItemEnitityModel> items = new();
              if (Code.Length <= 10)
              {
                  if (isIntgerSize(Code))
                  {
                      var promoId = Convert.ToInt32(Code);
                      items = await _itemsRepository.GetItemsInPromo(promoId);
                  }
              }

              if (items.Count == 0)
              {
                  items.Add(await _itemsRepository.GetPosItemAsync(Code.Trim()));
              }

              int discountType = items.First().discounttype.Value;
              int discountNo = items.First().discountno.Value;
              ValidatePromotion(discountNo, items);

              PromotionItemsReponseModel output = new();
              switch (discountType)
              {
                  case 101:
                      foreach (var item in items)
                      {
                          var catModel = await _itemsRepository.GetItemSectionAsync(item.barcode);
                          output.Items.Add(_mapper.MapPromoType101(item, catModel));
                      }
                      break;
                  case 102:
                      foreach (var item in items)
                      {
                          var catModel = await _itemsRepository.GetItemSectionAsync(item.barcode);
                          output.Items.Add(_mapper.MapPromoType102(item, catModel));
                      }

                      break;
              }

              return new SucessResponseModel<PromotionItemsReponseModel> { Data = output };


          });
    }
}
