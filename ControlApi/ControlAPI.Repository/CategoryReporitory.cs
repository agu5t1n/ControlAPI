using ControlAPI.Entities;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ControlDbContext _context;
        public CategoryRepository(ControlDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var Category = _context.Set<Category>().AsQueryable()
                            .ToList();

            return Category;

        }
        public void Save(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

    }
}