﻿using PdaHub.Models;
using System;
using System.Collections.Generic;

namespace PdaHub.Exceptions
{
    public class PdaHubExceptions : Exception
    {
        public PdaHubExceptions(string error) : base(error)
        {

        }
        public PdaHubExceptions()
        {

        }
        public List<MessageDataModel> Messages { get; set; } = new();
    }

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