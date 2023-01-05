using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Repository;

namespace ControlAPI.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryRepository _categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        public void Save(Category category)
        {
            _categoryRepository.Save(category);
        }
    }
}