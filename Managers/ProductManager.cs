using API.Models;

namespace API.Managers
{
    public class ProductManager
    {
        private readonly List<Product> products;

        public ProductManager()
        {
            products = new() 
            {
                new Product(1, "Milk", 2.5),
                new Product(2, "Bread", 1.5),
                new Product(3, "Eggs", 3.5),
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
