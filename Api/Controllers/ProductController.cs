using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Api.Model.ViewModel;

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
        [Authorize]
        public void addProduct([FromBody] Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        [HttpGet]
        [Route("getAll")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductView>>> getAllProducts()
        {
            return await db.Products
                .Select(x => new ProductView(x))
                .ToListAsync();
        }

    }
}
