using SimpleImpersonation;
using System;

namespace PdaHub.Broker.RunAs
{
    public class RunAs : IRunAs
    {
        public void RunAsAdminUser(Action model)
        {
            var credentials = new UserCredentials(@"bGomla\sql.svc", @"PkJ)A96y3q\^41@<;Fu3Zh4J/NT.to");
            Impersonation.RunAsUser(credentials, LogonType.NetworkCleartext, () =>
            {
                model();
            });

        }
    }
}
