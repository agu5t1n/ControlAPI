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

        int GetStock();
        List<Product> GetByCategory(string name);
        int StockByCategory(string name);
        void Save(Product product);
        void Update(Product product);
    }
}
