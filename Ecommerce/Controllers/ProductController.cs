using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[Route("products")]
public class ProductController : Controller
{

    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    public IActionResult Index()
    {
        var productsList = new ProductsListModel()
        {
            Products = _productService.Products
        };
        
        return View(productsList);
    }
    
    [Route("add")]
    public IActionResult Add()
    {
        var addProduct = new AddProduct()
        {
            Categories = _productService.Categories
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
            Category = _productService.Categories.FirstOrDefault(x => x.Id == addProduct.CategoryId),
            Price = addProduct.Price
        };
        
        _productService.Products.Add(product);
        
        return RedirectToAction("Index");
    }

    [HttpGet("product/edit/{id:guid}")]
    public IActionResult Edit(Guid id)
    {
        var product = _productService.Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return RedirectToAction("Index");
        }
        
        return View(new EditProduct()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Categories = _productService.Categories,
            Price = product.Price
        });
    }

    [HttpPost("product/edit/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult SaveEdit(Guid id, EditProduct editProduct)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }
        
        var existingProduct = _productService.Products.FirstOrDefault(x => x.Id == editProduct.Id);

        if (existingProduct == null)
        {
            return RedirectToAction("Index");
        }
        
        existingProduct.Name = editProduct.Name;
        existingProduct.Description = editProduct.Description;
        existingProduct.Price = editProduct.Price;
        existingProduct.Category = _productService.Categories.FirstOrDefault(x => x.Id == editProduct.CategoryId);
        
        return RedirectToAction("Index");
    }

    [Route("product/get-doc")]
    public IActionResult GetDocument()
    {
        var file = System.IO.File.ReadAllBytes("wwwroot/Documents/httpcontext.pdf");
        return File(file, "application/pdf", "httpcontext.pdf");
    }
    
    
}