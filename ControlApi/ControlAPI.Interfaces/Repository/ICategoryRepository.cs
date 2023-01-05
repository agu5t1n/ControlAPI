using ControlAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void Save(Category category);
    }
}
