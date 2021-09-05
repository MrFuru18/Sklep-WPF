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
        [Route("makeOrder")]
        [Authorize]
        public async Task<ActionResult<OrderView>> Make([FromBody] OrderView order)
        {
            var transaction = db.Database.BeginTransaction();
            try
            {
                User u = await userManager.GetUserAsync(HttpContext.User);
                if (u == null) return new BadRequestResult();


                Address addr = (db.Users
                    .Where(x => x.Id == u.Id)
                    .Select(x => x.adresy)).FirstOrDefault()
                    .Where(p => p.id == order.adres_id)
                    .FirstOrDefault();

                if (addr == null) return new BadRequestResult();

                Order o = new()
                {
                    adres = addr,
                    data_zlozenia = DateTime.Now,
                    Stan = OrderState.niepotwierdzone,
                    user = u
                };

                o.pozycje = order.pozycje.Select(x => new OrderItem() {
                    ilosc = x.ilosc,
                    produkt = db.Products
                        .Where(p => p.id == x.produkt_id)
                        .FirstOrDefault(),
                    cena_1 = db.Products
                        .Where(p => p.id == x.produkt_id)
                        .FirstOrDefault().cena
                }).ToList();

                foreach(OrderItem item in o.pozycje)
                {
                    item.produkt.dostepna_ilosc -= item.ilosc;
                    if(item.produkt.dostepna_ilosc<0)
                    {
                        throw new Exception("Brak towaru");
                    }
                }
                db.Orders.Add(o);

                transaction.Commit();
                db.SaveChanges();
                return new OrderView(o);
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                if (ex.Message == "Brak towaru")
                    return new ConflictResult();
                return new BadRequestResult();
            }
        }

        [HttpPost]
        [Route("confirmOrder")]
        [Authorize]
        public async Task<ActionResult<OrderView>> confirmOrder(OrderView order)
        {
            User u = await userManager.GetUserAsync(HttpContext.User);
            if (u == null) return new BadRequestResult();

            Order o = db.Orders.Where(x => x.id == order.id).FirstOrDefault();
            if (order == null) return new BadRequestResult();
            if(o.user.Id==u.Id)
            {
                if(o.Stan==OrderState.niepotwierdzone)
                {
                    o.Stan = OrderState.realizowane;
                    db.SaveChanges();
                    return new OrderView(o);
                }
            }
            return new BadRequestResult();
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderView>>> getMyOrders()
        {
            User u = await userManager
                .GetUserAsync(HttpContext.User);
            if (u == null) return new BadRequestResult();
            var result = db.Orders
                .Where(x => x.user.Id == u.Id)
                .Include(x=>x.adres)
                .Include(x=>x.pozycje).ThenInclude(x=>x.produkt)
                .Select(x => new OrderView(x)).ToList();
            return result;
        }
    }
}