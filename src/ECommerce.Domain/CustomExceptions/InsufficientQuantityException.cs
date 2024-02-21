
namespace ECommerce.Domain.Models
{
    internal class InsufficientQuantityException : Exception
    {
        public InsufficientQuantityException()
        {
        }

        public InsufficientQuantityException(string? message) : base(message)
        {
        }
    }
}