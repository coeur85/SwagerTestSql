using System.Collections.Generic;

namespace PdaHub.Test.Acceptance.Models.Response
{
    public record ErrorResponseModel : ResponseModel
    {
        public ErrorResponseModel()
        {
            Succsess = false;
        }
        public ErrorResponseModel(string msg)
        {
            Succsess = false;
            Messages.Add(new MessageDataModel { MessageType = MessageType.Error, MessageBody = msg });
        }
        public ErrorResponseModel(string[] msgs)
        {
            Succsess = false;
            foreach (var msg in msgs)
            {
                Messages.Add(new MessageDataModel { MessageBody = msg, MessageType = MessageType.Error });
            }
        }
        public ErrorResponseModel(List<MessageDataModel> Messages)
        {
            Succsess = false;
            base.Messages = Messages;
        }

    }
}

