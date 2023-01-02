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
        //public List<Product> GetByCategory(string name, params Expression<Func<Product, object>>[] includes)
        //{
        //    var ID = _context.Set<Product>().AsQueryable()
        //                .Where(x => x.Category.Type == name)
        //                .Include(t => t.Category).ToList();
        //    return ID.ToList();

        //}

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
        public bool Delete(int numbill)
        {
            try
            {
                var orderCorrect = _context.Set<Order>().AsQueryable()
               .Where(_x => _x.NumBill == numbill).ToList();
                foreach (var orderRemove in orderCorrect)
                {
                    _context.Remove(GetOrder(orderRemove.Id));
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


            //var billnew = 0;
            //var Bill = _context.Set<Bill>().AsQueryable()
            //    .OrderByDescending(x => x.NumBill)
            //                .Take(1).ToList();
            //foreach (var bill in Bill)
            //{
            //    billnew = bill.NumBill;
            //}
            //return billnew;


            //try
            //{
            //    _context.Remove(GetOrder(id));
            //    _context.SaveChanges();
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

    }
}