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
            var Datenow= DateTime.Now;
            var Bill = _context.Set<Bill>().AsQueryable()
                            .Where(x => x.Date == Datetime && x.Date <=Datenow) 
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

        public int FindNumBill()
        {
            var billnew = 0;
            var Bill = _context.Set<Bill>().AsQueryable()
                            .OrderByDescending(x => x.NumBill)
                            .Take(1).ToList();
            foreach (var bill in Bill)
            {
                billnew = bill.NumBill;
            }
            return billnew;

        }


        //var lastRecord = objContext.ResetPassword
        //                   .Where(x
        //                         => x.Email == email
        //                         && x.Status == 0)
        //                     .OrderByDescending(x => x.Id)
        //                     .Take(1);



        //public List<Product> GetByCategory(string name, params Expression<Func<Product, object>>[] includes)
        //{
        //    var ID = _context.Set<Product>().AsQueryable()
        //                .Where(x => x.Category.Type == name)
        //                .Include(t => t.Category).ToList();
        //    return ID.ToList();

        //}

        public Bill GetProduct(int numbill)
        {
            Bill bill = _context.Bill.Find(numbill);
            return bill;
        }
        public void Save(Bill bill)
        {
            var billnew = FindNumBill();
            bill.Client = "NA";
            bill.DocumentClient = "NA";
            bill.NumBill = billnew + 1;
           
            var datenow = DateTime.Now.ToString("yyyy-MM-dd");
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
                foreach (var billremove in billCorrect)
                {
                    _context.Remove(GetProduct(billremove.Id));
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}