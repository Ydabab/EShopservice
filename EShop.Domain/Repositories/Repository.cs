using EShop.Domain.Models;
namespace EShop.Domain.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
    
}
