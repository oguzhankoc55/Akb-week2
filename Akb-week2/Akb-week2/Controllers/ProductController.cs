using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize] // Fake kullanýcý giriþi için authorization kontrolü
    public class ProductsController : ControllerBase
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 19.99 },
            new Product { Id = 2, Name = "Product 2", Price = 29.99 },
            // ... Diðer ürünler
        };
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductsController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }
        [HttpGet]
        [AllowAnonymous] // Herkesin eriþebilmesi için
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            return product;
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _products.Count + 1;
                _products.Add(product);

                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }

            return BadRequest(ModelState); // 400 Bad Request
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent(); // 204 No Content
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            _products.Remove(product);

            return NoContent(); // 204 No Content
        }

        // GET: api/products/list?name=abc&sort=asc
        [HttpGet("list")]
        public ActionResult<IEnumerable<Product>> ListAndSortProducts(string name, string sort)
        {
            var query = _products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(sort) && sort.Equals("asc", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(p => p.Name);
            }
            else if (!string.IsNullOrEmpty(sort) && sort.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(p => p.Name);
            }

            return query.ToList();
        }
        
        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404 Not Found
            }

            patchDoc.ApplyTo(product, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) =>
            {
                // Hata durumunu ele alabilirsiniz
                ModelState.AddModelError("JsonPatch", err.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            return NoContent(); // 204 No Content
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
