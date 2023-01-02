using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Order GetOrder(int numbill);
        List<Order> FindByID(int name, params Expression<Func<Order, object>>[] includes);
        //List<Product> GetByCategory(string name, params Expression<Func<Product, object>>[] includes);

        void Save(Order order);
        void Update(Order order);
        bool Delete(int id);



    }
}
