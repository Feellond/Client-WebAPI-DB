namespace Client.Services.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<bool> CreateAsync(TEntity product);
        Task<bool> UpdateAsync(TEntity product);
        Task<bool> DeleteAsync(int id);
    }
}
