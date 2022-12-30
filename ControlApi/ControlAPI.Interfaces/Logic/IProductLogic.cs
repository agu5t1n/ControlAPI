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
        Product GetProduct(int id);

        void Save(Product product);
    }
}
