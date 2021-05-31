﻿using PdaHub.Models;

namespace PdaHub.Exceptions
{
    public class ItemsExceptions : PdaHubExceptions
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
