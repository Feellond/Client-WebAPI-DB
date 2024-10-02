using WebAPI.BL.Services.Base;
using WebAPI.DAL;
using WebAPI.DAL.Entities.Database;

namespace WebAPI.BL.Services
{
    public class ManufacturerService : BaseService<Manufacturer, int>
    {
        public ManufacturerService(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
