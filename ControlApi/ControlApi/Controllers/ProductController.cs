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
        [Route("GetProduct")]
        public ActionResult<ProductDTORs> GetProduct(string name)
        {
            var product = _productLogic.GetProduct(name);
            var productDTORs = _mapper.Map<ProductDTORs>(product);

            return productDTORs;
        }
        [HttpGet()]
        [Route("ProductByCategory")]
        public ActionResult<List<ProductDTORs>> ProductByCategory(string name)
        {
            var product = _productLogic.GetByCategory(name);
            var productDTORs = _mapper.Map<List<ProductDTORs>>(product);

            return productDTORs;
        }
        [HttpGet()]
        [Route("StockByCategory")]
        public ActionResult<int> StockByCategory(string name)
        {
            var stock = _productLogic.StockByCategory(name);


            return stock;
        }
        [HttpGet()]
        [Route("TotalStock")]
        public ActionResult<int> TotalStock()
        {
            var product = _productLogic.GetStock();
            //var productDTORs = _mapper.Map<List<ProductDTORs>>(product);

            return product;
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