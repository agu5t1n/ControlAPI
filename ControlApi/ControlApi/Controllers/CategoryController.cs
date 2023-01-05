using AutoMapper;
using ControlApi.DTO;
using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using ControlAPI.Logic;
using Microsoft.AspNetCore.Mvc;

namespace ControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryLogic _categoryLogic;
        private readonly IMapper _mapper;


        public CategoryController(IMapper mapper, ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;

            _mapper = mapper;
        }
        [HttpGet()]
        [Route("GetCategories")]
        public ActionResult<List<CategoryDTORs>> GetCategories()
        {
            var category = _categoryLogic.GetCategories();
            var CategoryDTORs = _mapper.Map<List<CategoryDTORs>>(category);

            return CategoryDTORs;
        }
        [HttpPost]
        public ActionResult Save(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            _categoryLogic.Save(category);

            return Ok(category);
        }
    };

}