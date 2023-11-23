using ExtensaoCurricular.Server.Context;
using ExtensaoCurricular.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace ExtensaoCurricular.Server.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public readonly ApiDbContext _db;

    public BaseRepository(ApiDbContext db)
    {
        _db = db;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _db.Set<T>().WhereInterpolated($"Id == {id}").FirstOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(T obj)
    {
        await _db.Set<T>().AddAsync(obj);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(T obj)
    {
        _db.Set<T>().Update(obj);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var amountOfItemsDeleted = await _db.Set<T>().WhereInterpolated($"Id == {id}").ExecuteDeleteAsync();
        return amountOfItemsDeleted > 0;
    }
}