using EShop.Domain.Repositories;
using EShop.Domain.Models;

namespace EShop.Domain.Seeders;

public class EShopSeeder(DataContext context) : IESeeder
{
    public async Task Seed()
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "Cobi", Ean = "1234" },
                new Product { Name = "Duplo", Ean = "431" },
                new Product { Name = "Lego", Ean = "12212"}
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
