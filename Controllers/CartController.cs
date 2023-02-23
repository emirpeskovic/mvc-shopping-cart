using API.Extensions;
using API.Managers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly ProductManager _productManager;

        public CartController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        // This GET makes no sense, but that's what the assignment wants me to do
        [HttpGet]
        public IEnumerable<Product> Get(string productName, double productPrice) 
            => _productManager.GetProducts().Where(p => p.Name == productName && p.Price == productPrice);

        // I had to add `ID` to Product for this to make better sense
        [HttpPost]
        public void AddToCart(int productId)
        {
            // Find the product with the corresponding ID
            var product = _productManager.GetProducts().FirstOrDefault(p => p.Id == productId);
            if (product == null) return; // Don't add if it doesn't exist
            
            // Get the current cart, create one if it doesn't exist, and add the product to the cart
            var cart = HttpContext.Session.GetObjectFromJson<List<Product>>("cart");
            cart ??= new List<Product>();
            cart.Add(product);

            // Save the cart to the session
            HttpContext.Session.SetObjectAsJson("cart", cart);
        }
    }
}
