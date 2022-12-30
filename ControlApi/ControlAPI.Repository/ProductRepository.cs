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

        public List<Product> FindByID(int id, params Expression<Func<Product, object>>[] includes)
        {
                var ID = _context.Set<Product>().AsQueryable()
                            .Where(x => x.Id == id);
                foreach (Expression<Func<Product, object>> i in includes)
                {
                    ID = ID.Include(i);
                }
                return ID.ToList();

        }

        public Product GetProduct(int id)
        {
            Product product= _context.Products.Find(id);
            return product;
        }
        public void Save (Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

    }
}