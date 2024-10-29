using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IPostService
{
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto> GetById(Guid id);
    ReturnModel<PostResponseDto> Add(CreatePostRequest create);
    ReturnModel<PostResponseDto> Update(UpdatePostRequest update);
    ReturnModel<PostResponseDto> Remove(Guid id);
    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(string id);
    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id);
}