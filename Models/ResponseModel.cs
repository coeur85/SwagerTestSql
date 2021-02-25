using System.Collections.Generic;

namespace PdaHub.Models
{
    public class ResponseModel
    {
        public bool Succsess { get; set; }
        public List<MessageDataModel> Messages { get; set; } = new();
    }
    public class SucessResponseModel : ResponseModel
    {
        public SucessResponseModel()
        {
            Succsess = true;
        }
        public SucessResponseModel(object data, string msg, MessageType type)
        {
            Succsess = true;
            Data = data;
            Messages.Add(new MessageDataModel { MessageType = type, MessageBody = msg });
        }
        public object Data { get; set; }


    }




    public class ErrorResponseModel : ResponseModel
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



    public class MessageDataModel
    {
        public MessageType MessageType { get; set; }
        public string MessageBody { get; set; }
    }
    public enum MessageType
    {
        Success,
        Warining,
        Error,
        Information
    }
}
