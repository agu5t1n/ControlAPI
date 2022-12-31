using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(string name);
        List<Product> FindByID(string name, params Expression<Func<Product, object>>[] includes);
        List<Product> GetByCategory(string name, params Expression<Func<Product, object>>[] includes);
        
        void Save(Product product);
        void Update(Product product);
        

    }
}
