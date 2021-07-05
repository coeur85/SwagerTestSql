using System.Collections.Generic;

namespace PdaHub.Test.Acceptance.Models.Response
{
    public record ResponseModel
    {
        public bool Succsess { get; set; }
        public List<MessageDataModel> Messages { get; set; } = new();
    }
}

