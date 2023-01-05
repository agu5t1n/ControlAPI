using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Repository;

namespace ControlAPI.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderRepository _orderRepository;

        public OrderLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order GetOrder(int numbill)
        {
            return _orderRepository.FindByID(numbill)[0];
        }
        public void Save(Order order)
        {
            _orderRepository.Save(order);
        }
        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
        public bool Delete(int id)
        {
            bool confirmation = _orderRepository.Delete(id);
            return confirmation;
        }
    }
}