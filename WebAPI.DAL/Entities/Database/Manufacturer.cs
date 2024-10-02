using WebAPI.DAL.Entities.Base;

namespace WebAPI.DAL.Entities.Database
{
    public class Manufacturer : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        //public List<Product> Products { get; set; }
    }
}
