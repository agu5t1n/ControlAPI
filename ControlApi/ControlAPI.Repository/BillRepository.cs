using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlAPI.Repository
{
    public class BillRepository : IBillRepository
    {

        private readonly ControlDbContext _context;
        public BillRepository(ControlDbContext context)
        {
            _context = context;
        }
        public List<Bill> FindByID(int numbill, params Expression<Func<Bill, object>>[] includes)
        {
            var Bill = _context.Set<Bill>().AsQueryable()
                            .Where(x => x.Id == numbill)
                            .Include(s => s.Order)
                            .ToList();
            return Bill;
        }
        public List<Bill> FindByDate(DateTime Datetime, params Expression<Func<Bill, object>>[] includes)
        {
            var Datenow = DateTime.Now;
            var Bill = _context.Set<Bill>().AsQueryable()
                            .Where(x => x.Date == Datetime && x.Date <= Datenow)
                            .Include(s => s.Order)
                            .ToList();
            return Bill;
        }
        public double TotalByDate(DateTime Datetime)
        {
            var Datenow = FindByDate(Datetime);
            var Total = 0.00;
            foreach (var i in Datenow)
            {
                Total += i.Total;
            }
            return Total;
        }

        public Bill FindNumBill()
        {
            var billnew = new Bill();
            var Bill = _context.Set<Bill>().AsQueryable()
                            .OrderByDescending(x => x.NumBill)
                            .Take(1).ToList();
            foreach (var bill in Bill)
            {
                billnew.Id = bill.Id + 1;
                billnew.NumBill = bill.NumBill + 1;
            }
            return billnew;

        }
        public Bill GetBill(int numbill)
        {
            Bill bill = _context.Bill.Find(numbill);
            return bill;
        }
        public void Save(Bill bill)
        {
            var billnew = FindNumBill();
            var datenow = DateTime.Now.ToString("yyyy-MM-dd");
            bill.NumBill = billnew.NumBill;
            bill.Date = Convert.ToDateTime(datenow);
            _context.Add(bill);
            _context.SaveChanges();
        }
        public void Update(Bill bill)
        {
            var datenow = DateTime.Now.ToString("yyyy-MM-dd");
            bill.Date = Convert.ToDateTime(datenow);
            _context.Update(bill);
            _context.SaveChanges();
        }
        public bool Delete(int numbill)
        {
            try
            {
                var billCorrect = _context.Set<Bill>().AsQueryable()
                            .Where(_x => _x.NumBill == numbill)
                            .ToList();
                if (billCorrect.Count != 0)
                {
                    foreach (var billremove in billCorrect)
                    {
                        _context.Remove(GetBill(billremove.Id));
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
