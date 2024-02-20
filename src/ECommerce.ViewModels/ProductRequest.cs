using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class ProductRequest : Request
    {
        [Required(ErrorMessage = "Name is a required property.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Price is a required property.")]
        public decimal Price { get; init; }

        //Optional
        public string Description { get; init; }

        public ProductRequest(string name, decimal price, string description = "Vazia")
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
