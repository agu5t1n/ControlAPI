using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Logic
{
    public interface IBillLogic
    {
        Bill GetBill(int numbull);
        Bill FindNumBill();
        double TotalByDate(DateTime dateTime);
        List<Bill> FindByDate(DateTime Datetime);
        void Save(Bill bill);
        void Update(Bill bill);
        bool Delete(int id);
    }
}
