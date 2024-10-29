using AutoMapper;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entites;

namespace BlogSite.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();
        CreateMap<Post, PostResponseDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Author.UserName));

        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();

        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<UpdateCategoryRequest, Comment>();
        CreateMap<Comment, CommentResponseDto>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName))
            .ForMember(x => x.Post, opt => opt.MapFrom(x => x.Post.Author));

        CreateMap<ChangePasswordRequestDto, User>();
        CreateMap<LoginRequestDto, User>();
        CreateMap<RegisterRequestDto, User>();
        CreateMap<User, UserResponseDto>();
    }
}