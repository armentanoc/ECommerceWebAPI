using ECommerce.Domain.Utils;
namespace ECommerce.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, string description, decimal price)
        {
            if(PrimaryValidator.IsValid(name)) Name = name;
            if(PrimaryValidator.IsValid(description)) Description = description;
            if(PrimaryValidator.IsValid(price)) Price = price;
        }
    }
}
