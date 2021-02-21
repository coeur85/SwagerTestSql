using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PdaHub.DataAccess;
using PdaHub.Models;
using SimpleImpersonation;

namespace PdaHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class StockController : ControllerBase
    {
    private readonly StockData _stockData;
    public StockController(StockData stockData)
        {
            _stockData = stockData;
        }
    
    [HttpGet]
    public string Get()
      {
          return "Stock Controller Get method";
      }
    [HttpPost]
    public async Task<StockInOutDetailModel> sendUpdate(StockReviewModel model)
    {
        var data = await _stockData.GetInOutOrderDetailAsync(model);
        var credentials = new UserCredentials(@"bGomla\sql.svc", @"PkJ)A96y3q\^41@<;Fu3Zh4J/NT.to");
        Impersonation.RunAsUser(credentials, LogonType.NetworkCleartext, () =>
        {
            _stockData.SaveToExcel(data);
        });
        return data;
    }
    }
}
