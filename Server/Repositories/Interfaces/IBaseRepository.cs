namespace ExtensaoCurricular.Server.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<bool> CreateAsync(T obj);
    Task<bool> UpdateAsync(T obj);
    Task<bool> DeleteAsync(int id);
}