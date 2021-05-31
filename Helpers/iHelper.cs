using System.Threading.Tasks;

namespace PdaHub.Helpers
{
    public interface iHelper
    {

        public string PdaHubConnection();
        public string BranchLocalDB();
        public string ExcelSaveRoot();
        ValueTask<int> GetBranchCodeAsync();
        string AuthSecret();
    }
}
