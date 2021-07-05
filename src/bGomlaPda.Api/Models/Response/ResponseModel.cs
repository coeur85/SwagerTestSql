using System.Collections.Generic;

namespace PdaHub.Api.Models.Response
{
    public record ResponseModel
    {
        public bool Succsess { get; set; }
        public List<MessageDataModel> Messages { get; set; } = new();
    }
}
