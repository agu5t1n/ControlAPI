using AutoMapper;
using ControlApi.DTO;
using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {

        private readonly IOrderLogic _orderLogic;
        private readonly IBillLogic _billLogic;
        private readonly IMapper _mapper;


        public OrderController(IMapper mapper, IOrderLogic orderLogic, IBillLogic billLogic)
        {
            _orderLogic = orderLogic;
            _billLogic = billLogic;
            _mapper = mapper;
        }
        [HttpGet()]
        [Route("ID")]
        public ActionResult<OrderDTO> GetId(int numbill)
        {
            var order = _orderLogic.GetOrder(numbill);
            var OrderDTORs = _mapper.Map<OrderDTO>(order);

            return OrderDTORs;
        }
        [HttpPost]
        public ActionResult Save(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _orderLogic.Save(order);

            return Ok(order);
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult Update(int id, OrderDTO orderDTO)
        {

            var order = _mapper.Map<Order>(orderDTO);
            order.Id = id;
            _orderLogic.Update(order);

            return Ok(order);
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int numbill)
        {
            bool confirmation = _orderLogic.Delete(numbill);
            bool confirmation2 = _billLogic.Delete(numbill);

            return Ok(confirmation);
        }

    };

}