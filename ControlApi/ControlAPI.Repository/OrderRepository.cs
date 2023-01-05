using ControlAPI.Entities;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ControlDbContext _context;
        public OrderRepository(ControlDbContext context)
        {
            _context = context;
        }

        public List<Order> FindByID(int numbill, params Expression<Func<Order, object>>[] includes)
        {
            var Order = _context.Set<Order>().AsQueryable()
                            .Where(x => x.NumBill == numbill)
                            .ToList();

            return Order;

        }
        public Order GetOrder(int numbill)
        {
            Order order = _context.Order.Find(numbill);
            return order;
        }
        public void Save(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
        }
        public void Update(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }
        private Product Updateproduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return product;
        }
        public bool Delete(int numbill)
        {
            try
            {

                var orderCorrect = _context.Set<Order>().AsQueryable()
                                           .Where(_x => _x.NumBill == numbill).ToList();
                if (orderCorrect.Count != 0)
                {

                    foreach (var orderRemove in orderCorrect)
                    {
                        var product = _context.Set<Product>().AsQueryable()
                                              .Where(_x => _x.Id == orderRemove.IdProduct).ToList();
                        foreach (var productr in product)
                        {
                            productr.Stock = productr.Stock + orderRemove.Amount;
                            _context.Update(Updateproduct(productr));
                        }

                        _context.Remove(GetOrder(orderRemove.Id));
                    }
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}