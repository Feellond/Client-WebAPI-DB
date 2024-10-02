using Client.Model.Base;

namespace Client.Model
{
    public class Manufacturer : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public class ManufacturerRequest : Manufacturer
    {

    }
}
