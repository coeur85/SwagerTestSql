using PdaHub.Models;
using System;

namespace PdaHub.Services
{
    public partial class ItemsServices
    {
        private void ValidatePosItem(PosItemEnitityModel model)
        {
            CheckItem(model);
            CheckItemPrice(model);
            CheckPromos(model);
        }
        private void CheckPromos(PosItemEnitityModel model)
        {
            if (model.date_from.HasValue && model.date_to.HasValue)
            {
                if (DateTime.Now > model.date_from && DateTime.Now < model.date_to)
                {
                    throw new ItemsExceptions(
                        new string[]{ @"the item has an active on it and can not be printed by this app tight now",
                            $"barcode# {model.barcode}",
                            $"item name {model.a_name}",
                            $"promo number# {model.discountno}",
                            $"promo peroid:{model.date_from.Value} till {model.date_to.Value}" });

                }
            }
        }
        private void CheckItemPrice(PosItemEnitityModel model)
        {
            if (!model.sell_price.HasValue)
                throw new ItemsExceptions("this item has no price, please contact your database administrator");
        }
        private void CheckItem(PosItemEnitityModel model)
        {
            if (model is null)
                throw new ItemsExceptions("No items where found, please check your barcode");
        }
    }
}
