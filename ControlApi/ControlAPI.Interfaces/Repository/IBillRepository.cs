using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Repository
{
    public interface IBillRepository
    {
        Bill GetProduct(int numbill);
        int FindNumBill(); 
        double TotalByDate(DateTime dateTime);
        List<Bill> FindByID(int numbill, params Expression<Func<Bill, object>>[] includes);
        List<Bill> FindByDate(DateTime Datetime, params Expression<Func<Bill, object>>[] includes);
        //List<Bill> GetByCategory(int numbill, params Expression<Func<Bill, object>>[] includes);

        void Save(Bill bill);
        void Update(Bill bill);

        bool Delete(int id);

    }
}
