﻿using PdaHub.Api.Models.Base;
using PdaHub.Models.Item;
using System;

namespace PdaHub.Broker.Mapper
{
    public partial class Mapper
    {
        public PromotionItemDetailsModel MapPromoType102(PosItemEnitityModel model, ItemSectionEnitiyModel catModel)
        {
            return new PromotionItemDetailsModel
            {
                Header = MapHeader(model, catModel),
                Body = new Body
                {
                   
                    DescriptionArea = new Descriptionarea
                    {
                        IsDivided = true,
                        DescriptionLineTwoDrawX = true,
                        DescriptionLineOne = "بدلا من :",
                        DescriptionLineTwo = model.sell_price.Value.ToString(),
                      
                    },
                    PriceArea = new PriceArea
                    {
                        Price = model.sell_price.Value - model.discountvalue.Value,
                        ShowtSideBarcode = true,
                        SideBarcodeValue = model.barcode.Trim()
                    }

                },
                Footer = MapFooter(model)



            };
        }
        public PromotionItemDetailsModel MapPromoType101(PosItemEnitityModel model, ItemSectionEnitiyModel catModel)
        {
            NamingModel discripPromo = DiscripPromo101(model);
            return new PromotionItemDetailsModel
            {

                Header = MapHeader(model, catModel),
                Body = new Body
                {
                   
                    DescriptionArea = new Descriptionarea
                    {
                        IsDivided = false,
                        DescriptionLineTwoDrawX = false,
                        DescriptionLineOne = discripPromo.LineOne,
                        DescriptionLineTwo = discripPromo.LineTwo
                       
                    },
                    PriceArea = new PriceArea
                    {
                        Price = model.sell_price.Value,
                        ShowtSideBarcode = true,
                        SideBarcodeValue = model.barcode.Trim()
                    }

                },
                Footer = MapFooter(model)
            };
        }
        public ItemDetailsResponseModel MapItem(PosItemEnitityModel dbItem, ItemSectionEnitiyModel catModel, ItemSpecialEnitiyModel specialItemModel)
        {
            NamingModel modelName = ItemName(dbItem);
            ItemDetailsResponseModel output = new ItemDetailsResponseModel
            {
                ArabicName = modelName.LineOne,
                Barcode = dbItem.barcode.Trim(),
                EnglishName = modelName.LineTwo,
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


        private Header MapHeader(PosItemEnitityModel model, ItemSectionEnitiyModel catModel)
        {
            NamingModel modelName = ItemName(model);
            return new Header
            {
                CategoryName = catModel.a_name,
                ArabicName = modelName.LineOne,
                EnglishName = modelName.LineTwo

            };
        }
        private Footer MapFooter(PosItemEnitityModel model)
        {
            return new Footer
            {
                PromotionNumber = model.discountno.Value,
                PromotionExpireDate = model.date_to.Value.ToShortDateString(),
                PrintDate = DateTime.Now.ToShortDateString(),
                DescriptionCenter = model.barcode.Trim(),
                DescriptionRight = model.barcode.Trim()
            };
        }
    }
}
