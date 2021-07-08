using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly DB db;

        public OrderController(ILogger<OrderController> logger,DB dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        [HttpPost]
        [Route("make")]
        [ValidateAntiForgeryToken]
        public Order Make([FromHeader]Order order)
        {
            db.Database.BeginTransaction();
            foreach(var item in order.pozycje)
            {
                Product current = db.Products.Where(x => x.id == item.produkt.id).FirstOrDefault();
                current.dostepna_ilosc -= item.ilosc;
                if(current.dostepna_ilosc<0)
                {
                    db.Database.RollbackTransaction();
                    return null;
                }
            }
            db.Orders.Add(order);
            db.Database.CommitTransaction();
            db.SaveChanges();
            return order;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<OrderView>>> getMyOrders()
        {
            return await db.Orders.Select(x => new OrderView()
            {
                id = x.id,
                pozycje = x.pozycje.Select(p => new OrderItemView()
                {
                    ilosc = p.ilosc,
                    cena_1 = p.cena_1,
                    produkt_id = p.produkt.id
                }).ToList(),
                adres_id = x.adres.id,
                data_zlozenia = x.data_zlozenia
            }).ToListAsync();
        }
    }
}