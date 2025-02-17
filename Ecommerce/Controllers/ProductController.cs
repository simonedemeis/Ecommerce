using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProductController : Controller
{
    //Lista statica di prodotti di partenza per popolare la tabella. Simula i prodotti in un database.
    private static readonly List<Category> Categories = new()
    {
        new Category { Id = Guid.Parse("3f4e1a89-2d45-4f8d-9a7e-123456789abc"), Title = "Electronics" },
        new Category { Id = Guid.Parse("a1b2c3d4-e5f6-4789-abcd-9876543210ef"), Title = "Literature" },
        new Category { Id = Guid.Parse("fedcba98-7654-4321-0fed-cba987654321"), Title = "Food" }
    };
    
    //Lista statica di categorie per popolare la select nel form di inserimento di un nuovo prodotto. Simula le categorie in un db.
    private static List<Product> Products = new List<Product>()
    {
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Pc",
            Price = 1000,
            Description = "Powerful pc",
            Category = Categories[0]
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Tv",
            Price = 2000,
            Description = "A normal television",
            Category = Categories[0]
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Book",
            Price = 1000,
            Description = "A book",
            Category = Categories[1]
        }
    };
    
    public IActionResult Index()
    {

        var products = Products;
        
        var productsList = new ProductsListModel()
        {
            Products = products
        };
        
        return View(productsList);
    }
    
    public IActionResult Add()
    {
        var addProduct = new AddProduct()
        {
            Categories = Categories
        };
        return View(addProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProduct(AddProduct addProduct)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Something went wrong";
            return RedirectToAction("Add");
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = addProduct.Name,
            Description = addProduct.Description,
            Category = Categories.FirstOrDefault(x => x.Id == addProduct.CategoryId),
            Price = addProduct.Price
        };
        
        Products.Add(product);
        
        return RedirectToAction("Index");
    }

    public IActionResult GetDocument()
    {
        var file = System.IO.File.ReadAllBytes("wwwroot/Documents/httpcontext.pdf");
        return File(file, "application/pdf", "httpcontext.pdf");
    }
}