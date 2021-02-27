using System.Collections.Generic;

namespace PdaHub.Models
{
    public class ResponseModel
    {
        public bool Succsess { get; set; }
        public List<MessageDataModel> Messages { get; set; } = new();
    }
    public class SucessResponseModel<T> : ResponseModel
    {
        public SucessResponseModel()
        {
            Succsess = true;
        }
        public SucessResponseModel(T data, string msg, MessageType type)
        {
            Succsess = true;
            Data = data;
            Messages.Add(new MessageDataModel { MessageType = type, MessageBody = msg });
        }
        public T Data { get; set; }


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


    /// <summary>Everyone needs a name</summary>
    public class MessageDataModel
    {
        /// <summary> test </summary>
        /// 0   Success,
        /// 1   Warining,
        /// 2   Error,
        /// 3   Information

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
