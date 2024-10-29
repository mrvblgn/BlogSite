using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entites;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        List<Comment> comments = _commentRepository.GetAll();
        List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>()
        {
            Data = responses,
            Message = "Tüm yorumlar listelendi",
            Success = true,
            StatusCode = 200
        };
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {
        var comment = _commentRepository.GetById(id);
        var commentResponseDto = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = commentResponseDto,
            Message = "Aranan yorum",
            Success = true,
            StatusCode = 200
        };
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequest create)
    {
        var createdComment = _mapper.Map<Comment>(create);
        createdComment.Id = Guid.NewGuid();
        
        _commentRepository.Add(createdComment);
        
        CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = response,
            Message = "Yeni yorum eklendi",
            Success = true,
            StatusCode = 200
        };
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updatePost)
    {
        Comment comment = _commentRepository.GetById(updatePost.Id);

        Comment update = new Comment()
        {
            Id = comment.Id,
            Text = updatePost.Text,
            UserId = comment.UserId,
            User = comment.User,
            CreatedDate = comment.CreatedDate,
            PostId = comment.PostId,
        };
        
        Comment updatedComment = _commentRepository.Update(update);
        CommentResponseDto response = _mapper.Map<CommentResponseDto>(updatedComment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = response,
            Message = "Yorum güncellendi",
            Success = true,
            StatusCode = 200
        };

    }

    public ReturnModel<CommentResponseDto> Remove(Guid id)
    {
        Comment comment = _commentRepository.GetById(id);
        Comment deletedComment = _commentRepository.Remove(comment);
        
        CommentResponseDto dto = _mapper.Map<CommentResponseDto>(deletedComment);

        return new ReturnModel<CommentResponseDto>()
        {
            Data = dto,
            Message = "Yorum silindi",
            Success = true,
            StatusCode = 200
        };
    }
}