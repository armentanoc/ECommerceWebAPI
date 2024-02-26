
namespace ECommerce.Domain.Models
{
    public class BaseEntity
    {
        public uint Id { get; set; }
        public void SetId(uint id)
        {
            Id = id;
        }
    }
}
