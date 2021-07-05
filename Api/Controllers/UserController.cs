using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public User Login([FromHeader]string mail, [FromHeader]string pass)
        {
            throw new NotImplementedException();
            //string token = "";
            //DB db = new DB();
            //token = db.Users.Where(
            //    x => 
            //        x.email == mail && pass == x.haslo
            //        )
            //    .FirstOrDefault()
            //    .token;
            //return token;
        }


        [HttpPost]
        [Route("Addresses")]
        public IEnumerable<Address> GetAddresses([FromHeader]long id, [FromHeader]string token)
        {
            throw new NotImplementedException();
            //DB db = new DB();
            //return db.Users.Where(
            //    x => 
            //        x.email == mail && token == x.token
            //    )
            //    .FirstOrDefault()
            //    .adresy;
        }
    }
}
