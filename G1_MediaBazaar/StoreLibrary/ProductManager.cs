using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class ProductManager
    {
        private readonly IProductDataInterface _productDataInterface;
        public ProductManager(IProductDataInterface productDataInterface)
        {
            _productDataInterface = productDataInterface;
        }

        public int GenerateId()
        {
            return _productDataInterface.GenerateNewProductId();
        }
        public void AddProduct(Product product)
        {
            _productDataInterface.AddProductToDatabase(product);
        }
        public void RemoveProduct(Product product)
        {
            _productDataInterface.RemoveProductFromDatabase(product);
        }
        public Product CheckProductFromDB(Product product)
        {
            return _productDataInterface.GetProductFromDatabase(product);
        }
        public void UpdateProductStock(Product product)
        {
            _productDataInterface.UpdateStock(product);
        }
        public List<Product> Products()
        {
            return _productDataInterface.GetAllProducts();
        }

        public bool ReassignProdsToDept(List<Product> reassignedProds) 
        {
            return _productDataInterface.ReassignProdsToDept(reassignedProds);
        }
    }
}
