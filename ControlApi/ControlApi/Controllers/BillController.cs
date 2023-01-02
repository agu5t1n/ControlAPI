using AutoMapper;
using ControlApi.DTO;
using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : Controller
    {

        private readonly IBillLogic _billLogic;
        private readonly IMapper _mapper;


        public BillController(IMapper mapper, IBillLogic billLogic)
        {
            _billLogic = billLogic;
            _mapper = mapper;
        }
        [HttpGet()]
        [Route("ID")]
        public ActionResult<BillDTORs> GetId(int numbill)
        {
            var bill = _billLogic.GetProduct(numbill);
            var billDTORs = _mapper.Map<BillDTORs>(bill);

            return billDTORs;
        }
        [HttpGet()]
        [Route("FindByDate")]
        public ActionResult<List<BillDTORs>> FindByDate(DateTime Datetime)
        {
            var bill = _billLogic.FindByDate(Datetime);
            var billDTORs = _mapper.Map<List<BillDTORs>>(bill);

            return billDTORs;
        }
        [HttpGet()]
        [Route("TotalByDate")]
        public ActionResult<double> TotalByDate(DateTime Datetime)
        {
            var total = _billLogic.TotalByDate(Datetime);
           

            return total;
        }
        //[HttpGet()]
        //[Route("GetByCategory")]
        //public ActionResult<List<BillDTORs>> GetByCategory(string name)
        //{
        //    var product = _billLogic.(name);
        //    var productDTORs = _mapper.Map<List<BillDTORs>>(product);

        //    return productDTORs;
        //}
        //[HttpGet()]
        //[Route("numbill")]
        //public ActionResult<BillDTORs> GetNumbill()
        //{
        //    var bill = _billLogic.FindNumBill();
        //    var billDTORs = _mapper.Map<BillDTORs>(bill);

        //    return billDTORs;
        //}
        [HttpPost]
        public ActionResult Save(BillDTO billDTO)
        {
            var bill = _mapper.Map<Bill>(billDTO);
           
            _billLogic.Save(bill);

            return Ok(bill);
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult Update(int id, BillDTO billDTO)
        {
            var bill = _mapper.Map<Bill>(billDTO);
            bill.Id = id;
            _billLogic.Update(bill);

            return Ok(bill);
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            bool confirmation = _billLogic.Delete(id);

            return Ok(confirmation);
        }

    };

}