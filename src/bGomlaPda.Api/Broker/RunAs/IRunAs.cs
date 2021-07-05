using System;

namespace PdaHub.Broker.RunAs
{
    public interface IRunAs
    {
        void RunAsAdminUser(Action model);
    }
}