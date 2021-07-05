using PdaHub.Models;

namespace PdaHub.Exceptions
{
    public class AccountsExceptions : PdaHubExceptions
    {
        public AccountsExceptions(string msg)
        {
            Messages.Add(new MessageDataModel { MessageType = MessageType.Error, MessageBody = msg });
        }
    }


    public class InvalidLoginCredentialsExceptions : AccountsExceptions
    {
        public InvalidLoginCredentialsExceptions()
            : base("Wrong password !")
        {

        }
    }
}
