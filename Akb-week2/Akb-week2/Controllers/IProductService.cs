using System.Collections.Generic;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
}

public class FakeProductService : IProductService
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 19.99 },
        new Product { Id = 2, Name = "Product 2", Price = 29.99 },
        // ... Diðer ürünler
    };

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}

public interface IUserService
{
    bool IsUserAuthenticated(string token);
}

public class FakeUserService : IUserService
{
    public bool IsUserAuthenticated(string token)
    {
        // Fake bir þekilde kullanýcýyý doðrula
        return !string.IsNullOrEmpty(token);
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
