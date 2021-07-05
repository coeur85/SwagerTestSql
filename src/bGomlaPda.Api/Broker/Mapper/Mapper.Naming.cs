using PdaHub.Models;
using System;
using System.Text.RegularExpressions;

namespace PdaHub.Broker.Mapper
{
    public partial class Mapper
    {
        private NamingModel ItemName(PosItemEnitityModel dbModel)
        {
            NamingModel output = new() { LineOne = dbModel.a_name, LineTwo = dbModel.l_name };

            if (HasArabicLetters(dbModel.l_name))
            {
                output.LineTwo = string.Empty;
                output.LineOne = output.LineOne.Trim();
            }

            if (string.IsNullOrEmpty(output.LineTwo))
            {
                if (output.LineOne.Length >= 45)
                {
                    var words = SplitLines(output.LineOne);
                    output.LineOne = words[0];
                    output.LineTwo = words[1];
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
        private bool HasArabicLetters(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
            return regex.IsMatch(text);
        }
    
        private NamingModel DiscripPromo101(PosItemEnitityModel model){

            NamingModel output = new();
            decimal discountPercent = model.discountvalue.Value;
            decimal orginalPricePercent = 100 - discountPercent;
            double discountAmount = Convert.ToDouble(discountPercent / orginalPricePercent);
            switch (discountAmount)
            {
                case 1:
                    output.LineOne = UniteName(model.barcode)+ " + ";;
                    output.LineTwo = UniteName(model.barcode) +" هدية ";
                   
                    break;
                case <= 0.5 and >= 0.49  :
                    output.LineOne = UniteName(model.barcode)+ " + ";
                    output.LineTwo = "نصف هدية";
                    break;

                case 0.25 :
                    output.LineOne = UniteName(model.barcode)+ " + ";
                    output.LineTwo = "ربع هدية";
                    break;
                default:
                    output.LineOne = "خصم ";
                    output.LineTwo = $"{discountAmount}%";
                    break;
            }



            return output;
        }

        private string UniteName(string barcode){
            if(barcode.Trim().StartsWith("23"))
            {
                return "كيلو";
            }
            else{
                return "قطعة";
            }

        }
    
    }
}
