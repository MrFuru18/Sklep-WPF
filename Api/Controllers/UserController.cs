using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Api.Model.ViewModel;

namespace Api.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly DB db;

        public UserController(ILogger<UserController> logger,DB dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public UserView Login([FromHeader]string mail, [FromHeader]string pass)
        {
            User r = db.Users.Where(
                x =>
                    x.email == mail && pass == x.haslo
                    )
                .FirstOrDefault();
            return new UserView()
            {
                login = r.login,
                email = r.email,
                imie = r.imie,
                nazwisko = r.nazwisko,
                nr_tel = r.nr_tel,
                adresy = r.adresy,
                token = r.token
            };
        }


        [HttpPost]
        [Route("Addresses")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IEnumerable<AddressView> GetAddresses([FromHeader]string login, [FromHeader]string token)
        {
            return db.Users.Where(
                x => 
                    x.login == login && token == x.token
                )
                .FirstOrDefault()
                .adresy as List<AddressView>;
        }
    }
}
