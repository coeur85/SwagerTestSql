using PdaHub.Broker.DataAccess;
using PdaHub.Helpers;
using PdaHub.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Repositories.Accounts
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly iHelper _helper;
        private readonly ISqlDataAccess _dataAccess;

        public AccountsRepository(iHelper helper, ISqlDataAccess dataAccess)
        {
            _helper = helper;
            _dataAccess = dataAccess;
        }


        public async Task<List<UserNameModel>> GetAllowedUsersAsync()
        {
            var branch = await _helper.GetBranchCodeAsync();
            var output = await _dataAccess.QueryAsync<UserNameModel>(_helper.BranchLocalDB(),
                $@"selecT distinct l.userid ,l.username from sys_login l inner join sys_userprofile p on l.userid = p.userid
                where p.systemcode = 666 and (l.trails in({branch} ,0) or p.setting like '%{branch}%') and l.locked = 0 order by l.username");
            return output.ToList();
        }

    }
}
