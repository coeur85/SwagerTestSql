using System.Collections.Generic;

namespace PdaHub.Models.Item
{

    public record PromotionItemsReponseModel
    {
        public List<PromotionItemDetailsModel> Items { get; set; } = new();
    }

}



