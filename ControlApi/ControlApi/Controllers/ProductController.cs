using AutoMapper;
using ControlApi.DTO;
using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductLogic _productLogic;
        private readonly IMapper _mapper;


        public ProductController(IMapper mapper, IProductLogic productLogic)
        {
            _productLogic = productLogic;
            _mapper = mapper;
        }
        [HttpGet()]
        [Route("ID")]
        public ActionResult<ProductDTORs> GetId(string name)
        {
            var product = _productLogic.GetProduct(name);
            var productDTORs = _mapper.Map<ProductDTORs>(product);

            return productDTORs;
        }
        [HttpGet()]
        [Route("GetByCategory")]
        public ActionResult<List<ProductDTORs>> GetByCategory(string name)
        {
            var product = _productLogic.GetByCategory(name);
            var productDTORs = _mapper.Map<List<ProductDTORs>>(product);

            return productDTORs;
        }

        [HttpPost]
        public ActionResult Save(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productLogic.Save(product);

            return Ok(product);
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(int id, ProductDTO productDTO)
        {
            
            var product = _mapper.Map<Product>(productDTO);
            product.Id = id;
            _productLogic.Update(product);

            return Ok(product);
        }

    };

}