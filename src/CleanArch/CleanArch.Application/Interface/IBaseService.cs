using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);

        Task<T> AddAsync(T DTO);
        Task<T> UpdateAsync(T DTO);
        Task RemoveAsync(int? id);
    }
}
