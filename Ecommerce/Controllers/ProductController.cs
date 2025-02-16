using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {

        var products = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Pc",
                Price = 1000,
                Description = "Powerful pc",
                Category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Title = "Electronics"
                }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Tv",
                Price = 2000,
                Description = "A normal television",
                Category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Title = "Electronics"
                }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Book",
                Price = 1000,
                Description = "A book",
                Category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Title = "Literature"
                }
            }
        };

        var productsList = new ProductsListModel()
        {
            Products = products
        };
        
        return View(productsList);
    }

    public IActionResult Add()
    {
        return View();
    }
}