using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_shop_Api.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainClass : ControllerBase
    {
        public static string ConnStr { get; set; }
        
    }
}
