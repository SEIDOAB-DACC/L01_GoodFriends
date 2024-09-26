using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Models.DTO;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HealthController : Controller
    {
        IFriendsService _service = null;
        ILogger<FriendsController> _logger = null;

        // GET: health/hello
        [HttpGet()]
        [ActionName("Heartbeat")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Heartbeat()
        {
            //to verify the layers are accessible
            string sRet = $"\nLayer access:\n{csAppConfig.Heartbeat}" +
                $"\n{csFriend.Heartbeat}" +
                $"\n{csLoginService.Heartbeat}" +
                $"\n{csJWTService.Heartbeat}" +
                $"\n{csFriendsServiceDb.Heartbeat}";

           //to verify secret access source
            sRet += $"\n\nSecret source:\n{csAppConfig.SecretSource}";

            //to verify connection strings can be read from appsettings.json
            sRet += $"\n\nDbConnections:\nDbLocation: {csAppConfig.DbSetActive.DbLocation}" +
                $"\nDbServer: {csAppConfig.DbSetActive.DbServer}";

            sRet += "\nDbUserLogins in DbSet:";
            foreach (var item in csAppConfig.DbSetActive.DbLogins)
            {
                sRet += $"\n   DbUserLogin: {item.DbUserLogin}" +
                    $"\n   DbConnection: {item.DbConnection}\n   ConString: <secret>";
            }

            return Ok(sRet);
        }

        //GET: health/log
        [HttpGet()]
        [ActionName("Log")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csLogMessage>))]
        public async Task<IActionResult> Log([FromServices] ILoggerProvider _loggerProvider)
        {
            return BadRequest("Not implemented");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        #region constructors
        /*
        public HealthController(IFriendsService service, ILogger<FriendsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        */
        #endregion
    }
}

/* Exercise - HealthController
1. Add below structue to appsettings.json
  "MyName": {
    "FirstName": "your name",
    "LastName": "your name",
    "Age": your_age
  },
2. Modify Configuration.csAppConfig.cs to read MyName structure
3. Modify HealthController so Heartbeat service also writes your full name and age

4. Make new Action AppTest that says "Hello World"
*/

