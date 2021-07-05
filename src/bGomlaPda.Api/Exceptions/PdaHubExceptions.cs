using PdaHub.Models;
using System;
using System.Collections.Generic;

namespace PdaHub.Exceptions
{
    public class PdaHubExceptions : Exception
    {
        public PdaHubExceptions(string error) : base(error)
        {

        }
        public PdaHubExceptions()
        {

        }
        public List<MessageDataModel> Messages { get; set; } = new();
    }
}
