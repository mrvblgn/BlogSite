using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAll();
    ReturnModel<CommentResponseDto> GetById(Guid id);
    ReturnModel<CommentResponseDto> Add(CreateCommentRequest create);
    ReturnModel<CommentResponseDto> Update(UpdateCommentRequest update);
    ReturnModel<CommentResponseDto> Remove(Guid id);
}