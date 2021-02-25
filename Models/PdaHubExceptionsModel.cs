using System;
using System.Collections.Generic;

namespace PdaHub.Models
{
    public class PdaHubExceptionsModel : Exception
    {
        public PdaHubExceptionsModel(string error) : base(error)
        {

        }
        public PdaHubExceptionsModel()
        {

        }
        public List<MessageDataModel> Messages { get; set; } = new();
    }

    public class ItemsExceptions : PdaHubExceptionsModel
    {
        public ItemsExceptions()
        {

        }
        public ItemsExceptions(string msg)
        {
            Messages.Add(new MessageDataModel { MessageType = MessageType.Error, MessageBody = msg });
        }
        public ItemsExceptions(string[] msgs)
        {
            foreach (var msg in msgs)
            {
                Messages.Add(new MessageDataModel { MessageBody = msg, MessageType = MessageType.Error });
            }
        }

    }
}
