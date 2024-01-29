    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public interface IProductDataInterface
    {
        int GenerateNewProductId();
        void AddProductToDatabase(Product product);
        void RemoveProductFromDatabase(Product product);
        Product GetProductFromDatabase(Product product);
        void UpdateStock(Product product);
        List<Product> GetAllProducts();
        bool ReassignProdsToDept(List<Product> reassignedProds);
    }
}
