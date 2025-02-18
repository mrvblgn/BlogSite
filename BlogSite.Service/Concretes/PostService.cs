using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entites;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            Success = true,
            Message = "Tüm post'lar listelendi.", 
            StatusCode = 200
        };
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        var post = _postRepository.GetById(id);
        var postDto = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto>
        {
            Data = postDto,
            Message = "Aranan doktor bulundu",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();
        
        _postRepository.Add(createdPost);
        
        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post eklendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> Remove(Guid id)
    {
        Post post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Remove(post);
        
        PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

        return new ReturnModel<PostResponseDto>()
        {
            Data = response,
            Message = "Post silindi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost)
    {
        Post post = _postRepository.GetById(updatePost.Id);
        
        Post update = new Post
        {
            CategoryId = post.CategoryId,
            Content = updatePost.Content,
            Title = updatePost.Title,
            AuthorId = post.AuthorId,
            CreatedDate = post.CreatedDate,
        };

        Post updatedPost = _postRepository.Update(update);
        PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);
        
        return new ReturnModel<PostResponseDto>()
        {
            Data = dto,
            Success = true,
            Message = "Post güncellendi",
            StatusCode = 200
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(string id)
    {
        throw new NotImplementedException();
    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id)
    {
        var posts = _postRepository.GetAll(x => x.AuthorId == id);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }
}









