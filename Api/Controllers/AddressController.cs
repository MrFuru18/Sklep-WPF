using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Api.Controllers
{
    [ApiController]
    [Route("Address")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly DB db;
        private UserManager<User> userManager;

        public AddressController(ILogger<OrderController> logger, DB dbContext, UserManager<User> userMgr)
        {
            _logger = logger;
            db = dbContext;
            userManager = userMgr;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AddressView>>> getAllAddresses()
        {
            User u = await userManager
                .GetUserAsync(HttpContext.User);
            if (u == null) return null;
            return u.adresy
                .Select(x => new AddressView(x)).ToList();
        }

    }
}
