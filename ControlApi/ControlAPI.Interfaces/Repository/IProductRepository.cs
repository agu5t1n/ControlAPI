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
        Product GetProduct(int id);
        List<Product> FindByID(int id, params Expression<Func<Product, object>>[] includes);
        void Save(Product product);

    }
}
