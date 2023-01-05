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
        public ActionResult<BillDTORs> GetBill(int numbill)
        {
            var bill = _billLogic.GetBill(numbill);
            var billDTORs = _mapper.Map<BillDTORs>(bill);

            return billDTORs;
        }

        [HttpGet()]
        [Route("Bill")]
        public ActionResult<Bill> FindBynumbill()
        {
            var bill = _billLogic.FindNumBill();


            return bill;
        }
        [HttpGet()]
        [Route("FindByDate")]
        public ActionResult<List<BillDTORs>> FindByDate(DateTime Datetime)
        {
            //var data= DateTime.Parse(Datetime);
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
        public ActionResult Delete(int numbill)
        {
            bool confirmation = _billLogic.Delete(numbill);

            return Ok(confirmation);
        }

    };

}