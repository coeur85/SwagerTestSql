using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerTest.Models;

namespace SwaggerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
    
    [HttpGet]
      public string Get()
      {
          return "Stock Controller Get method";
      }


      [HttpPost]
      public int Post (StockModel model){
        return model.OrderNo;
      }

    }
}
