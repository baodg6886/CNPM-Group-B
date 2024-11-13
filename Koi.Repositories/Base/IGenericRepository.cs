using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koi.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        // Tìm kiếm theo điều kiện tùy chỉnh
        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);

        // Xóa theo điều kiện tùy chỉnh
        Task DeleteAsync(Func<T, bool> predicate);

        // Lấy dữ liệu theo truy vấn LINQ
        Task<IEnumerable<T>> GetByQueryAsync(Func<IQueryable<T>, IQueryable<T>> query);

        // Lưu thay đổi vào cơ sở dữ liệu
        Task SaveChangesAsync();
    }
}
