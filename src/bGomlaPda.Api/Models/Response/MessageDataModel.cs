namespace PdaHub.Api.Models.Response
{
    public record MessageDataModel
    {
        /// <summary> test </summary>
        /// 0   Success,
        /// 1   Warining,
        /// 2   Error,
        /// 3   Information

        public MessageType MessageType { get; set; }
        public string MessageBody { get; set; }
    }
}
