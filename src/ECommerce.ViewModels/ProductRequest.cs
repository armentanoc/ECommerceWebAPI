using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class ProductRequest : Request
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "A quantidade do produto é obrigatória.")]
        public uint Quantity { get; init; }

        //Optional
        public string Description { get; init; }

        public ProductRequest(string name, decimal price, uint quantity, string description = "Vazia")
        {
            Name = name;
            Price = price;
            Quantity = quantity;

            if(description.Equals("string")) 
                description = "Vazia";

            Description = description;
        }
    }
}
