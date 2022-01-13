using AutoMapper;
using CleanArch.Application.DTO;
using CleanArch.Application.Interface;
using CleanArch.Domain.Entity;
using CleanArch.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepoository;
        private readonly  IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepoository, IMapper mapper)
        {
            _categoryRepoository = categoryRepoository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categoriesEntity = await _categoryRepoository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _categoryRepoository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<CategoryDTO> AddAsync(CategoryDTO DTO)
        {
            var category = await _categoryRepoository.CreateAsync(_mapper.Map<Category>(DTO));
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO DTO)
        {
            var category = await _categoryRepoository.UpdateAsync(_mapper.Map<Category>(DTO));
            return _mapper.Map<CategoryDTO>(category);
        }
        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = _categoryRepoository.GetByIdAsync(id).Result;
            await _categoryRepoository.RemoveAsync(categoryEntity);
        }
    }
}
