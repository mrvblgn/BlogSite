using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entites;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public async Task<User> ChangePasswordAsycn(string id, ChangePasswordRequestDto requestDto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        if (requestDto.NewPassword.Equals(requestDto.ConfirmPassword) is false)
        {
            throw new BusinessException("Parolalar uyuşmuyor.");
        }
        
        var result = await _userManager.ChangePasswordAsync(user, requestDto.CurrentPassword, requestDto.NewPassword);
        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }
        
        return user;
    }

    public async Task<string> DeleteAsycn(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }
        
        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return "Kullanıcı silindi";
    }

    public async Task<User> LoginAsycn(LoginRequestDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }
        
        bool checkPassword = await _userManager.CheckPasswordAsync(user, dto.Password);

        if (checkPassword is false)
        {
            throw new BusinessException("Parolanız yanlış.");
        }
        
        return user;
    }

    public async Task<User> UpdateAsycn(string id, UserUpdateRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        user.UserName = dto.Username;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.City = dto.City;
        
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return user;
    }

    public async Task<User> RegisterAsycn(RegisterRequestDto dto)
    {
        User user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            City = dto.City,
            UserName = dto.Username,
            
        };
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return user;
    }

    public async Task<User> GetByEmailAsycn(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }
        
        return user;
    }
}










