using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;

namespace ControlAPI.Logic
{
    public class BillLogic : IBillLogic
    {
        private IBillRepository _billRepository;

        public BillLogic(IBillRepository BillRepository)
        {
            _billRepository = BillRepository;
        }

        public Bill GetBill(int numbill)
        {
            return _billRepository.FindByID(numbill)[0];
        }
        public List<Bill> FindByDate(DateTime Datetime)
        {
            return _billRepository.FindByDate(Datetime);
        }
        public Bill FindNumBill()
        {
            return _billRepository.FindNumBill();
        }
        public double TotalByDate(DateTime Datetime)
        {
            return _billRepository.TotalByDate(Datetime);
        }
        public void Save(Bill bill)
        {
            _billRepository.Save(bill);
        }
        public void Update(Bill bill)
        {
            _billRepository.Update(bill);
        }
        public bool Delete(int id)
        {
            bool confirmation = _billRepository.Delete(id);
            return confirmation;
        }
    }
}