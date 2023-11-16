using Contacts.Domain.Entities.Base;

namespace Contacts.Domain.Repositories.Base;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
