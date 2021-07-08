using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly DB db;
        public ProductController(ILogger<ProductController> logger, DB dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        [HttpPost]
        [Route("Add")]
        public void addProduct([FromHeader]Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        [HttpGet]
        [Route("getAll")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> getAllProducts()
        {
            return await db.Products.Select(x => new Product()
            {
                id = x.id,
                nazwa = x.nazwa,
                cena = x.cena,
                dostepna_ilosc = x.dostepna_ilosc,
                opis = x.opis
            }).ToListAsync();
        }

    }
}
