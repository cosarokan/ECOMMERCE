
namespace ECOMMERCE.CORE.Entities
{
    public class Neighborhood : Entity<int>
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }

        public virtual District District { get; set; }
    }
}
