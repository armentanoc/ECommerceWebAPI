
namespace ECommerce.Domain.Utils
{
    public class ObjectValidator
    {
        public static bool IsValid(object obj)
        {
            if(obj != null) return true;
            throw new ArgumentException($"Object can't be null. ({nameof(obj)})");
        }

        public static bool IsDateTimeValid(DateTime date)
        {
            if (date != default(DateTime)) return true;
            throw new ArgumentException($"DateTime can't be null or default. ({date})");
        }
    }
}
