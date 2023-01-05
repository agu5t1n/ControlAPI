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
        public Product GetProduct(string name)
        {
            try
            {
                return _productRepository.FindByID(name)[0];
            }
            catch (Exception)
            {

                return null;
            }
           
        }
        public int GetStock()
        {
            return _productRepository.GetStock();
        }
        public List<Product> GetByCategory(string name)
        {
            return _productRepository.GetByCategory(name);
        }
        public int StockByCategory(string name)
        {
            return _productRepository.StockByCategory(name);
        }
        public void Save(Product product)
        {
            _productRepository.Save(product);
        }
        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}