using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Logic
{
    public interface IProductLogic
    {
        Product GetProduct(string name);

        List<Product> GetByCategory(string name);

        void Save(Product product);
        void Update(Product product);
    }
}
