
namespace ECommerce.Domain.Utils
{
    public class PrimaryValidator
    {
        public static bool IsValid(string value)
        {
            if(!string.IsNullOrWhiteSpace(value)) return true;
            throw new ArgumentException($"String value can't be null, empty or whitespace. ({value})");
        }

        public static bool IsValid(decimal value)
        {
            if (value > 0) return true;
            throw new ArgumentException($"Decimal value must be greater than zero. ({value})");
        }
    }
}
