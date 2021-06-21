using PdaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Services.Items
{
    public partial class ItemsServices
    {
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
    }
}
