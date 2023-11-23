using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Client.Services.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<bool> CreateAsync(T obj);
    Task<bool> UpdateAsync(T obj);
    Task<bool> DeleteAsync(int id);
}