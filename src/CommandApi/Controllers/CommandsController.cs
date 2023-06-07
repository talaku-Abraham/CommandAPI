// using System;
using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<String>> Get(){
            return new String[]{"this", "is","hard", "coded"};
        }
    }
}