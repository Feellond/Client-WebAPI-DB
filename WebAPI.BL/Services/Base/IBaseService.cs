using WebAPI.DAL.Entities.Base;

namespace WebAPI.BL.Services.Base
{
    public interface IBaseService<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> SaveAsync();
    }
}
