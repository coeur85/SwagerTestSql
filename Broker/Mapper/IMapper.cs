using PdaHub.Models;

namespace PdaHub.Broker.Mapper
{
    public interface IMapper
    {
        ItemDetailsResponseModel MapItem(PosItemEnitityModel dbItem, ItemSectionEnitiyModel catModel, ItemSpecialEnitiyModel specialItemModel);
        PromotionItemDetailsModel MapPromoType102(PosItemEnitityModel model, ItemSectionEnitiyModel catModel);
    }
}