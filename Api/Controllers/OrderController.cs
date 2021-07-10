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
    [Route("Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly DB db;
        private UserManager<User> userManager;

        public OrderController(ILogger<OrderController> logger, DB dbContext, UserManager<User> userMgr)
        {
            _logger = logger;
            db = dbContext;
            userManager = userMgr;
        }

        [HttpPost]
        [Route("make")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult<OrderView>> Make([FromBody] OrderView order)
        {
            //
            throw new NotImplementedException();
            //
            User u = await userManager.GetUserAsync(HttpContext.User);
            if (u == null) return null;
            Order o = new();
            db.Database.BeginTransaction();
            //To do
            db.Database.CommitTransaction();
            return new OrderView(o);
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderView>>> getMyOrders()
        {
            User u = await userManager
                .GetUserAsync(HttpContext.User);
            if (u == null) return null;
            return await db.Orders
                .Where(x => x.user.Id == u.Id)
                .Select(x=> new OrderView(x)).ToListAsync();
        }
    }
}