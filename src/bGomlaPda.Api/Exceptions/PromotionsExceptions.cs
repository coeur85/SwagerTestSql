using PdaHub.Api.Models.Response;

namespace PdaHub.Exceptions
{
    public class PromotionsExceptions : PdaHubExceptions
    {
        public PromotionsExceptions(string msg)
        {
            Messages.Add(new MessageDataModel { MessageType = MessageType.Error, MessageBody = msg });
        }
        public PromotionsExceptions(string[] msgs)
        {
            foreach (var msg in msgs)
            {
                Messages.Add(new MessageDataModel { MessageBody = msg, MessageType = MessageType.Error });
            }
        }
    }
}
