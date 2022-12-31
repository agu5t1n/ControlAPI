using ControlAPI.Entities;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ControlDbContext _context;
        public ProductRepository(ControlDbContext context)
        {
            _context = context;
        }

        public List<Product> FindByID(string name, params Expression<Func<Product, object>>[] includes)
        {
            var product = _context.Set<Product>().AsQueryable()
                            .Where(x => x.Name == name)
                            .Include(t => t.Category)
                            .ToList();

            return product;

        }
        public List<Product> GetByCategory(string name, params Expression<Func<Product, object>>[] includes)
        {
            var ID = _context.Set<Product>().AsQueryable()
                        .Where(x => x.Category.Type == name)
                        .Include(t => t.Category).ToList();
            return ID.ToList();

        }

        public Product GetProduct(string name)
        {
            Product product = _context.Products.Find(name);
            return product;
        }
        public void Save(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

    }
}