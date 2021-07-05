using PdaHub.Exceptions;
using PdaHub.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PdaHub.Services.Items
{
    public partial class ItemsServices
    {
        private void ValidatePosItem(PosItemEnitityModel model)
        {
            CheckItem(model);
            CheckItemPrice(model);
            CheckNoActivePromos(model);
        }
        private void CheckNoActivePromos(PosItemEnitityModel model)
        {
            if (DoesItemHasPromo(model))
                throw new ItemsExceptions(
                       new string[]{ @"the item has an active promotion and can not be printed by this app right now",
                            $"barcode# {model.barcode}",
                            $"item name {model.a_name}",
                            $"promo number# {model.discountno}",
                            $"promo peroid:{model.date_from.Value} till {model.date_to.Value}" });



        }

        private bool DoesItemHasPromo(PosItemEnitityModel model)
        {
            if (model.date_from.HasValue && model.date_to.HasValue && model.usage.HasValue)
            {
                if (DateTime.Now > model.date_from && DateTime.Now < model.date_to && model.usage.Value == 1)
                {
                    return true;
                }
            }
            return false;
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
        private void ValidatePromotion(int DiscountNo, List<PosItemEnitityModel> model)
        {
            if (model.Count == 0)
                throw new PromotionsExceptions(new string[]
                {"there is no items in this promo",
                $"wrong promo code {DiscountNo}"});


            var expiredItmes = model.Where(x => !DoesItemHasPromo(x)).ToList();

            if (expiredItmes.Count > 0)
            {
                throw new PromotionsExceptions(
                        new string[]{ @"this promotion has expired items, nad can not be printed",
                            $"promo number# {DiscountNo}",
                            $"promo peroid:{expiredItmes.Min(x=> x.date_from).Value} till {model.Max(x=> x.date_to).Value}",
                            $"barcodes# { string.Join(",", expiredItmes.Select(x => x.barcode))}",
                            $"items name {string.Join(",", expiredItmes.Select(x => x.a_name))}"
                        }
                    );


            }

            int[] acceptedPromoTypes = new int[] { 101, 102 };
            var allSupported = model.TrueForAll(x => x.discounttype.HasValue && acceptedPromoTypes.Any(y => y == x.discounttype.Value));
            if (!allSupported)
                throw new PromotionsExceptions("only direct promotion are currently supported!");



        }   
        private void ValidateGetSearchCode(string Code){
           
                bool resrult = Code.All(c => c >= '0' && c <= '9');
                if(!resrult)
                    throw new PromotionsExceptions("invalied search code !");
           
        }

        private bool isIntgerSize(string value)
        {
            try
            {
                var result = Convert.ToInt32(value);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
