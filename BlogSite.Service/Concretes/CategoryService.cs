using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entites;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category>  categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = responses,
            Success = true,
            Message = "Kategoriler listelendi",
            StatusCode = 200
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        Category category = _categoryRepository.GetById(id);
        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = dto,
            Success = true,
            Message = "Kategori bulundu",
            StatusCode = 200
        };
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create)
    {
        Category createdCategory = _mapper.Map<Category>(create);
        _categoryRepository.Add(createdCategory);
        
        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = dto,
            Message = "Kategori eklendi",
            Success = true,
            StatusCode = 200
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest update)
    {
        Category category = _categoryRepository.GetById(update.Id);

        Category updated = new Category()
        {
            Name = category.Name,
            CreatedDate = category.CreatedDate,
        };
        
        Category updatedCategory = _categoryRepository.Update(updated);
        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = dto,
            Message = "Kategori güncellendi",
            Success = true,
            StatusCode = 200
        };
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        Category category = _categoryRepository.GetById(id);
        Category deletedCategory = _categoryRepository.Remove(category);

        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(deletedCategory);

        return new ReturnModel<CategoryResponseDto>()
        {
            Data = dto,
            Message = "Kategori silindi",
            Success = true,
            StatusCode = 200
        };
    }
}






