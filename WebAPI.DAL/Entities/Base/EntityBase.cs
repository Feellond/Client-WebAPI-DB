namespace WebAPI.DAL.Entities.Base
{
    public class EntityBase : IEntityBase<int>
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
