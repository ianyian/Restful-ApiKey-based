using Microsoft.AspNetCore.Mvc;
using Restful_ApiKey_based.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_ApiKey_based.Controllers
{
    [ApiKeyAuth]
    public class SecretController : ControllerBase 
    {
        [HttpGet(template:"secret")]
        public IActionResult GetSecret()
        {
            return Ok("i'm gooood");
        }
    }
}
