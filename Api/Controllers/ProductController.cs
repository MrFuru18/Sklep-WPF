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
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Product> getAllProducts()
        {
            DB db = new DB();
            return db.Products.Select(x => new Product()
            {
                id = x.id,
                nazwa = x.nazwa,
                cena = x.cena,
                dostepna_ilosc = x.dostepna_ilosc,
                opis = x.opis
            });
        }

    }
}
