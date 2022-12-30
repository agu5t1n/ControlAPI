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
        public ActionResult<ProductDTORs> GetId(int id)
        {
            var product = _productLogic.GetProduct(id);
            var productDTORs = _mapper.Map<ProductDTORs>(product);

            return productDTORs;
        }

        [HttpPost]
        public ActionResult Save(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productLogic.Save(product);

            return Ok(product);
        }

    };

}