namespace PdaHub.Test.Acceptance.Models.Response
{
    public record MessageDataModel
    {
      
        public MessageType MessageType { get; set; }
        public string MessageBody { get; set; }
    }
}

