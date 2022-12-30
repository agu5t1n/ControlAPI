using ControlAPI.Entities;
using ControlAPI.Interfaces.Logic;
using ControlAPI.Interfaces.Repository;

namespace ControlAPI.Logic
{
    public class ProductLogic : IProductLogic
    {
        private IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            return _productRepository.FindByID(id, t => t.Category)[0];
        }


        public void Save(Product product)
        {
            _productRepository.Save(product);
        }
    }
}