using PdaHub.Exceptions;
using PdaHub.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PdaHub.Services.Items
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
            if (model.date_from.HasValue && model.date_to.HasValue && model.usage.HasValue)
            {
                if (DateTime.Now > model.date_from && DateTime.Now < model.date_to && model.usage.Value == 1)
                {
                    throw new ItemsExceptions(
                        new string[]{ @"the item has an active promotion and can not be printed by this app right now",
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
        private bool HasArabicLetters(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
            return regex.IsMatch(text);
        }

        private void ValidatePromotion(List<PosItemEnitityModel> model)
        {
            if(model.Count == 0)
            {

            }
        }
    }
}
