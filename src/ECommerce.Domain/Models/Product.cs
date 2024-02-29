
using ECommerce.Domain.Utils;

namespace ECommerce.Domain.Models
{
    public class Product : BaseEntity
    {
        public uint QuantityRemaining { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Product()
        {
            // required by EF
        }

        public Product(string name, string description, decimal price, uint quantity)
        {
            if(PrimaryValidator.IsValid(name)) Name = name;
            if(PrimaryValidator.IsValid(price)) Price = price;
            if(PrimaryValidator.IsValid(quantity, true)) QuantityRemaining = quantity;
            Description = description;
        }

        public void IncreaseQuantity()
        {
            QuantityRemaining++;
        }
        public void DecreaseQuantity()
        {
            if (QuantityRemaining < 1)
                throw new InsufficientQuantityException($"Product quantity is insufficient. Operation can't be executed. (Name: {Name}, Id: {Id})");
            else
                QuantityRemaining--;
        }
    }
}
