using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entites;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
    Task<User> RegisterAsycn(RegisterRequestDto dto);
    Task<User> GetByEmailAsycn(string email);
    Task<User> LoginAsycn(LoginRequestDto dto);
    Task<User> UpdateAsycn(string id, UserUpdateRequestDto dto);
    Task<string> DeleteAsycn(string id);
    Task<User> ChangePasswordAsycn(string id, ChangePasswordRequestDto requestDto);
}