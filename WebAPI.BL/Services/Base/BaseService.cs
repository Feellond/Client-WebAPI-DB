using Microsoft.EntityFrameworkCore;
using WebAPI.DAL;
using WebAPI.DAL.Entities.Base;

namespace WebAPI.BL.Services.Base
{
    public abstract class BaseService<TEntity, TId> : IBaseService<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получение всех элементов
        /// </summary>
        /// <returns>Коллекция элементов</returns>
        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            var list = await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            return list;
        }

        /// <summary>
        /// Получение элемента по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            var foundEntity = await _dbContext.FindAsync<TEntity>(id);
            return foundEntity;
        }

        /// <summary>
        /// Создание нового элемента в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> CreateAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            return await SaveAsync();
        }

        /// <summary>
        /// Изменение элемента в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var saved = _dbContext.Update(entity);
            return await SaveAsync();
        }

        /// <summary>
        /// Удаление элемента из БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbContext.Remove(entity);
            return await SaveAsync();
        }

        /// <summary>
        /// Сохранение изменений БД
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
