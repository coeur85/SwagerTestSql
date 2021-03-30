using Microsoft.AspNetCore.Mvc;
using PdaHub.Models;
using System.Threading.Tasks;

namespace PdaHub.Helpers
{
    public class PdaHubBaseContraoller : ControllerBase
    {
        protected delegate Task<ActionResult<SucessResponseModel<T>>> RetrunActionResultFunc<T>();

        protected async Task<ActionResult<SucessResponseModel<T>>> TryCatch<T>(RetrunActionResultFunc<T> model)
        {
            try
            {
                return await model();
            }
            catch (PdaHubExceptionsModel ex)
            {

                return BadRequest(new ErrorResponseModel(ex.Messages));
            }
        }
    }
}
