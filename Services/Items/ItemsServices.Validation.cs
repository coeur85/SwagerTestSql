using PdaHub.Exceptions;
using PdaHub.Models;
using System;
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


        private NameingModel ItemName(PosItemEnitityModel dbModel)
        {
            NameingModel output = new() { ArabicName = dbModel.a_name, EnglsihName = dbModel.l_name };

            if (HasArabicLetters(dbModel.l_name))
            {
                output.EnglsihName = string.Empty;
                output.ArabicName = output.ArabicName.Trim();
            }

            if (string.IsNullOrEmpty(output.EnglsihName))
            {
                if (output.ArabicName.Length >= 45)
                {
                    var words = SplitLines(output.ArabicName);
                    output.ArabicName = words[0];
                    output.EnglsihName = words[1];
                }
            }

            // output.ArabicName = Center(output.ArabicName);


            return output;

        }



        private string[] SplitLines(string name)
        {
            name = name.Trim();
            var words = name.Split(new char[0]); // splite on spacae
            int wc = words.Length / 2;
            string[] output = new string[2];

            for (int i = 0; i < wc; i++)
            {
                output[0] += words[i] + " ";
            }

            for (int i = wc; i < words.Length; i++)
            {
                output[1] += words[i] + " ";
            }




            return output;
        }


        private string EmptySpaces(int length)
        {
            string output = string.Empty;
            for (int i = 0; i < length; i++)
            {
                output += " ";
            }
            return output;
        }

        private string Center(string word)
        {

            var lin1 = 50 - word.Length;
            int beforAfter = lin1 / 2;
            word = EmptySpaces(beforAfter) + word + EmptySpaces(beforAfter);
            return word;
        }

    }
}
