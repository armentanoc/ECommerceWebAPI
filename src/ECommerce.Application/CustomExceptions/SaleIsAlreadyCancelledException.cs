
namespace ECommerce.Application.CustomExceptions
{
    internal class SaleIsAlreadyCancelledException : Exception
    {
        public SaleIsAlreadyCancelledException(string? message = "Sale is already cancelled") : base(message)
        {
        }
    }
}