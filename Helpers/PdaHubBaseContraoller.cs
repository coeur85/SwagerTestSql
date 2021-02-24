using Microsoft.AspNetCore.Mvc;
using PdaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdaHub.Helpers
{
    public class PdaHubBaseContraoller : ControllerBase
    {
        protected delegate Task<ResponseModel> RetrunActionResultFunc();

        protected async Task<ResponseModel> TryCatch(RetrunActionResultFunc model)
        {
            try
            {
                 return await model();
            }
            catch (PdaHubExceptionsModel ex)
            {

                return new ErrorResponseModel(ex.Messages);
            }
        }
    }
}
