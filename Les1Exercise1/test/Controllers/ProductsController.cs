using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using test.Models;
namespace WebAPIService.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
        new Product { Id = 1, Name = "Чай Ахмат", Category = "Бакалея", Price = 100 },
        new Product { Id = 2, Name = "Кукла Барби", Category = "Игрушки", Price = 1000 },
        new Product { Id = 3, Name = "Дрель Интерскол", Category = "Инструменты", Price = 3000 }
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
