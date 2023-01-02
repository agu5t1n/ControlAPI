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

        public Bill GetProduct(int numbill)
        {
            return _billRepository.FindByID(numbill/*, t => t.Category*/)[0];
        }
        public List<Bill> FindByDate(DateTime Datetime)
        {
            return _billRepository.FindByDate(Datetime);
        }
        //public List<Product> GetByCategory(string name)
        //{
        //    return _billRepository.GetByCategory(name);
        //}
        public int FindNumBill()
        {
            return _billRepository.FindNumBill();
        } public double TotalByDate(DateTime Datetime)
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