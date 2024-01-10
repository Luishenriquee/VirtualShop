using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories;

namespace VirtualShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoriesEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoriesEntity);
    }

    public async Task AddCategory(CategoryDTO categoryDto)
    {
        Category category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(category);
        categoryDto.CategoryId = category.CategoryId;
    }

    public async Task UpdateCategory(CategoryDTO categoryDto)
    {
        Category category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(category);
    }

    public async Task RemoveCategory(int id)
    {
        Category category = _categoryRepository.GetById(id).Result;
        await _categoryRepository.Delete(category.CategoryId);
    }
}