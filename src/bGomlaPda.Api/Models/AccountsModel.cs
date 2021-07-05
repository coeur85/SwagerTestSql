namespace PdaHub.Models.Accounts
{

    public record UserNameModel(int UserID, string UserName);
    public record LoginModel(int UserID, string Password);
    public record AccountModel(int UserID, string ArabicTitle, string EnglishTitle);
    public record LoginSucessModel(AccountModel Account, string BearerToken);
    public class DocTypeModel
    {
        public int DocID { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
    //  public record DocTypeModel(int DocID, string ArabicName,string EnglishName);



}
