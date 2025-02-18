using Ecommerce.Models;

namespace Ecommerce.Services;

public class ProductService
{
    //Lista statica di categorie per popolare la select nel form di inserimento di un nuovo prodotto. Simula le categorie in un db.
    private static List<Category> _categories = new()
    {
        new Category { Id = Guid.Parse("3f4e1a89-2d45-4f8d-9a7e-123456789abc"), Title = "Electronics" },
        new Category { Id = Guid.Parse("a1b2c3d4-e5f6-4789-abcd-9876543210ef"), Title = "Literature" },
        new Category { Id = Guid.Parse("fedcba98-7654-4321-0fed-cba987654321"), Title = "Food" }
    };
    
    //Lista statica di prodotti di partenza per popolare la tabella. Simula i prodotti in un database.
    private static List<Product> _products = new List<Product>()
    {
        new Product()
        {
            Id = Guid.Parse("9e765e95-87d5-43d7-b5be-8b0e1f6f8588"),
            Name = "Pc",
            Price = 1000,
            Description = "Powerful pc",
            Category = _categories[0]
        },
        new Product()
        {
            Id = Guid.Parse("dcbfe963-3211-4083-87df-2c6d21b9884d"),
            Name = "Tv",
            Price = 2000,
            Description = "A normal television",
            Category = _categories[0]
        },
        new Product()
        {
            Id = Guid.Parse("747aa2f3-3687-49c1-8328-347616da1dac"),
            Name = "Book",
            Price = 1000,
            Description = "A book",
            Category = _categories[1]
        }
    };

    public List<Product> Products
    {
        get => _products;
    }

    public List<Category> Categories
    {
        get => _categories;
    }
}