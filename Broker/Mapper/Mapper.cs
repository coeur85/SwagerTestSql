using PdaHub.Models;
using PdaHub.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Broker.Mapper
{
    public partial class Mapper : IMapper
    {
        public PromotionItemDetailsModel MapPromoType102(PosItemEnitityModel model, ItemSectionEnitiyModel catModel)
        {
            NamingModel modelName = ItemName(model);
            return new PromotionItemDetailsModel
            {
                Header = new Header
                {
                    CategoryName = catModel.a_name,
                    ArabicName = modelName.ArabicName,
                    EnglishName = modelName.EnglsihName
                },
                Body = new Body
                {
                    Price = model.sell_price.Value - model.discountvalue.Value,
                    DescriptionArea = new Descriptionarea
                    {
                        IsDivided = true,
                        DescriptionLineTwoDrowX = true,
                        DescriptionLineOne = "بدلا من :",
                        DescriptionLineTwo = model.sell_price.Value.ToString()
                    }

                },
                Footer = new Footer
                {
                    PromotionNumber = model.discountno.Value,
                    PromotionExpireDate = model.date_to.Value.ToShortDateString(),
                    PrintDate = DateTime.Now.ToShortDateString(),
                    DrowDescriptionCenterAsBarcode = true,
                    DescriptionCenter = model.barcode.Trim(),
                    DescriptionRight = model.barcode.Trim()
                }

            };
        }


        public ItemDetailsResponseModel MapItem(PosItemEnitityModel dbItem, ItemSectionEnitiyModel catModel, ItemSpecialEnitiyModel specialItemModel)
        {
            NamingModel modelName = ItemName(dbItem);
            ItemDetailsResponseModel output = new ItemDetailsResponseModel
            {
                ArabicName = modelName.ArabicName,
                Barcode = dbItem.barcode.Trim(),
                EnglishName = modelName.EnglsihName,
                Price = dbItem.sell_price.Value,
                PrintDate = DateTime.Today,
                CategoryName = catModel.a_name,
            };
            if (specialItemModel is not null)
            {
                output.IsSpecial = true;
                output.Notes = specialItemModel.Notes;
            }
            return output;
        }
    }
}
