using CleanArch.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interface
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task AddAsync(ProductDTO DTO);
        Task UpdateAsync(ProductDTO DTO);
        Task RemoveAsync(int? id);

    }
}
