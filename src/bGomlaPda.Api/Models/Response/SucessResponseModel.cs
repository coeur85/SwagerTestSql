namespace PdaHub.Api.Models.Response
{
    public record SucessResponseModel<T> : ResponseModel
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
}
