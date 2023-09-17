namespace CrudProductManager.API.Domain.Repositories.Base;

public interface IRepositoryBase<T>
{
    Task<T> Create(T type);
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int? id);
    Task<T> Update(T type, int? id);
    Task<T> Delete(int? id);
}