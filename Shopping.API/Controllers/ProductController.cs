using System;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ILogger<Product> _logger;

        public ProductController(ILogger<Product> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Name = "asd"
            })
            .ToArray();
        }
    }
}

