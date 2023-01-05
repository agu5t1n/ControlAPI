using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Logic
{
    public interface IOrderLogic
    {
        Order GetOrder(int numbill);
        void Save(Order order);
        void Update(Order order);
        bool Delete (int id);
    }
}
