using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest update);
    ReturnModel<CategoryResponseDto> Remove(int id);
}