namespace API.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
